using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class InputBuffer
{
    public string inputType;
    public Transform data;

    public InputBuffer(string name, Transform data){
        this.inputType = name;
        this.data = data;
    }
}
