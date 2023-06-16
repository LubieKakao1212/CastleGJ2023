using Coherence.Toolkit;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class MessageBoard : MonoBehaviour
{
    private static MessageBoard instance;

    [SerializeField]
    private TextMeshProUGUI messagePrefab;

    [SerializeField]
    private CoherenceSync sync;

    [SerializeField]
    private Transform BoardRoot;

    public static void AddDeathMessage((uint target, uint source, byte messageSet, byte message) args)
    {
        var (target, source, messageSet, message) = args;

        instance.sync.SendCommand<MessageBoard>(nameof(AddDeathMessageInternal), Coherence.MessageTarget.All, target, source, messageSet, message);

        //instance.AddMessageInternal(text);
    }

    /*public static void AddMessage(string message)
    {
        instance.sync.SendCommand<MessageBoard>(nameof(AddMessageInternal), Coherence.MessageTarget.All, message);
    }*/

    public void AddDeathMessageInternal(uint target, uint source, byte messageSet, byte message)
    {
        AddMessageInternal(KillMessageGenerator.DecodeMessage(target, source, messageSet, message));
    }

    private void AddMessageInternal(string message)
    {
        Instantiate(messagePrefab, BoardRoott).text = message;
    }

    private void Awake()
    {
        Assert.IsNull(instance, "Duplicate MessageBoard");
        instance = this;
    }
}
