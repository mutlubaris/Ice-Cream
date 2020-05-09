using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    IceCreamDispenser iceCreamDispenserScript;
    GameObject check1;
    GameObject check2;
    GameObject check3;
    RectTransform check1Rect;
    RectTransform check2Rect;
    RectTransform check3Rect;

    void Start()
    {
        iceCreamDispenserScript = GameObject.Find("Ice Cream Dispenser").GetComponent<IceCreamDispenser>();
        check1 = GameObject.Find("Canvas/Check 1");
        check2 = GameObject.Find("Canvas/Check 2");
        check3 = GameObject.Find("Canvas/Check 3");
        check1Rect = check1.GetComponent<RectTransform>();
        check2Rect = check2.GetComponent<RectTransform>();
        check3Rect = check3.GetComponent<RectTransform>();
    }

    void Update()
    {
        GetComponent<Slider>().value = iceCreamDispenserScript.numberOfLayers;
        if (iceCreamDispenserScript.numberOfLayers == 10)
        {
            check1Rect.sizeDelta = new Vector2(70, 70);
            check1.GetComponent<Image>().color = Color.red;
        }

        if (iceCreamDispenserScript.numberOfLayers == 24)
        {
            check2Rect.sizeDelta = new Vector2(70, 70);
            check2.GetComponent<Image>().color = Color.red;
        }

        if (iceCreamDispenserScript.numberOfLayers == 38)
        {
            check3Rect.sizeDelta = new Vector2(70, 70);
            check3.GetComponent<Image>().color = Color.red;
        }
    }
}
