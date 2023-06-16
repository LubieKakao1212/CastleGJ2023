using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardEntry : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameText;
    [SerializeField]
    private TextMeshProUGUI kdText;

    public void Setup(string playerName, int kills, int deaths)
    {
        nameText.text = playerName;
        var kText = kills.ToString().Color(KillMessageGenerator.sourceColorCode);
        var dText = deaths.ToString().Color(KillMessageGenerator.targetColorCode);
        kdText.text = kText + "/" + dText;
    }
}
