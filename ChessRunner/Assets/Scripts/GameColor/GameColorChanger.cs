using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameColorChanger : MonoBehaviour
{
    public ColorTypeListScriptableObject colorTypeList;

    private Image selfImage;
    public Text selfText;

    private int indexColor=0;

    // Start is called before the first frame update
    void Start()
    {
        selfImage = GetComponent<Image>();
        Init();
    }

    private void Init()
    {
        if(PlayerPrefs.HasKey("indexColor"))
        {
           indexColor = PlayerPrefs.GetInt("indexColor");
        } else {
            PlayerPrefs.SetInt("indexColor", 0);
            indexColor = 0;
        }

        selfImage.color = colorTypeList.colorTypes[indexColor].tileA;
        selfText.color = colorTypeList.colorTypes[indexColor].tileB;
    }

    public void NextColor()
    {
        indexColor++;
        if(indexColor >= colorTypeList.colorTypes.Length || 
            indexColor >= PlayerPrefs.GetInt("Level")
        ) indexColor=0;
        selfImage.color = colorTypeList.colorTypes[indexColor].tileA;
        selfText.color = colorTypeList.colorTypes[indexColor].tileB;
        PlayerPrefs.SetInt("indexColor", indexColor);
    }

}
