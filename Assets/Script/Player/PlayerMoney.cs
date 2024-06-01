using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    private static int money;

    public static event Action OnMoneyChange;

    public static int Money{
        get{
            return money;
        }
        set{
            money = value;
            OnMoneyChange?.Invoke();
        }
    }
}
