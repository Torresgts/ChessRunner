using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static int score = 0;
    public static int BestScore = 0;

    private const string ScoreKey = "Score";
    private const string BestScoreKey = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        BestScore = PlayerPrefs.GetInt(BestScoreKey, 20);
    }

    /*public static int GetScore()
    {
        if (PlayerPrefs.HasKey(ScoreKey))
        {
            if (Score > PlayerPrefs.GetInt(ScoreKey))
            {
                PlayerPrefs.SetInt(ScoreKey, Score);
            }
        }
        else
        {
            //Used only one time
            PlayerPrefs.SetInt("Score", 0);
        }

        return Score;
    }*/

    public static void SetBestScore()
    {
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            if (score > PlayerPrefs.GetInt(BestScoreKey, 0))
            {
                PlayerPrefs.SetInt(BestScoreKey, score);
            }
        }
        else
        {
            //Used only one time
            PlayerPrefs.SetInt(BestScoreKey, score);
        }
    }

    public static void SaveBestScore()
    {
        if (score > PlayerPrefs.GetInt(BestScoreKey, 0))
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
