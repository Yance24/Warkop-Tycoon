using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpenMenuUI : PlayerNpcAction
{
    public override void execute()
    {
        base.execute();
        MenuMakerManager.Instance.createMenu();
        finish();
    }
}
