using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{

    [SerializeField]
    private ChunkTileListScriptableObject chunkTileList;

    [SerializeField]
    private static ChunkTileListScriptableObject chunkTileListAux;
    
    [SerializeField]
    private static int chunkIndex;

    private static ChunkTileScriptableObject lastChunkSpawned;

    private static int numberOfTimesToSpawnClearOne = 1; 


    void Start()
    {
        numberOfTimesToSpawnClearOne= 1;
        chunkTileListAux = chunkTileList;

        lastChunkSpawned = chunkTileListAux.chunkTiles[0];
    }

    //public static EnemyType[,] GetEnemiesInChunk()
    //{
    //    chunkIndex = Random.Range(0, chunkTileListAux.chunkTiles.Length);

    //    var _chunkTile = chunkTileListAux.chunkTiles[chunkIndex];

    //    //List<int> prohibitedIndex = new List<int>();

    //    //foreach (ChunkTileScriptableObject prohibitedChunk in _chunkTile.prohibitedNext)
    //    //{
    //    //    prohibitedIndex.Add(prohibitedChunk.index);
    //    //}

    //    EnemyType[,] _enemies = new EnemyType[_chunkTile.chunkTile.Length, _chunkTile.chunkTile[0].enemies.Length];


    //    //if (prohibitedIndex.Contains(chunkIndex))
    //    //{
    //    //    while (prohibitedIndex.Contains(chunkIndex))
    //    //    {
    //    //        chunkIndex = Random.Range(0, chunkTileListAux.chunkTiles.Length);
    //    //    }

    //    //    for (byte a = 0; a < _enemies.GetLength(0); a++)
    //    //    {
    //    //        for (byte b = 0; b < _enemies.GetLength(1); b++)
    //    //        {
    //    //            _enemies[a, b] = _chunkTile.chunkTile[a].enemies[b];
    //    //            //Debug.Log(_enemies[a,b]);

    //    //            GameObject newEnemy;
    //    //            newEnemy = Instantiate(Resources.Load(_enemies[a, b].ToString()), new Vector3(Block.TileGO[a, b].transform.position.x, Block.TileGO[a, b].transform.position.y, Block.TileGO[a, b].transform.position.z), Quaternion.identity, Block.TileGO[a, b].transform) as GameObject;
    //    //        }
    //    //    }

    //    //    // GetEnemiesInChunk();
    //    //}
    //    //else
    //    //{
    //    //    for (byte a = 0; a < _enemies.GetLength(0); a++)
    //    //    {
    //    //        for (byte b = 0; b < _enemies.GetLength(1); b++)
    //    //        {
    //    //            _enemies[a, b] = _chunkTile.chunkTile[a].enemies[b];
    //    //            //Debug.Log(_enemies[a,b]);

    //    //            GameObject newEnemy;
    //    //            newEnemy = Instantiate(Resources.Load(_enemies[a, b].ToString()), new Vector3(Block.TileGO[a, b].transform.position.x, Block.TileGO[a, b].transform.position.y, Block.TileGO[a, b].transform.position.z), Quaternion.identity, Block.TileGO[a, b].transform) as GameObject;
    //    //        }
    //    //    }
    //    //}

    //    if (lastChunkSpawned.prohibitedNextList.Contains(_chunkTile))
    //    {
    //        //GetEnemiesInChunk();
    //    }
    //    else
    //    {
    //        for (byte a = 0; a < _enemies.GetLength(0); a++)
    //        {
    //            for (byte b = 0; b < _enemies.GetLength(1); b++)
    //            {
    //                _enemies[a, b] = _chunkTile.chunkTile[a].enemies[b];
    //                //Debug.Log(_enemies[a,b]);

    //                GameObject newEnemy;
    //                newEnemy = Instantiate(Resources.Load(_enemies[a, b].ToString()), new Vector3(Block.TileGO[a, b].transform.position.x, Block.TileGO[a, b].transform.position.y, Block.TileGO[a, b].transform.position.z), Quaternion.identity, Block.TileGO[a, b].transform) as GameObject;
    //            }
    //        }
    //    }
        
    //    return _enemies;
    //}


    public static EnemyType[,] GetEnemiesInChunk()
    {
        if(numberOfTimesToSpawnClearOne > 0)
        {
            chunkIndex = 0;
            numberOfTimesToSpawnClearOne--;
        } else {
            chunkIndex = Random.Range(0, chunkTileListAux.chunkTiles.Length);
        }

        var _chunkTile = chunkTileListAux.chunkTiles[chunkIndex];

        EnemyType[,] _enemies = new EnemyType[_chunkTile.chunkTile.Length, _chunkTile.chunkTile[0].enemies.Length];


        if (lastChunkSpawned.prohibitedNextList.Contains(_chunkTile))
        {
            GetEnemiesInChunk();
        }
        else
        {
            for (byte a = 0; a < _enemies.GetLength(0); a++)
            {
                for (byte b = 0; b < _enemies.GetLength(1); b++)
                {
                    _enemies[a, b] = _chunkTile.chunkTile[a].enemies[b];
                    //Debug.Log(_enemies[a,b]);

                    GameObject newEnemy;
                    newEnemy = Instantiate(Resources.Load(_enemies[a, b].ToString()), new Vector3(Block.TileGO[a, b].transform.position.x, Block.TileGO[a, b].transform.position.y, Block.TileGO[a, b].transform.position.z), Quaternion.identity, Block.TileGO[a, b].transform) as GameObject;

                    lastChunkSpawned = _chunkTile;
                }
            }
        }

        return _enemies;
    }

}
