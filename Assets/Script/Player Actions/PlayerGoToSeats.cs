using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoToSeats : PlayerGoTo
{
    protected override void setupTarget()
    {
        base.setupTarget();
        TrayedMenuWrap data = actionsDataList.getData("Trayed Menu").GetComponent<TrayedMenuWrap>();
        if(data) target = data.tray.notaData.seatsData.transform;
    }
}