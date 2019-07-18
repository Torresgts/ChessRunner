using UnityEngine;

[CreateAssetMenu(fileName = "ChunkTileListData", menuName = "ScriptableObjects/ChunkTileListScriptableObject", order = 1)]
public class ChunkTileListScriptableObject : ScriptableObject
{
    public ChunkTileScriptableObject[] chunkTiles;
}