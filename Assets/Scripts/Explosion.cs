using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2DDetector detector;
    
    [SerializeField]
    private float directionalStrength;

    [SerializeField]
    private float radialStrength;

    [SerializeField]
    private GameObject acid;

    [HideInInspector]
    public Vector2 direction;

    public void Init(Vector2 direction)
    {
        this.direction = direction.normalized;
    }

    private void FixedUpdate()
    {
        foreach (var body in detector.DetectedBodies)
        {
            body.AddForce(direction * directionalStrength, ForceMode2D.Force);
            body.AddForce((body.transform.position - transform.position) * radialStrength, ForceMode2D.Force);
        }
    }

    private void OnDestroy()
    {
        Instantiate(acid, transform.position, Quaternion.identity);
    }
}
