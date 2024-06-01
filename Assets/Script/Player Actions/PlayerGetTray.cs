using System.Collections;
using UnityEngine;

public class PlayerGetTray : PlayerNpcAction
{
    public override void execute()
    {
        base.execute();
        StartCoroutine(ActionProcess());
    }

    IEnumerator ActionProcess(){
        yield return null;
        
        TrayedMenu trayedMenu = TrayManager.Instance.pullTray();
        if(trayedMenu != null){
            yield return new WaitForSeconds(2);
            // Debug.Log("tray saved to data list");
            actionsDataList.setData("Trayed Menu",trayedMenu);
            finish();
        }else{
            // Debug.Log("there is no tray");
            failed();
        }
    }
}
