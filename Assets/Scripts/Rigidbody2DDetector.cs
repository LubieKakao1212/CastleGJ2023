using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Rigidbody2DDetector : MonoBehaviour
{
    public IReadOnlyCollection<Rigidbody2D> DetectedBodies => bodies;

    private HashSet<Rigidbody2D> bodies;
    
    private void Awake()
    {
        var collider = GetComponent<CircleCollider2D>();
        bodies = new HashSet<Rigidbody2D>(
        Physics2D.OverlapCircleAll(collider.offset + (Vector2)transform.position, collider.radius).SelectMany((collider)=>
        {
            var rigid = collider.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                return Enumerable.Repeat(rigid, 1);
            }
            return Enumerable.Empty<Rigidbody2D>();
        }
        ));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rigid = collision.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            bodies.Add(rigid);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var rigid = collision.GetComponent<Rigidbody2D>();
        if (rigid != null)
        {
            bodies.Remove(rigid);
        }
    }
}
