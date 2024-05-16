using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

public class Ordering : BaseNpcAction
{
    public int averageWaitingInSeconds;
    public int waitingTimeDeviation;
    // public GameObject notaUI;

    private SeatsData data;
    private List<CostumerPreferenceParameter> costumerParameter = new List<CostumerPreferenceParameter>();
    private List<MenuParameter> menuParameters;
    private List<MenuParameter> pickedMenu = new List<MenuParameter>();

    protected class MenuScore{
        public int score;
        public MenuParameter menu;
    }


    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private bool setupHitBoxHandler(){
        data = actionsDataList.getData("currentSeat").GetComponent<SeatsData>();
        return data;
    }

    private bool setupPickMenu(){
        foreach(GameObject costumer in objectsRef){
            costumerParameter.Add(costumer.GetComponent<CostumerPreferenceParameter>());
        }
        menuParameters = MenuAvailable.Instance.menuItem;
        return true;
    }

    private void getDrink(){
        for(int i = 0; i < costumerParameter.Count;){
            List<MenuScore> menuScore = new List<MenuScore>();
            // Debug.Log("Costumer "+i+" : ");
            int totalScore = 0;
            foreach(MenuParameter menu in menuParameters){
                if(menu.Type == MenuParameter.MenuType.Brew) {
                    int currentScore = getUtilNumber(costumerParameter[i],menu);
                    totalScore += currentScore;
                    menuScore.Add(new MenuScore{score = currentScore, menu = menu});
                }
            }
            // Debug.Log("Getted Menu"+getMenu(menuScore,totalScore).name);
            pickedMenu.Add(getMenu(menuScore,totalScore));
            i++;
        }
    }

    private MenuParameter getMenu(List<MenuScore> menuScores, int maxScore){
        int randomNum = UnityEngine.Random.Range(1,maxScore + 1);
        foreach(MenuScore menuScore in menuScores){
            randomNum -= menuScore.score;
            if(randomNum <= 0) return menuScore.menu;
        }
        return null;
    }

    public int getUtilNumber(CostumerPreferenceParameter costumer , MenuParameter menu){
        // Debug.Log("Scoring : ");
        int sweetScore = 100 -  (Mathf.Abs(costumer.Sweet - menu.Sweet) * costumer.SweetTolerance);
        // Debug.Log(Mathf.Abs(costumer.Sweet - menu.Sweet));
        // Debug.Log(costumer.SweetTolerance);
        // Debug.Log("sweet have score of: "+sweetScore);

        int bitterScore = 100 - (Mathf.Abs(costumer.Bitter - menu.Bitter) * costumer.BitterTolerance);
        // Debug.Log(Mathf.Abs(costumer.Bitter - menu.Bitter));
        // Debug.Log(costumer.BitterTolerance);
        // Debug.Log("bitter have score of: "+bitterScore);

        int spendScore = 100 - (int) (Math.Abs(costumer.SpendExcpectation - menu.Price) * costumer.SpendTolerance);
        // Debug.Log(Mathf.Abs(costumer.SpendExcpectation - menu.Price));
        // Debug.Log(costumer.SpendTolerance);
        // Debug.Log("spend have score of: "+spendScore);

        int tempScore = 100 - ((costumer.Temp == BaseMenuParameter.temp.Both)? 50: ((costumer.Temp == menu.Temp)? 0:90));
        // Debug.Log((costumer.Temp == BaseMenuParameter.temp.Both)? 50: ((costumer.Temp == menu.Temp)? 0:90));
        // Debug.Log("temp have score of: "+tempScore);

        sweetScore = Mathf.Clamp(sweetScore,0,100);
        bitterScore = Mathf.Clamp(bitterScore,0,100);
        spendScore = Mathf.Clamp(spendScore,0,100);
        tempScore = Mathf.Clamp(tempScore,0,100);
        int result = (int) ((float)(sweetScore * bitterScore * spendScore * tempScore) / (float)(Mathf.Pow(100,3)));
        result = Mathf.Clamp(result,1,100);
        Debug.Log(menu.Name+" have score of: "+result);
        return result;
    }

    private void setupNotaUI(){
        NotaDataManager.Instance.writeMenu(pickedMenu);
    }

    IEnumerator ActionProcess(){
        yield return null;

        //calling the player
        Debug.Log("Setup Hitbox");
        if(!setupHitBoxHandler()){
            failed();
            yield break;
        }
        data.IsOrdering = true;
        Debug.Log("Waiting input..");
        //wait for the player to respond
        while(data.IsOrdering){
            yield return new WaitForFixedUpdate();
        }
        Debug.Log("Setup Pick Menu");
        //Deciding which menu to pick
        if(!setupPickMenu()){
            failed();
            yield break;
        }
        Debug.Log("getting drink");
        getDrink();
        
        Debug.Log("setupUI");
        setupNotaUI();
        
        finish();
        yield break;
    }
}