using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalIncome : MonoBehaviour
{
    public Text totalIncomeText;
    public static int totalIncome;

    private void Start()
    {
        totalIncomeText.text = "$" + totalIncome;
    }

    public static void AddToBank(int income)
    {
        totalIncome += income;
        print("Total Income So Far Is: " + totalIncome);
    }
}
