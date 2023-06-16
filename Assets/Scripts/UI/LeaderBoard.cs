using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private LeaderBoardEntry entryPrefab;

    private void Awake()
    {
        InputManager.ToggleLeaderBoard += () =>
        {
            gameObject.SetActive(!gameObject.activeSelf);
            if (gameObject.activeSelf)
            {
                UpdateBoard();
            }
        };

        gameObject.SetActive(false);
    }

    public void UpdateBoard()
    {
        for (int i = transform.childCount - 1; i >= 0; i--) 
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        var players = new List<(float KD, int killCount, int deathCount, string name)>();

        foreach (var player in PlayerList.Players)
        {
            float kd = (float)player.KillCount / (float)player.DeathCount;
            players.Add((kd, player.KillCount, player.DeathCount, player.PlayerName));
        }

        players.Sort((a, b) => a.name.CompareTo(b.name));

        foreach (var p in players)
        {
            Instantiate(entryPrefab, transform).Setup(p.name, p.killCount, p.deathCount);
        }
    }
}
