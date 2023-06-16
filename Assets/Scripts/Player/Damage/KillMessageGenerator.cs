using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class KillMessageGenerator
{
    private const string targetColorCode = "#FF1111";
    private const string sourceColorCode = "#555555";

    private static MessageSet explosion = new MessageSet()
    {
        Id = 0,
        killMessages = new string[]
        {
            "{0} was <color=orange>exploded</color> away by {1}"
        },
        selfKillMessages = new string[]
        {
            "{0} exploded themselves (YOU SUICIDAL CHEATER)"
        }
    };
    private static MessageSet acidRun = new MessageSet()
    {
        Id = 1,
        killMessages = new string[]
        {
            "{0} run into <color=green>dirty stuff</color> escaping {1}"
        },
        selfKillMessages = new string[]
        {
            "{0} <color=green>melted</color> alone",
            "{0} got themselfs <color=green>dirty</color>",
        }
    };
    private static MessageSet acidFling= new MessageSet()
    {
        Id = 2,
        killMessages = new string[]
        {
            "{0} was flung into <color=green>dirty stuff</color> by {1}",
            "{0} trajectory was changed by {1}, but there was <color=green>acid</color> in the way"
        },
        selfKillMessages = new string[]
        {
            "{0} jumped into <color=green>dirty stuff</color>",
        }
    };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="targeName"></param>
    /// <param name="lastExplosion"></param>
    /// <param name="nearbyPlayers">Sorted by distance (closest first)</param>
    /// <returns></returns>
    public static string GetDeathMessage(string targetName, string currentExplosion, string lastExplosion, string[] nearbyPlayers)
    {
        targetName = targetName.Color(targetColorCode);
        if (currentExplosion != null)
        {
            return GetDeathMessage(targetName, currentExplosion.Color(sourceColorCode), explosion);
        }
        if (lastExplosion != null)
        {
            return GetDeathMessage(targetName, lastExplosion.Color(sourceColorCode), acidFling);
        }
        if (nearbyPlayers.Length > 0)
        {
            return GetDeathMessage(targetName, nearbyPlayers[0].Color(sourceColorCode), acidRun);
        }

        return GetDeathMessage(targetName, targetName.Color(sourceColorCode), acidRun);
    }

    public static (uint target, uint source, byte messageSet, byte message) GetEncodedMessage(uint targetId, uint? currentExplosion, uint? lastExplosion, uint[] nearbyPlayers)
    {
        uint sourceId;
        MessageSet messageSet;
        if (currentExplosion != null)
        {
            sourceId = currentExplosion.Value;
            messageSet = explosion;
        }
        else if (lastExplosion != null)
        {
            sourceId = lastExplosion.Value;
            messageSet = acidFling;
        }
        else if (nearbyPlayers.Length > 0)
        {
            sourceId = nearbyPlayers[0];
            messageSet = acidRun;
        }
        else
        {
            sourceId = targetId;
            messageSet = acidRun;
        }
        int l;

        if (targetId != sourceId)
        {
            l = messageSet.killMessages.Length;
        }
        else
        {
            l = messageSet.selfKillMessages.Length;
        }

        return (targetId, sourceId, (byte)messageSet.Id, (byte)Random.Range(0, l));
    }

    public static MessageSet GetMessageSetById(byte id) => id switch
    {
        0 => explosion,
        1 => acidRun,
        2 => acidFling,
        _ => null
    };

    public static string DecodeMessage(uint targetId, uint sourceId, byte messageSet, byte message)
    {
        var set = GetMessageSetById(messageSet);
        var messages = targetId == sourceId ? set.selfKillMessages : set.killMessages;
        var target = PlayerList.GetPlayerName(targetId).Color(targetColorCode);
        var source = PlayerList.GetPlayerName(sourceId).Color(sourceColorCode);
        return string.Format(messages[message], target, source);
    }

    private static string GetDeathMessage(string targetName, string sourceName, MessageSet messages)
    {
        if (targetName != sourceName)
        {
            return ChoseMessage(targetName, sourceName, messages.killMessages);
        }
        else
        {
            return ChoseMessage(targetName, sourceName, messages.selfKillMessages);
        }
    }

    private static string ChoseMessage(string target, string source, string[] messages)
    {
        return string.Format(messages[Random.Range(0, messages.Length)], target, source);
    }

    private static string Color(this string message, string colorCode)
    {
        return $"<color={colorCode}>" + message + "</color>";
    }

    public class MessageSet
    {
        public string[] killMessages { get; set; }

        public string[] selfKillMessages { get; set; }

        public int Id { get; set; }
    }
}



