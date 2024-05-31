using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTrayCupToTrash : DragUIHandler
{
    private TrayCupHandler handler;
    protected override void setupDrag()
    {
        base.setupDrag();
        handler = GetComponent<TrayCupHandler>();
    }

    protected override void execute()
    {
        base.execute();
        MenuMakerManager.Instance.CraftedMenu.RemoveAt(handler.index);
        TrayUIManager.Instance.refreshUI();
    }
}
