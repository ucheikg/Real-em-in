using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using Dan.Models;

public class GameSettings : MonoBehaviour
{

    private void Start()
    {
        UpdateLeaderboard();
    }


    #region Leaderboard

    [SerializeField] private List<TextMeshProUGUI> names;
    [SerializeField] private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey =
        "a94df36f87cbc1abbda1642d9a3f48b943bdb7cba8ae7a7786cac83984dfed02";

    


    
    public void UpdateLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) => {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i = 0; i < loopLength; i++)
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
