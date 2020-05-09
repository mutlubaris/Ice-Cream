using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    IceCreamDispenser iceCreamDispenserScript;
    ParticleSystem levelCompleteVFX;

    void Start()
    {
        iceCreamDispenserScript = GameObject.Find("Ice Cream Dispenser").GetComponent<IceCreamDispenser>();
        levelCompleteVFX = GetComponent<ParticleSystem>();
    }

    public void EmitVFX()
    {
        levelCompleteVFX.Emit(10);
    }
}
