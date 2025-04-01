using Dan.Main;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    private GameSettings gameSettings;
    private void Start()
    {
        gameSettings = GameObject.Find("[GameSettings]").GetComponent<GameSettings>();
        string name = gameSettings.GetPlayerName();
        if (name != "")
        {
            int score = gameSettings.GetPlayerCurrentScore();
            SetLeaderboardEntry(name, score);
        }
        
        UpdateLeaderboard();
    }

    #region Leaderboard

    [Header("Leaderboard")]
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "4b700994758b3fff08b281e618b7d5fb2692440741b690d1805d86bbde879684";

    public void UpdateLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; i++)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderboardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username,
            score, ((msg) => {
                UpdateLeaderboard();
            }));
    }

    #endregion
}
