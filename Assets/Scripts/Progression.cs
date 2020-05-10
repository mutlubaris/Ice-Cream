using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    public RectTransform[] checks;

    private readonly List<int> _layerLimits = new List<int>
    {
        10,24,38
    };

    public void UpdateValues(int numberOfLayers)
    {
        GetComponent<Slider>().value = numberOfLayers;

        for (var i = 0; i < _layerLimits.Count; i++)
        {
            if (numberOfLayers == _layerLimits[i])
            {
                checks[i].sizeDelta = new Vector2(70, 70);
                checks[i].GetComponent<Image>().color = Color.red;
                break;
            }
        }
    }
}
