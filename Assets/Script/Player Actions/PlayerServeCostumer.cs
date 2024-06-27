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
        
        if(checkServedMenu(createdMenus,orderedMenus)){
            //Correct order
            // Debug.Log("Correct Order!");
            
        }else{
            //false order
            // Debug.Log("Wrong Order!");
        }
    }

    private bool checkServedMenu(List<MenuParameter> createdMenus, List<MenuParameter> orderedMenus){
        foreach(MenuParameter createdMenu in createdMenus){
            // Debug.Log("created menu: "+createdMenu.name);
            MenuParameter orderedMenu = orderedMenus.Find(component => component.name == createdMenu.name);
            if(orderedMenu){
                orderedMenus.Remove(createdMenu);
                PlayerMoney.Money += orderedMenu.Price;
            }
        }
        CostumerGroupManager costumerGroup = trayedMenu.notaData.seatsData.getOccupiedBy();
        costumerGroup.AiHandler.GetComponent<ActionsDataList>().setData("Served",true);
        return orderedMenus.Count <= 0;
    }

    IEnumerator ActionProcess(){
        yield return null;
        trayedMenu = (TrayedMenu) actionsDataList.getData("Trayed Menu");

        if(trayedMenu == null){
            failed();
            yield break;
        }
        yield return new WaitForSeconds(2);
        if(orderedMenus == null){
            failed();
            yield break;
        }
        serveCostumer();


        finish();
        yield break;
    }
}
