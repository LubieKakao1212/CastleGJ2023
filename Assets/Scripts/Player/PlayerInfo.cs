using Coherence.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public event Action<string> NameUpdated;

    public event Action scoreChanged;

    public string PlayerName 
    {
        get => playerName;
        set
        {
            playerName = value;
            NameUpdated?.Invoke(playerName);
        } 
    }

    public int KillCountSync 
    { 
        get => KillCount;
        set
        {
            KillCount = value;
            scoreChanged?.Invoke();
        }
    }

    public int DeathCountSync 
    { 
        get => DeathCount;
        set
        {
            DeathCount = value;
            scoreChanged?.Invoke();
        }
    }

    public int KillCount { get; private set; }
    public int DeathCount { get; private set; }

    public uint PlayerId { get; set; }

    public bool isLocal { get; private set; }
    
    [field: SerializeField]
    public CoherenceSync sync { get; private set; }

    [SerializeField]
    private CoherenceMonoBridge bridge;

    private string playerName;

    private void Start()
    {
        bridge.onConnected.AddListener((_) => 
        {
            this.isLocal = sync.AuthorityType == Coherence.AuthorityType.Full;
            if (isLocal)
                PlayerList.Instance.SetupLocalPlayerInfo(this);
        });
    }

    public void AddDeath()
    {
        DeathCount++;
        scoreChanged?.Invoke();
    }

    public void AddKill()
    {
        sync.SendCommand<PlayerInfo>(nameof(AddKillInternal), Coherence.MessageTarget.AuthorityOnly);
    }

    public void AddKillInternal()
    {
        KillCount++;
        scoreChanged?.Invoke();
    }
}
