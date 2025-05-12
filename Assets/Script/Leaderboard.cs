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
            LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
                bool playerInLeaderboard = false;
                for (int i = 0; i < msg.Length; i++)
                {
                    if (msg[i].Username == name)
                    {
                        playerInLeaderboard = true;
                        if (msg[i].Score <= score)
                        {
                            SetLeaderboardEntry(name, score);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (!playerInLeaderboard)
                {
                    SetLeaderboardEntry(name, score);
                }
            }));
            
        }
        
        UpdateLeaderboard();
    }

    #region Leaderboard

    [Header("Leaderboard")]
    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "7e7a25dc24c7ff961384319d163ba1c41c487e334c9eb5849feb6b0d38b115d3";

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
