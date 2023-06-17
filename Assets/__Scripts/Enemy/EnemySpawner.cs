using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    private bool canSpawn;

    private GameObject player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDistance = 5f;

    [SerializeField] private bool apocalyse = false;

    void Start()
    {
        canSpawn = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float grace = apocalyse ? 0f : 5f;
        if (canSpawn && Time.timeSinceLevelLoad > grace)
            Spawn();
    }

    void Spawn()
    {
        canSpawn=false;
        float spawnRate = Time.timeSinceLevelLoad;
        spawnRate /= apocalyse ? 3 : 30;
        for (int i = 0; i < spawnRate; i++)
        {
            Vector3 spawnLocation = (Random.onUnitSphere * spawnDistance) + player.transform.position;
            spawnLocation.z = 0;
            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
        Invoke("CanSpawn", Random.value*2+1);
    }

    private void CanSpawn()
    {
        canSpawn = true;
    }
}
