using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BihopTimer : MonoBehaviour
{
    [SerializeField]
    private GameObject bishopGO;

    private Bishop bishopScript;

    public bool startedCount = false;

    [SerializeField]
    private TMP_Text timerTXT;

    public int time = 2;

    private void Awake()
    {
        TextCast();
        bishopScript = bishopGO.GetComponent<Bishop>();
    }

    private void Update()
    {
        TextCast();
        bishopScript.time = time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("TimeStarter") && !startedCount)
        {
            StartCoroutine(CountDown());
            startedCount = true;
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        if (time > 0)
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
