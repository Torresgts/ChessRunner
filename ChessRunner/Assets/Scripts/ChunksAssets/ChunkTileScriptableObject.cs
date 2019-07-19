using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChunkTileData", menuName = "ScriptableObjects/ChunkTileScriptableObject", order = 1)]
public class ChunkTileScriptableObject : ScriptableObject
{
    public ChunkTile[] chunkTile;
    //public ChunkTileScriptableObject[] prohibitedNext;
    public List<ChunkTileScriptableObject> prohibitedNextList;
}

[Serializable]
public class ChunkTile
{
    [SerializeField]
    public EnemyType[] enemies;
}