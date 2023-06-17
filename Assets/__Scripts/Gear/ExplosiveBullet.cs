using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : ContactExplosive
{

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
