using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactExplosive : Explosive
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Explode();
    }
}
