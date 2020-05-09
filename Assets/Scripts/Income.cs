using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Income : MonoBehaviour
{
    IceCreamDispenser iceCreamDispenserScript;
    Text incomeFinal;

    void Start()
    {
        iceCreamDispenserScript = GameObject.Find("Ice Cream Dispenser").GetComponent<IceCreamDispenser>();
        incomeFinal = GetComponent<Text>();
    }

    public void CalculateIncome()
    {
        incomeFinal.text = ("$" + iceCreamDispenserScript.income.ToString());
    }
}
