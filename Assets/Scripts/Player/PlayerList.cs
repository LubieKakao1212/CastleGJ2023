using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    public static PlayerList Instance { get; private set; }

    /// <summary>
    /// Public for coherence only, do NOT touch
    /// </summary>
    [HideInInspector]
    public uint nextId;

    [SerializeField]
    private InputField namePrompt;

    [SerializeField]
    private CoherenceSync sync;

    private PlayerInfo localPlayer;
    private Dictionary<uint, string> PlayerNames;
    private Dictionary<string, uint> PlayerIds;

    private void Awake()
    {
        Assert.IsNull(Instance, "Duplicate PlayerList");
        Instance = this;

        PlayerNames = new Dictionary<uint, string>();
        PlayerIds= new Dictionary<string, uint>();
    }

    public void SetupLocalPlayerInfo(PlayerInfo info)
    {
        info.PlayerName = namePrompt.text;
        localPlayer = info;
        sync.SendCommand<PlayerList>(nameof(AssignPlayerIdAndName), Coherence.MessageTarget.AuthorityOnly, info.sync, info.PlayerName);
    }

    public void AssignPlayerIdAndName(CoherenceSync targetPlayerSync, string playerName)
    {
        sync.SendCommand<PlayerList>(nameof(BindPlayerIdAndName), Coherence.MessageTarget.All, targetPlayerSync, playerName, nextId++);
    }

    public void BindPlayerIdAndName(CoherenceSync targetPlayerSync, string playerName, uint id)
    {
        PlayerNames.Add(id, playerName);
        PlayerIds.Add(playerName, id);
        if (localPlayer.sync == targetPlayerSync)
        {
            localPlayer.PlayerId = id;
        }
    }

    public static string GetPlayerName(uint id)
    {
        return Instance.PlayerNames[id];
    }

    /*public static uint GetPlayerId(string name)
    {
        return Instance.PlayerIds[name];
    }*/
}
