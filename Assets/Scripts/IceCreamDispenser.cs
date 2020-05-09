using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamDispenser : MonoBehaviour
{
    GameObject tap1;
    GameObject tap2;

    [SerializeField] GameObject dropPrefab;
    [SerializeField] float secondsBetweenDrops = 1f;
    [SerializeField] float yDif = 0.1f;

    public int numberOfLayers = 0;
    public int numberOfDrops = 0;
    public int successRate = 0;
    public int income = 0;

    public Animator animator;
    public Material lemon;
    public Material chocolate;

    void Start()
    {
        animator = GetComponent<Animator>();
        tap1 = gameObject.transform.GetChild(2).gameObject;
        tap2 = gameObject.transform.GetChild(3).gameObject;
    }

    void Update()
    {
        
        if (Input.GetKeyDown("1"))
        {
            animator.Play("Dispense");
            tap1.transform.Rotate(-45, 0, 0);
            StartCoroutine(SpawnLemonDrops());
            animator.speed = 1f;
        }

        if (Input.GetKeyUp("1"))
        {
            tap1.transform.Rotate(45, 0, 0);
            animator.speed = 0f;
            StopAllCoroutines();
        }

        if (Input.GetKeyDown("2"))
        {
            animator.Play("Dispense");
            tap2.transform.Rotate(-45, 0, 0);
            StartCoroutine(SpawnChocolateDrops());
            animator.speed = 1f;
        }

        if (Input.GetKeyUp("2"))
        {
            tap2.transform.Rotate(45, 0, 0);
            animator.speed = 0f;
            StopAllCoroutines();
        }
        income = successRate * 2;
    }

    IEnumerator SpawnLemonDrops()
    {
        while (true && numberOfDrops <= 48)
        {
            GameObject nose = gameObject.transform.GetChild(1).gameObject;
            Vector3 nosePosition = nose.transform.position;
            Vector3 spawnPosition = new Vector3(nose.transform.position.x, nose.transform.position.y - yDif, nose.transform.position.z);
            GameObject drop = Instantiate(dropPrefab, spawnPosition, transform.rotation);
            drop.GetComponent<MeshRenderer>().material = lemon;
            numberOfDrops++;
            yield return new WaitForSeconds(secondsBetweenDrops);
        }
    }

    IEnumerator SpawnChocolateDrops()
    {
        while (true && numberOfDrops <=48)
        {
            GameObject nose = gameObject.transform.GetChild(1).gameObject;
            Vector3 nosePosition = nose.transform.position;
            Vector3 spawnPosition = new Vector3(nose.transform.position.x, nose.transform.position.y - yDif, nose.transform.position.z);
            GameObject drop = Instantiate(dropPrefab, spawnPosition, transform.rotation);
            drop.GetComponent<MeshRenderer>().material = chocolate;
            numberOfDrops++;
            yield return new WaitForSeconds(secondsBetweenDrops);
        }
    }

    public void CreateNewLayer(Material dropMaterial)
    {
        GameObject newLayer = GameObject.Find("Ice Cream Cone").transform.GetChild(numberOfLayers).gameObject;
        newLayer.GetComponent<MeshRenderer>().enabled = true;
        if (newLayer.GetComponent<MeshRenderer>().material.color == dropMaterial.color) { successRate += 2; }
        newLayer.GetComponent<MeshRenderer>().material = dropMaterial;
        numberOfLayers++;
    }
}
