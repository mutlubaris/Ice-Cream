using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalIncome : MonoBehaviour
{
    IceCreamDispenser iceCreamDispenserScript;
    Text totalIncomeText;
    static int totalIncome;

    private void Start()
    {
        iceCreamDispenserScript = GameObject.Find("Ice Cream Dispenser").GetComponent<IceCreamDispenser>();
        totalIncomeText = GetComponent<Text>();
        totalIncomeText.text = ("$" + totalIncome.ToString());
    }

    public void AddToBank()
    {
        totalIncome += iceCreamDispenserScript.income;
        print("Total Income So Far Is: " + totalIncome);
    }
}
