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
    private ProjectileTrail trail;

    [SerializeField]
    private Explosion explosion;

    [SerializeField]
    private float castRadius;

    [SerializeField]
    private PlayerInfo playerInfo;

    private void Start()
    {
        enabled = false;
        playerInfo = GetComponent<PlayerInfo>();
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
        var hit = Physics2D.CircleCast(transform.position, castRadius, dir, range, targetLayerMask.value);

        Debug.DrawRay(transform.position, dir, Color.red, 100f);

        Vector3 endPoint;

        if (hit.collider != null)
        {
            Instantiate(explosion, hit.point + ((Vector2)dir) * 0.01f, Quaternion.identity).Init(hit.normal, playerInfo);

            endPoint = hit.point;

            var wall = hit.collider.GetComponent<Wall>();

            if (wall != null && !wall.Equals(null))
            {
                wall.Hit(hit, this);
            }
        }
        else
        {
            endPoint = transform.position + dir * range;
        }

        Instantiate(trail, tip.position, Quaternion.identity).EndPosSync = endPoint;
    }
}
