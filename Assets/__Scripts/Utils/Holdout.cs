using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdout : Objective
{

    [SerializeField] private float duration = 60f;

    [SerializeField] private GameObject enemyPrefab;

    private float count;
    [SerializeField] private float spawnDistance = 5f;
    [SerializeField] private int spawnRate = 3;

    public override string Name { get { return $"Holdout Time Remaining: {count:0.0}"; } }

    private bool counting;
    private bool canSpawn;

    // Start is called before the first frame update
    void Start()
    {
        count = duration;
        counting = false;
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        count -= counting ? Time.deltaTime : 0;

        if (count < 0)
            Complete();
        else if (counting && canSpawn)
            Spawn();
    }

    void Spawn()
    {
        canSpawn = false;
        for (int i = 0; i < spawnRate; i++)
        {
            Vector3 spawnLocation = V2toV3(Random.insideUnitCircle.normalized * spawnDistance) + transform.position;
            Instantiate(enemyPrefab, spawnLocation, Quaternion.identity);
        }
        Invoke("CanSpawn", Random.value * 2 + 1);
    }

    private void OnTriggerEnter2D(Collider2D collision) => counting = collision.gameObject.tag == "Player" ? true : counting;

    private void OnTriggerExit2D(Collider2D collision) => counting = collision.gameObject.tag == "Player" ? false : counting;

    private void CanSpawn() => canSpawn = true;

    private static Vector3 V2toV3(Vector2 v)
    {
        return new Vector3(v.x, v.y);
    }
}
