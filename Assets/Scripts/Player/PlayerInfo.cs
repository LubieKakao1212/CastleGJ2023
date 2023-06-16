using Coherence.Toolkit;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public event Action<string> NameUpdated;

    public string PlayerName 
    {
        get => playerName;
        set
        {
            playerName = value;
            NameUpdated?.Invoke(playerName);
        } 
    }

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
}
