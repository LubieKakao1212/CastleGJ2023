using Coherence.Toolkit;
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

    [HideInInspector]
    public uint ownerId;

    [SerializeField]
    private int damage;

    public void Init(Vector2 direction, PlayerInfo owner)
    {
        this.direction = direction.normalized;
        this.ownerId = owner.PlayerId;
    }

    private void FixedUpdate()
    {
        foreach (var body in detector.DetectedBodies)
        {
            body.AddForce(direction * directionalStrength, ForceMode2D.Force);
            body.AddForce((body.transform.position - transform.position) * radialStrength, ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerInfo>();
        if (player == null || collision.GetComponent<CoherenceSync>().AuthorityType == Coherence.AuthorityType.None)
        {
            return;
        }
        var playerHp = collision.GetComponent<PlayerHP>();
        if (player.PlayerId != ownerId)
        {
            //Should not cause errors unless owner is not player, which should not happen
            playerHp.DealDamage(damage, ownerId);
            playerHp.RememberExplosion(ownerId);
        }
        else
        {
            playerHp.RememberExplosion(ownerId);
        }
    }

    private void OnDestroy()
    {
        Instantiate(acid, transform.position, Quaternion.identity);
    }
}
