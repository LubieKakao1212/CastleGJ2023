using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, Wall
{
    [SerializeField]
    private Collider2D collider2d;

    [SerializeField]
    private GameObject visuals;

    [SerializeField]
    private float cooldown;

    public void Hit(RaycastHit2D hit, ShootingController shooter)
    {
        collider2d.enabled = false;
        visuals.SetActive(false);

        StartCoroutine(RestoreWall());
    }

    private IEnumerator RestoreWall()
    {
        yield return new WaitForSeconds(cooldown);
        collider2d.enabled = true;
        visuals.SetActive(true);
    }
}
