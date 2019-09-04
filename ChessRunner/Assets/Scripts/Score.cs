using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private TMP_Text _scoreText;
    
    [SerializeField]
    private TMP_Text bestScoreText;

    private string ScoreStr = "SCORE: ";
    
    private void Awake()
    {
        if (Application.systemLanguage == SystemLanguage.English)
        {
            ScoreStr = "SCORE: ";
        }
        else if(Application.systemLanguage == SystemLanguage.Portuguese)
        {
            ScoreStr = "PONTOS: ";
        }
        else if(Application.systemLanguage == SystemLanguage.Spanish)
        {
            ScoreStr = "PUNTUACIÓN: ";
        }
        
        _scoreText = this.gameObject.GetComponent<TMP_Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = GameplayManager.BestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = GameplayManager.BestScore.ToString();
        _scoreText.text = ScoreStr + GameplayManager.score;
    }
}
