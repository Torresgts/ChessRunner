using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static int score = 0;
    //public static int BestScore = 0;

    private const string ScoreKey = "Score";

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
