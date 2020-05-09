using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Material dropMaterial = this.gameObject.GetComponent<MeshRenderer>().material;
        FindObjectOfType<IceCreamDispenser>().CreateNewLayer(dropMaterial);
        Destroy(gameObject);
    }
}
