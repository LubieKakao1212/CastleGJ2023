using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerList : MonoBehaviour
{
    public static IEnumerable<PlayerInfo> Players
    { 
        get
        {
            var toRemove = new List<uint>();
            foreach (var pair in Instance.PlayersById)
            {
                if (pair.Value == null)
                {
                    toRemove.Add(pair.Key);
                    continue;
                }

                yield return pair.Value;    
            }

            foreach (var id in toRemove)
            {
                Instance.PlayersById.Remove(id);
            }
        }
    }


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
    private Dictionary<uint, PlayerInfo> PlayersById;

    private void Awake()
    {
        Assert.IsNull(Instance, "Duplicate PlayerList");
        Instance = this;

        PlayerNames = new Dictionary<uint, string>();
        //PlayerIds= new Dictionary<string, uint>();
        PlayersById = new Dictionary<uint, PlayerInfo>();
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
        PlayersById.Add(id, targetPlayerSync.GetComponent<PlayerInfo>());
        if (localPlayer.sync == targetPlayerSync)
        {
            localPlayer.PlayerId = id;
        }
    }

    public static string GetPlayerName(uint id)
    {
        return Instance.PlayerNames[id];
    }

    public static PlayerInfo GetPlayerInfo(uint id)
    {
        return Instance.PlayersById[id];
    }
}
