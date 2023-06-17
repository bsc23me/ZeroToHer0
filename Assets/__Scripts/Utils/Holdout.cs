using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdout : MonoBehaviour
{

    [SerializeField] private float duration = 60f;

    private float count;

    // Start is called before the first frame update
    void Start()
    {
        count = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (count < 0)
            GameManager.Instance.Win();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            count -= Time.deltaTime;
        }
    }
}
