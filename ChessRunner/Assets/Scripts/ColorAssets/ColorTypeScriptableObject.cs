using UnityEngine;

[CreateAssetMenu(fileName = "ColorTypeData", menuName = "ScriptableObjects/ColorTypeScriptableObject", order = 1)]
public class ColorTypeScriptableObject : ScriptableObject
{
    public Color tileA;
    public Color tileB;
    public Color pieces;
}