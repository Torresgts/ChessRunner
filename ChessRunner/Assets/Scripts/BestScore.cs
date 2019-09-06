using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    public static TMP_Text bestScoreText;

    private void Awake()
    {
        bestScoreText = this.gameObject.GetComponent<TMP_Text>();
    }

    
}
