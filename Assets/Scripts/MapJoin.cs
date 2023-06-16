using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapJoin : MonoBehaviour
{
    [SerializeField]
    private BucketRandom<Transform> targetPoints;
    
    [SerializeField]
    private Transform[] targetPoints2;

    private BucketRandom<int> random;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rigid = collision.GetComponent<Rigidbody2D>();
        JoinMap(rigid);
    }

    public void JoinMap(Rigidbody2D rigid)
    {
        if (rigid != null)
        {
            var point = targetPoints.GetRandom();

            rigid.MovePosition(point.position);

            var shooter = rigid.GetComponentInChildren<ShootingController>();

            shooter.enabled = true;
        }
    }

}
