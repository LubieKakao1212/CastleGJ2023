using Coherence.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class PlayerHP : MonoBehaviour
{
    [Sync]
    public int SyncHP
    {
        get => hp;
        set
        {
            hp = value;
            HpChanged?.Invoke();
        }
    }

    [Sync]
    public int SyncMaxHP
    {
        get => maxHP;
        set => maxHP = value;
    }

    public event Action HpChanged;

    public event Action OnDeath;

    public uint? LastExplosionOwnerId { get; private set; }

    public float Ratio => hp / (float)maxHP;

    [SerializeField]
    private int hp;

    [SerializeField]
    private float regenCooldown;

    [SerializeField]
    private int regenAmount;

    [SerializeField]
    private float explosionMemoryTime;

    [SerializeField]
    private float proximityRadius;

    [SerializeField]
    private LayerMask otherPlayers;

    [SerializeField]
    private PlayerInfo playerInfo;

    private AutoTimeMachine explosionMemoryCleanupTimer;

    private AutoTimeMachine regenTimer;

    private int maxHP;

    private int debugLastExplosionOwnerId;

    private void Start()
    {
        this.maxHP = hp;
        explosionMemoryCleanupTimer = new AutoTimeMachine(() =>
        {
            LastExplosionOwnerId = null;
        }, explosionMemoryTime);
        regenTimer = new AutoTimeMachine(() =>
        {
            hp += regenAmount;

            hp = Mathf.Min(hp, maxHP);

            HpChanged?.Invoke();
        }, regenCooldown);
    }

    private void FixedUpdate()
    {
        if (enabled)
        {
            regenTimer.Forward(Time.fixedDeltaTime);
            explosionMemoryCleanupTimer.Forward(Time.fixedDeltaTime);
        }

        debugLastExplosionOwnerId = LastExplosionOwnerId == null ? -1 : (int)LastExplosionOwnerId.Value;
    }

    public void DealDamage(int damage, uint? explosionOwnerId)
    {
        hp -= damage;

        HpChanged?.Invoke();

        //resetTimer
        regenTimer.Delay(regenCooldown);

        if (hp <= 0)
        {
            Die(explosionOwnerId, LastExplosionOwnerId);
        }
    }

    public void RememberExplosion(uint explosionOwnerId)
    {
        LastExplosionOwnerId = explosionOwnerId;
        explosionMemoryCleanupTimer.Delay(explosionMemoryTime);
    }

    private void Die(uint? currentExplosion, uint? lastExplosion)
    {
        var p = transform.position;

        var nearbyPlayers = new List<Collider2D>(Physics2D.OverlapCircleAll(p, proximityRadius, otherPlayers.value));

        nearbyPlayers.Sort((a, b) => (int)Mathf.Sign((a.transform.position - p).magnitude - (b.transform.position - p).magnitude));

        var nearbyPlayerNames = nearbyPlayers.Select((c) => c.GetComponent<PlayerInfo>().PlayerId).ToArray();

        var message = KillMessageGenerator.GetEncodedMessage(playerInfo.PlayerId, currentExplosion, lastExplosion, nearbyPlayerNames);

        //Debug.Log(message);
        MessageBoard.AddDeathMessage(message);

        OnDeath?.Invoke();
    }
}
