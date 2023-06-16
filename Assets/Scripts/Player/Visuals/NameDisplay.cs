using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameDisplay : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo player;

    [SerializeField]
    private TextMeshPro display;

    private void Start()
    {
        player.NameUpdated += (name) => display.text = name;
    }
}
