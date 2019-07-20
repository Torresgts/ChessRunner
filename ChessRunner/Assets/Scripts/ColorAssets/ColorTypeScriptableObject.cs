using UnityEngine;

[CreateAssetMenu(fileName = "ColorTypeData", menuName = "ScriptableObjects/ColorTypeScriptableObject", order = 1)]
public class ColorTypeScriptableObject : ScriptableObject
{
    public string colorName;
    public Color tileA = new Color(0f,0f,0f,1f);
    public Color tileB = new Color(0f,0f,0f,1f);
    public Color pieces = new Color(0f,0f,0f,1f);
}