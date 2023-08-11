using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LootLockerLeaderBoard : MonoBehaviour
{
    public TMP_Text loginInformationText;
    public TMP_Text playerIdText;
    public TMP_Text leaderboardCenteredText;

    /*
    * leaderboardKey or leaderboardID can be used.
    * leaderboardKey can be the same between stage and live /development mode on/off.
    * So if you use the key instead of the ID, you don't need to change any code when switching development_mode.
    */
    string leaderboardKey = "shapes_blitz";
    // int leaderboardID = 4705;

    string memberID;

    // Start is called before the first frame update
    void Start()
    {

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                loginInformationText.text = "Guest session started";
                playerIdText.text = "Player ID:" + response.player_id.ToString();
                memberID = response.player_id.ToString();
                //UpdateLeaderboardTop10();
                UpdateLeaderboardCentered();
            }
            else
            {
                loginInformationText.text = "Error" + response.Error;
            }
        });
    }



    public void UploadScore(int score)
    {
      
        /*
         * Since this is a player leaderboard, member_id is not needed, 
         * the logged in user is the one that will upload the score.
         */
        LootLockerSDKManager.SubmitScore(memberID, score, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                loginInformationText.text = "Player score was submitted";
                /*
                 * Update the leaderboards when the new score was sent so we can see them
                 */
                UpdateLeaderboardCentered();
               // UpdateLeaderboardTop10();
            }
            else
            {
                loginInformationText.text = "Error submitting score:" + response.Error;
            }
        });
    }
    void UpdateLeaderboardCentered()
    {
        LootLockerSDKManager.GetMemberRank(leaderboardKey, memberID, (memberResponse) =>
        {
            if (memberResponse.success)
            {
                if (memberResponse.rank == 0)
                {
                    leaderboardCenteredText.text = "Play at least once to see your position";
                    return;
                }
                int playerRank = memberResponse.rank;
                loginInformationText.text = "Rank: " + playerRank;
                int count = 10;
                /*
                 * Set "after" to 5 below and 4 above the rank for the current player.
                 * "after" means where to start fetch the leaderboard entries.
                 */
                int after = playerRank < 6 ? 0 : playerRank - 5;

                LootLockerSDKManager.GetScoreList(leaderboardKey, count, after, (scoreResponse) =>
                {
                    if (scoreResponse.success)
                    {
                        

                        /*
                         * Format the leaderboard
                         */
                        string leaderboardText = "";
                        for (int i = 0; i < scoreResponse.items.Length; i++)
                        {
                            LootLockerLeaderboardMember currentEntry = scoreResponse.items[i];

                            /*
                             * Highlight the player with rich text
                             */
                            if (currentEntry.rank == playerRank)
                            {
                                leaderboardText += "<color=yellow>";
                            }

                            leaderboardText += currentEntry.rank + ".";
                            leaderboardText += "Player" +currentEntry.player.id;
                            leaderboardText += " - ";
                            leaderboardText += currentEntry.score;
                            leaderboardText += " - ";
                            leaderboardText += currentEntry.metadata;

                            /*
                            * End highlighting the player
                            */
                            if (currentEntry.rank == playerRank)
                            {
                                leaderboardText += "</color>";
                            }
                            leaderboardText += "\n";
                        }
                        leaderboardCenteredText.text = leaderboardText;
                    }
                    else
                    {
                        loginInformationText.text = "Could not update scores:" + scoreResponse.Error;
                    }
                });
            }
            else
            {
                loginInformationText.text = "Could not get member rank:" + memberResponse.Error;
            }
        });
    }

    /*void UpdateLeaderboardTop10()
    {
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
        {
            if (response.success)
            {
                loginInformationText.text = "Top 10 leaderboard updated";

                *//*
                 * Format the leaderboard
                 *//*
                string leaderboardText = "";
                for (int i = 0; i < response.items.Length; i++)
                {
                    LootLockerLeaderboardMember currentEntry = response.items[i];
                    leaderboardText += currentEntry.rank + ".";
                    leaderboardText += currentEntry.player.id;
                    leaderboardText += " - ";
                    leaderboardText += currentEntry.score;
                    leaderboardText += " - ";
                    leaderboardText += currentEntry.metadata;
                    leaderboardText += "\n";
                }
                leaderboardTop10Text.text = leaderboardText;
            }
            else
            {
                loginInformationText.text = "Error updating Top 10 leaderboard";
            }
        });
    }*/

}
