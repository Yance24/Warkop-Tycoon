using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoToSeats : PlayerGoTo
{
    protected override void setupTarget()
    {
        base.setupTarget();
        TrayedMenu data = (TrayedMenu) actionsDataList.getData("Trayed Menu");
        if(data != null) target = data.notaData.seatsData.transform;
    }
}