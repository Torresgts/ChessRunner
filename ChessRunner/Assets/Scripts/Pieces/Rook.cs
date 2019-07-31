using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rook : MonoBehaviour
{
    public GameObject[] possibleMoveGO;

    RectTransform rt;

    public int time = 2;

    private void Awake()
    {
        rt = this.gameObject.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(250, 250);
    }

}
