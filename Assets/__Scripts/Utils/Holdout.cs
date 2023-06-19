using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdout : Objective
{

    [SerializeField] private float duration = 60f;

    private float count;

    public override string Name { get { return $"Holdout Time Remaining: {count:0.0}"; } }

    // Start is called before the first frame update
    void Start()
    {
        count = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 0)
            Complete();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count -= Time.deltaTime;
        }
        Debug.Log(count);
    }
}
