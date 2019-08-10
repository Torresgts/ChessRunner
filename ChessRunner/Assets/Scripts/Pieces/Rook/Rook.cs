using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rook : MonoBehaviour
{
    public GameObject[] possibleMoveGO;

    private RectTransform rt;

    public int time = 2;

    private void Awake()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(250, 250);
    }

    private void Start()
    {
        rt.sizeDelta = new Vector2(250, 250);
    }

}
