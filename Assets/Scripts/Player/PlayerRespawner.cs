using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawner : MonoBehaviour
{
    [SerializeField]
    private PlayerHP playerHP;

    private Transform[] spawnPoints;

    [SerializeField]
    private CoherenceSync sync;

    [SerializeField]
    private CoherenceSync spawnManager;

    public void Awake()
    {
        
    }

    public void SetSpawn(CoherenceSync spawnManager, Transform[] spawnPoints)
    {
        this.spawnPoints = spawnPoints;
        this.spawnManager = spawnManager;
        Respawn();
    }

    public void Respawn()
    {

    }
}
