using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int numberOfLayers = 0;
    public int successRate = 0;

    public Progression progression;
    public Panel panel;
    
    public List<MeshRenderer> sphereRenderers;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void IncrementNumberOfLayers()
    {
        numberOfLayers++;
        progression.UpdateValues(numberOfLayers);
        panel.UpdateValues(numberOfLayers);
    }
    
    public int GetIncome()
    {
        return successRate * 2;
    }
    
    public void CreateNewLayer(Material dropMaterial)
    {
        var newLayerRenderer = sphereRenderers[numberOfLayers];
        newLayerRenderer.enabled = true;
        if (newLayerRenderer.material.color == dropMaterial.color) { successRate += 2; }
        newLayerRenderer.material = dropMaterial;
        IncrementNumberOfLayers();
    }
}