using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public EnemyType[,] GetEnemiesInChunk()
    {
        EnemyType[,] _enemies = new EnemyType[4,4];

        for(byte a=0; a<4;a++)
        {
            for(byte b=0; b<4;b++)
            {
                _enemies[a,b] = EnemyType.Empty;
            }
        }

        _enemies[0,3] = EnemyType.Pawn;
        
        return _enemies;
    }
}
