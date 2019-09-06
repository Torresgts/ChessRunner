using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreText;
    
    //[SerializeField]
    //private TMP_Text bestScoreText;

    private string ScoreStr = "SCORE: ";

    private const string bestScore = "actualbestscore";

    public static int bestScoreValue = 0;

    private void Awake()
    {
        ScoreLanguage();

        _scoreText = this.gameObject.GetComponent<TMP_Text>();
    }

    private void ScoreLanguage()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            ScoreStr = "SCORE: ";
        }
        else if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            ScoreStr = "PONTOS: ";
        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            ScoreStr = "PUNTUACIÓN: ";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetBestScore();
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = ScoreStr + GameplayManager.score;
    }

    public static void GetBestScore()
    {
        if (PlayerPrefs.HasKey(bestScore))
        {
            if(GameplayManager.score > PlayerPrefs.GetInt(bestScore, 0))
            {
                PlayerPrefs.SetInt(bestScore, GameplayManager.score);
                bestScoreValue = GameplayManager.score;
            }
            else
            {
                bestScoreValue = PlayerPrefs.GetInt(bestScore, 0);
            }
          
        }
        else
        {
            PlayerPrefs.SetInt(bestScore, GameplayManager.score);
            bestScoreValue = GameplayManager.score;
        }
        //BestScore bstscore = FindObjectOfType<BestScore>();
        //bstscore.gameObject.GetComponent<BestScore>().bestScoreStr = bestScoreValue.ToString();

        BestScore.bestScoreText.text = bestScoreValue.ToString();
    }

    //public void SaveBestScore()
    //{
    //    if (PlayerPrefs.HasKey(bestScore))
    //    {
    //        PlayerPrefs.SetInt(bestScore, GameplayManager.score);
    //    }
    //}
}
