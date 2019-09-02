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

    private const string ScoreStr = "SCORE: ";
    
    private void Awake()
    {
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
