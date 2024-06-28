using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerServeCostumer : PlayerNpcAction
{
    private TrayedMenu trayedMenu;

    private List<MenuParameter> createdMenus;
    
    private List<MenuParameter> orderedMenus;

    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    private void serveCostumer(){
        createdMenus = trayedMenu.createdMenus;
        orderedMenus = trayedMenu.notaData.menu;

        // Debug.Log(trayedMenu.notaData.menu);
        
        // foreach(MenuParameter createdMenu in createdMenus){
        //     Debug.Log("Created Menu : "+createdMenu.name);
        // }

        // foreach(MenuParameter orderedMenu in orderedMenus){
        //     Debug.Log("Ordered Menu : "+orderedMenu.name);
        // }
        
        // if(checkServedMenu(createdMenus,orderedMenus)){
        //     //Correct order
        //     // Debug.Log("Correct Order!");
            
        // }else{
        //     //false order
        //     // Debug.Log("Wrong Order!");
        // }

        foreach(MenuParameter orderedMenu in orderedMenus){
            // Debug.Log("created menu: "+createdMenu.name);
            MenuParameter createdMenu = createdMenus.Find(component => component.name == orderedMenu.name);
            if(createdMenu){
                createdMenus.Remove(createdMenu);
                PlayerMoney.Money += orderedMenu.Price;
                ReputationSystem.Instance.CurrentReputation += 1;
            }else{
                ReputationSystem.Instance.CurrentReputation -= 5;
            }
        }
        CostumerGroupManager costumerGroup = trayedMenu.notaData.seatsData.getOccupiedBy();
        costumerGroup.AiHandler.GetComponent<ActionsDataList>().setData("Served",true);

    }

    // private bool checkServedMenu(List<MenuParameter> createdMenus, List<MenuParameter> orderedMenus){
        
    //     return orderedMenus.Count <= 0;
    // }

    IEnumerator ActionProcess(){
        yield return null;
        trayedMenu = (TrayedMenu) actionsDataList.getData("Trayed Menu");

        if(trayedMenu == null){
            failed();
            yield break;
        }
        
        yield return new WaitForSeconds(2);
        if(trayedMenu.notaData.menu == null){
            failed();
            yield break;
        }
        serveCostumer();



        finish();
        yield break;
    }
}
