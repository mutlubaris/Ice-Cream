using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour
{
    Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.localPosition;
        transform.localPosition = new Vector3(1000, 1000);
    }

    void Update()
    {
        IceCreamDispenser iceCreamDispenserScript = GameObject.Find("Ice Cream Dispenser").GetComponent<IceCreamDispenser>();
        GetComponentInChildren<Slider>().value = iceCreamDispenserScript.successRate;

        Text matchRate = GetComponentInChildren<Text>();
        matchRate.text = ("Match Rate: %" + iceCreamDispenserScript.successRate);

        if (iceCreamDispenserScript.numberOfLayers == 49)
        {
            transform.localPosition = startingPosition;
            FindObjectOfType<LevelCompletion>().EmitVFX();
            FindObjectOfType<Income>().CalculateIncome();
            FindObjectOfType<TotalIncome>().AddToBank();
            iceCreamDispenserScript.numberOfLayers++;
        }
    }

    public void OnMouseButton()
    {
        SceneManager.LoadScene(1);
    }
}
