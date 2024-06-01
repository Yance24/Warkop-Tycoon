using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoToSeats : PlayerGoTo
{
    protected override void setupTarget()
    {
        base.setupTarget();
        TrayedMenuWrap data = actionsDataList.getData("trayed menu").GetComponent<TrayedMenuWrap>();
        if(data) target = data.tray.notaData.seatsData.transform;
    }
}