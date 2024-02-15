using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1.5f;
    public float top = 5.5f;
    public float bottom = -0.5f;

    private void Start()
    {
        InvokeRepeating("SpawnPrefab", 2f, spawnRate);
    }


    void SpawnPrefab()
    {
        Vector3 position = Vector3.right * 20;
        position.y = Random.Range(top, bottom);
        Instantiate(pipePrefab, position, Quaternion.identity);
    }
}
