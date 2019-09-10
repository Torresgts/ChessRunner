using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    /// <summary>
    /// An Array that have all tiles in this GameObject. Use to get tiles positions, Components.
    /// </summary>
    public static GameObject[,] TileGO = new GameObject[5, 4];

    [FormerlySerializedAs("TilesList")] [Tooltip("Get all the Tiles in a Block")]
    public List<GameObject> tilesList = new List<GameObject>();

    [FormerlySerializedAs("BlocksHandlerGO")] public GameObject blocksHandlerGo;
    
    private bool _alreadyCreatedNewBlock = false;

    public int index;


    //it's a auxiliar variable to define wich color pattern the Block will have.
    bool _colorSwitch;

    void Start()
    {
        GetTilesPosition5x4();

        TilesColors.TilesColor(_colorSwitch, blocksHandlerGo.GetComponent<BlockHandler>());

        PieceSpawner.GetEnemiesInChunk();
        
    }

    private void Update()
    {
        DestroyBlockOnLimit();

        //CreateNewBlock(); //Here
    }

    private void DestroyBlockOnLimit() //If this block get to a Y (vertex) limit, it's destroyed. 
    {
        float limit = -8.2f;

        if (this.gameObject.transform.position.y <= limit)
        {
            //Destroy(this.gameObject);
            //Debug.Log("Block Destroyed");
        }
    }
    
    private void GetTilesPosition3x3() // Get all Tiles (from tileList(List)) and equal to tilePos(Array). 
    {
        int row = 0, columm = 0;

        foreach (GameObject tile in tilesList)
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

        foreach (GameObject tile in tilesList)
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
        float createPosition = 6f; //represents the value of Y (vertex), to create a new block. 6f

        //if (this.gameObject.transform.position.y <= createPosition && !_alreadyCreatedNewBlock)
        //{
        //    _alreadyCreatedNewBlock = true;
        //    StartCoroutine(CreateBlock()); //initialize Coroutine CreateBlock()
        //}

        //new way of spawning
        if (!_alreadyCreatedNewBlock)
        {
            _alreadyCreatedNewBlock = true;
            StartCoroutine(CreateBlock()); //initialize Coroutine CreateBlock()
        }
    }

    IEnumerator CreateBlock() //Create a new Block, Intantiate on Game Scene and define conditions of tiles colors.
    {
        float _Distance;

        GameObject newBlock;

        yield return new WaitForSeconds(0.0f);

        //newBlock = Instantiate(this.gameObject, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 5.61f, this.gameObject.transform.position.z), Quaternion.identity, BlocksHandlerGO.transform) as GameObject;
        newBlock = Instantiate(Resources.Load("Block5x4"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 6.08f, this.gameObject.transform.position.z), Quaternion.Euler(0,0,180), SceneHandler.BlockHandlerGameObject.transform) as GameObject; //Usar esse aqui!!!
        //newBlock = Instantiate(Resources.Load("Block5x4"), new Vector3(this.gameObject.transform.position.x, Camera.main.transform.position.y + 6.85f, this.gameObject.transform.position.z), Quaternion.identity, SceneHandler.BlockHandlerGameObject.transform) as GameObject;
        

        BlockHandler.numberOfBlocks++;
        newBlock.name = "Block5x4 Inst " + BlockHandler.numberOfBlocks;
        //newBlock.transform.SetAsFirstSibling();

        //PieceSpawner.GetEnemiesInChunk();
        
        newBlock.GetComponent<Block>()._colorSwitch = !_colorSwitch;

        BlockAux.LastBlockInstancied = newBlock;

        _Distance = Vector3.Distance(this.gameObject.transform.position, BlockAux.LastBlockInstancied.transform.position);

        Debug.Log("Distance is: " + _Distance);
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Creator"))
        {
            CreateNewBlock();
        }
    }
}
