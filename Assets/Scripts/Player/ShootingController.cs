using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    [SerializeField]
    private float range = 10f;

    [SerializeField]
    private LayerMask targetLayerMask;

    [SerializeField]
    private Transform tip;

    [SerializeField]
    private Explosion explosion;

    private void Start()
    {
        enabled = false;
    }

    private void OnEnable()
    {
        InputManager.Shoot += Shoot;
    }

    private void OnDisable()
    {
        InputManager.Shoot -= Shoot;
    }

    public void Shoot()
    {
        if (!enabled)
        {
            return;
        }
        var dir = -tip.up;
        var hit = Physics2D.Raycast(transform.position, dir, range, targetLayerMask.value);

        Debug.DrawRay(transform.position, dir, Color.red, 100f);

        if (hit.collider != null)
        {
            Instantiate(explosion, hit.point + ((Vector2)dir) * 0.01f, Quaternion.identity).Init(hit.normal);

            var wall = hit.collider.GetComponent<Wall>();

            if (wall != null && !wall.Equals(null))
            {
                wall.Hit(hit, this);
            }
        }
    }
}
