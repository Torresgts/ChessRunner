using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    /// <summary>
    /// An Array that have all tiles in this GameObject. Use to get tiles positions, Components.
    /// </summary>
    public static GameObject[,] TileGO = new GameObject[5, 4];

    [Tooltip("Get all the Tiles in a Block")]
    public List<GameObject> TilesList = new List<GameObject>();

    public GameObject BlocksHandlerGO;
    
    private bool alreadyCreatedNewBlock = false;

    //it's a auxiliar variable to define wich color pattern the Block will have.
    bool colorSwitch;

    void Start()
    {
        GetTilesPosition5x4();

        TilesColors.TilesColor(colorSwitch, BlocksHandlerGO.GetComponent<BlockHandler>());
    }

    private void Update()
    {
        DestroyBlockOnLimit();

        CreateNewBlock();
    }

    private void DestroyBlockOnLimit() //If this block get to a Y (vertex) limit, it's destroyed. 
    {
        float limit = -8.2f;

        if (this.gameObject.transform.position.y <= limit)
        {
            Destroy(this.gameObject);
            //Debug.Log("Block Destroyed");
        }
    }
    
    private void GetTilesPosition3x3() // Get all Tiles (from tileList(List)) and equal to tilePos(Array). 
    {
        int row = 0, columm = 0;

        foreach (GameObject tile in TilesList)
        {
            if (row == 0 && columm <= 2)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 0 && columm == 3)
            {
                row = 1;
                columm = 0;
            }

            if (row == 1 && columm <= 2)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 1 && columm == 3)
            {
                row = 2;
                columm = 0;
            }

            if (row == 2 && columm <= 2)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }

            
        }
    }

    private void GetTilesPosition5x4() // Get all Tiles (from tileList(List)) and equal to tilePos(Array). 
    {
        int row = 0, columm = 0;

        foreach (GameObject tile in TilesList)
        {
            if (row == 0 && columm <= 3)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 0 && columm == 4)
            {
                row = 1;
                columm = 0;
            }

            if (row == 1 && columm <= 3)
            {
                TileGO[row, columm] = tile.gameObject;
               // Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 1 && columm == 4)
            {
                row = 2;
                columm = 0;
            }

            if (row == 2 && columm <= 3)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 2 && columm == 4)
            {
                row = 3;
                columm = 0;
            }

            if (row == 3 && columm <= 3)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }
            else if (row == 3 && columm == 4)
            {
                row = 4;
                columm = 0;
            }

            if (row == 4 && columm <= 3)
            {
                TileGO[row, columm] = tile.gameObject;
                //Debug.Log("Name :" + tile.name + "Position :" + tile.transform.position);
                columm++;
            }


        }
    }

    private void CreateNewBlock() //function to decide when to call CreateBlock() Coroutine.
    {
        float createPosition = 6f; //represents the value of Y (vertex), to create a new block.

        if (this.gameObject.transform.position.y <= createPosition && !alreadyCreatedNewBlock)
        {
            alreadyCreatedNewBlock = true;
            StartCoroutine(CreateBlock()); //initialize Coroutine CreatorBlock()
        }
    }

    IEnumerator CreateBlock() //Create a new Block, Intantiate on Game Scene and define conditions of tiles colors.
    {
        GameObject newBlock;

        yield return new WaitForSeconds(0.0f);

        //newBlock = Instantiate(this.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5.61f, this.gameObject.transform.position.z), Quaternion.identity, BlocksHandlerGO.transform) as GameObject;
        newBlock = Instantiate(Resources.Load("Block5x4"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 7f, this.gameObject.transform.position.z), Quaternion.identity, SceneHandler.BlockHandlerGameObject.transform) as GameObject;
        BlockHandler.numberOfBlocks++;
        newBlock.name = "Block5x4 Inst " + BlockHandler.numberOfBlocks;

        //AQUI GABRIEL --- É O Spawner
        PieceSpawner.Spawn(EnemyType.Pawn, TileGO[Random.Range(0,5), Random.Range(0, 4)]);

        //PieceSpawner.GetEnemiesInChunk();


        if (colorSwitch)
        {
            newBlock.GetComponent<Block>().colorSwitch = false;
        }
        else
        {
            newBlock.GetComponent<Block>().colorSwitch = true;
        }
    }
}
