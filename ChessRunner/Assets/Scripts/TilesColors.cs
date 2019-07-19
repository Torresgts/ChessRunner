using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesColors : MonoBehaviour
{


    public static Color firstColor;
    public static Color secondColor;


    /// <summary>
    /// Use in Block (script) colorSwitch to define color sequences.
    /// </summary>
    /// <param name="colorSwitch"></param>
    public static void TilesColor(bool colorSwitch, BlockHandler blockHandler)
    {
        if(!PlayerPrefs.HasKey("indexColor")) PlayerPrefs.SetInt("indexColor", 0);
        int _colorIndex = PlayerPrefs.GetInt("indexColor");
        
        var _colorType = blockHandler.colorTypeList.colorTypes[_colorIndex];
        firstColor = _colorType.tileA;
        secondColor = _colorType.tileB;

        if (colorSwitch)
        {
            Block.TileGO[0, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[0, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[0, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[0, 3].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 3].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 3].GetComponent<Image>().color = secondColor;
            Block.TileGO[3, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[3, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[3, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[3, 3].GetComponent<Image>().color = firstColor;
            Block.TileGO[4, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[4, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[4, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[4, 3].GetComponent<Image>().color = secondColor;
        }
        else
        {
            Block.TileGO[0, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[0, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[0, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[0, 3].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 3].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 3].GetComponent<Image>().color = firstColor;
            Block.TileGO[3, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[3, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[3, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[3, 3].GetComponent<Image>().color = secondColor;
            Block.TileGO[4, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[4, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[4, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[4, 3].GetComponent<Image>().color = firstColor;
        }

    }
}
