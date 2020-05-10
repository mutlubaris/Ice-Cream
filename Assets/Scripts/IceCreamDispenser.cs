using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDispenser : MonoBehaviour
{
    public Transform tap1Transform;
    public Transform tap2Transform;
    public Transform noseTransform;
    
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private float secondsBetweenDrops = 1f;
    [SerializeField] private float yDif = 0.1f;

    public int numberOfDrops = 0;

    public Animator animator;
    public Material lemon;
    public Material chocolate;

    private Material _activeDropMaterial = null; 
    private Coroutine _activeDropCoroutine;

    private Dictionary<string, Material> _keyToMaterialDict;
    private Dictionary<string, Transform> _keyToTapDict;
    
    private const int MAX_NUMBER_OF_DROPS = 48;

    void Start()
    {
        _keyToMaterialDict = new Dictionary<string, Material>
        {
            {"1", lemon},
            {"2", chocolate}
        };
        
        _keyToTapDict = new Dictionary<string, Transform>
        {
            {"1", tap1Transform},
            {"2", tap2Transform}
        };
    }

    void Update()
    {
        foreach (var key in _keyToMaterialDict.Keys)
        {
            if (Input.GetKeyDown(key) && _activeDropMaterial == null)
            {
                animator.Play("Dispense");
                _keyToTapDict[key].Rotate(-45, 0, 0);
                _activeDropCoroutine = StartCoroutine(SpawnDrops(_keyToMaterialDict[key]));
                animator.speed = 1f;
                _activeDropMaterial = _keyToMaterialDict[key];
            }

            if (Input.GetKeyUp(key) && _activeDropMaterial == _keyToMaterialDict[key])
            {
                _keyToTapDict[key].Rotate(45, 0, 0);
                animator.speed = 0f;
                _activeDropMaterial = null;
                if (_activeDropCoroutine != null)
                {
                    StopCoroutine(_activeDropCoroutine);
                    _activeDropCoroutine = null;
                }
            }
        }
    }

    IEnumerator SpawnDrops(Material dropMaterial)
    {
        while (numberOfDrops <= MAX_NUMBER_OF_DROPS)
        {
            var nosePosition = noseTransform.position;
            Vector3 spawnPosition = nosePosition - new Vector3(0, yDif, 0);
            GameObject drop = Instantiate(dropPrefab, spawnPosition, transform.rotation);
            drop.GetComponent<MeshRenderer>().material = dropMaterial;
            numberOfDrops++;
            yield return new WaitForSeconds(secondsBetweenDrops);
        }
    }
}
