using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTrail : MonoBehaviour
{
    public Vector3 EndPosSync 
    {
        get => endPos;
        set
        {
            endPos = value;
            line.SetPosition(1, endPos);
        }
    }

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    private float lifespan;

    [ColorUsage(false, true)]
    [SerializeField]
    private Color color;

    [SerializeField]
    private float decayFactor;

    private float age;
    
    private Vector3 endPos;

    void Start()
    {
        line.endColor = new Color(color.r, color.g, color.b, 0f);
        line.SetPosition(0, transform.position);
    }

    private void Update()
    {
        age += Time.deltaTime;
        float a = Mathf.Pow((age / lifespan), decayFactor);
        line.startColor = color * new Color(1f, 1f, 1f, 1f - a);
    }
}
