using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [SerializeField]
    private ChunkTileListScriptableObject chunkTileList;
    
    [SerializeField]
    private int chunkIndex;

    // Start is called before the first frame update
    void Start()
    {
        GetEnemiesInChunk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EnemyType[,] GetEnemiesInChunk()
    {
        var _chunkTile = chunkTileList.chunkTiles[chunkIndex];



        EnemyType[,] _enemies = new EnemyType[_chunkTile.chunkTile.Length,_chunkTile.chunkTile[0].enemies.Length];

        for(byte a=0; a<_enemies.GetLength(0);a++)
        {
            for(byte b=0; b<_enemies.GetLength(1);b++)
            {
                _enemies[a,b] = _chunkTile.chunkTile[a].enemies[b];
                Debug.Log(_enemies[a,b]);
            }
        }
        
        return _enemies;
    }
}
