using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //print(GetEnemiesInChunk());

        //EnemySpawner(GetEnemiesInChunk());

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static EnemyType[,] GetEnemiesInChunk()
    {
        EnemyType[,] _enemies = new EnemyType[5,4];

        for(byte a=0; a<5;a++)
        {
            for(byte b=0; b<4;b++)
            {
                _enemies[a,b] = EnemyType.Pawn;

                GameObject enemyObject;
                enemyObject = Instantiate(Resources.Load(_enemies[a, b].ToString()), new Vector3(Block.TileGO[a, b].transform.position.x, Block.TileGO[a, b].transform.position.y, Block.TileGO[a, b].transform.position.z), Quaternion.identity, Block.TileGO[a, b].transform) as GameObject;
                 
               
            }
        }

        _enemies[0,3] = EnemyType.Pawn;


        return _enemies;
    }

    public static void Spawn(EnemyType enemy, GameObject tile)
    {
        GameObject enemyGO;
        enemyGO = Instantiate(Resources.Load(enemy.ToString()), new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z), Quaternion.identity, tile.transform) as GameObject;
    }

    public static void EnemySpawner(EnemyType[,] newEnemy)
    {

    }
}
