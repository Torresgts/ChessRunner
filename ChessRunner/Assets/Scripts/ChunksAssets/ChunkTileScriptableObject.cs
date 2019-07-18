using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkTileData", menuName = "ScriptableObjects/ChunkTileScriptableObject", order = 1)]
public class ChunkTileScriptableObject : ScriptableObject
{
    public ChunkTile[] chunkTile;
    public ChunkTileScriptableObject[] prohibitedNext;
}

[Serializable]
public class ChunkTile
{
    [SerializeField]
    public EnemyType[] enemies;
}