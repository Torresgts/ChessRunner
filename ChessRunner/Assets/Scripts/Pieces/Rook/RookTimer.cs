using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RookTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject rookGO;

    private Rook rookScript;

    public bool startedCount = false;

    [SerializeField]
    private TMP_Text  timerTXT;

    public int time = 2;

    private void Awake()
    {
        TextCast();
        rookScript = rookGO.GetComponent<Rook>();
    }

    private void Update()
    {
        TextCast();
        rookScript.time = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("TimeStarter") && !startedCount)
        {
            StartCoroutine(CountDown());
            startedCount = true;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        if(time > 0)
        {
            time--;
            StartCoroutine(CountDown());
        }
    }

    private void TextCast()
    {
        timerTXT.text = time.ToString() + "'s";
        
    }
}
