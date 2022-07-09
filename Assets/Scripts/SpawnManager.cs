using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<GameObject> fruitList;
    [SerializeField] Transform targetTransform;
    GameObject[] fruitArray;

    [Header("Settings")]
    [SerializeField] float startSpawningTime;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] bool stopSpawning;


    void Start()
    {
        fruitArray = fruitList.ToArray();
        Debug.Log("Array Length : " + fruitArray.Length);

        InvokeRepeating("SpawnObject", startSpawningTime, timeBetweenSpawns);
    }

    void Update()
    {
        
    }

    private void SpawnObject()
    {
        if (stopSpawning) CancelInvoke("SpawnObject");

        Vector3 randomPosition = new Vector3(RandomFloat(7f), 1.1f, RandomFloat(3f));
        Quaternion randomRotation = Quaternion.Euler(RandomFloat(180f), RandomFloat(180f), RandomFloat(180f));
        GameObject gO = Instantiate(fruitArray[Random.Range(0, fruitArray.Length)], randomPosition, randomRotation);
        Rigidbody rb = gO.GetComponent<Rigidbody>();
        SetRigidbodyVelocity(rb);
        
    }

    private float RandomFloat(float changeInValue)
    {
        return Random.Range(-changeInValue, changeInValue);
    }

    private void SetRigidbodyVelocity(Rigidbody rb)
    {
        Vector3 direction = targetTransform.position - rb.position;
        rb.velocity = direction;
    }
}
