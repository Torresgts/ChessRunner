using UnityEngine;

[CreateAssetMenu(fileName = "ColorTypeListData", menuName = "ScriptableObjects/ColorTypeListScriptableObject", order = 1)]
public class ColorTypeListScriptableObject : ScriptableObject
{
    public ColorTypeScriptableObject[] colorTypes;
}