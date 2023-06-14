using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapJoin : MonoBehaviour
{
    [SerializeField]
    private BucketRandom<Transform> targetPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rigid = collision.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            var point = targetPoints.GetRandom();

            rigid.MovePosition(point.position);

            var shooter = rigid.GetComponentInChildren<ShootingController>();

            shooter.enabled = true;
        }
    }

}
