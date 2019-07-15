using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilesColors : MonoBehaviour
{
    public static Color firstColor = new Color32(214, 214, 214, 255);
    public static Color secondColor = new Color32(255, 255, 255, 255);

    /// <summary>
    /// Use in Block (script) colorSwitch to define color sequences.
    /// </summary>
    /// <param name="colorSwitch"></param>
    public static void TilesColor(bool colorSwitch)
    {

        if (colorSwitch)
        {
            Block.TileGO[0, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[0, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[0, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 2].GetComponent<Image>().color = firstColor;
        }
        else
        {
            Block.TileGO[0, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[0, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[0, 2].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 0].GetComponent<Image>().color = firstColor;
            Block.TileGO[1, 1].GetComponent<Image>().color = secondColor;
            Block.TileGO[1, 2].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 0].GetComponent<Image>().color = secondColor;
            Block.TileGO[2, 1].GetComponent<Image>().color = firstColor;
            Block.TileGO[2, 2].GetComponent<Image>().color = secondColor;
        }

    }
}
