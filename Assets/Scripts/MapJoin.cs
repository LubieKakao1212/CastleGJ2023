using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapJoin : MonoBehaviour
{
    [SerializeField]
    private Transform[] targetPoints;

    private BucketRandom<int> random;

    [SerializeField]
    private CoherenceSync sync;

    private void Awake()
    {
        random = new BucketRandom<int>(Enumerable.Range(0, targetPoints.Length).ToArray());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerRespawner>();
        JoinMap(player);
    }

    public void JoinMap(PlayerRespawner player)
    {
        if (player != null)
        {
            player.SetSpawn(sync, this);
        }
    }

    public void RequestSpawnpoint(CoherenceSync player)
    {
        player.SendCommand<PlayerRespawner>(nameof(PlayerRespawner.RespawnInternal), Coherence.MessageTarget.AuthorityOnly, random.GetRandom());
    }

    public Transform GetSpawnpoint(int id)
    {
        return targetPoints[id];
    }
}
