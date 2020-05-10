using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public MeshRenderer dropRenderer;
    public void OnTriggerEnter(Collider other)
    {
        Material dropMaterial = dropRenderer.material;
        GameController.instance.CreateNewLayer(dropMaterial);
        Destroy(gameObject);
    }
}