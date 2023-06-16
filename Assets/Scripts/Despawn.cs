using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    [SerializeField]
    private float lifetime;

    private void FixedUpdate()
    {
        if(enabled && (lifetime -= Time.fixedDeltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
