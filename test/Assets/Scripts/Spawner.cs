using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] items;
    public float spawnInterval = 1.5f;
    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        InvokeRepeating("SpawnObject", 1f, spawnInterval);
    }

    void SpawnObject()
    {
        int index = Random.Range(0, items.Length);
        Vector3 spawnPos = new Vector3(10f, Random.Range(minY, maxY), 0f);
        Instantiate(items[index], spawnPos, Quaternion.identity);
    }
}
