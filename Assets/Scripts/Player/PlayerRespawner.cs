using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawner : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;

    private MapJoin map;

    [SerializeField]
    private Rigidbody2D rigid;

    [SerializeField]
    private ShootingController shooter;

    [SerializeField]
    private CoherenceSync sync;

    private CoherenceSync spawnManager;

    public void Awake()
    {
        playerHP.OnDeath += Respawn;
    }

    public void SetSpawn(CoherenceSync spawnManager, MapJoin map)
    {
        this.map = map;
        this.spawnManager = spawnManager;
        Respawn();
    }

    public void Respawn()
    {
        spawnManager.SendCommand<MapJoin>(nameof(MapJoin.RequestSpawnpoint), Coherence.MessageTarget.AuthorityOnly, sync);
    }

    /// <summary>
    /// Coherence stuff, do NOT touch
    /// </summary>
    public void RespawnInternal(int spawnpoint)
    {
        if (!shooter.enabled)
        {
            shooter.enabled = true;
        }
        rigid.MovePosition(map.GetSpawnpoint(spawnpoint).position);

        playerHP.ResetHP();
    }
}
