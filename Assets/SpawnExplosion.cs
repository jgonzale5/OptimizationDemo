using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnExplosion : MonoBehaviour
{
    public Transform explosion;

    private void Awake()
    {
        Instantiate(explosion, this.transform.position, Quaternion.identity, this.transform);
    }
}
