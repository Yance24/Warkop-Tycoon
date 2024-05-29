using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNpcAction : BaseNpcAction
{
    protected Transform data;
    public virtual void setup(GameObject objRef, Transform data){
        objectsRef.Clear();
        objectsRef.Add(objRef);
    }
}
