using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public static GameObject horse;

    private void Awake()
    {
        horse = this.gameObject;
    }

    void Update()
    {
        PositionByInput();
    }

    private void PositionByInput() //Equal te position of this Gameobject with tilePos(Array). USED ONLY FOR TESTING!
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            this.gameObject.transform.position = Block.TileGO[0, 0].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            this.gameObject.transform.position = Block.TileGO[0, 1].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            this.gameObject.transform.position = Block.TileGO[0, 2].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            this.gameObject.transform.position = Block.TileGO[1, 0].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha5))
        {
            this.gameObject.transform.position = Block.TileGO[1, 1].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha6))
        {
            this.gameObject.transform.position = Block.TileGO[1, 2].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha7))
        {
            this.gameObject.transform.position = Block.TileGO[2, 0].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha8))
        {
            this.gameObject.transform.position = Block.TileGO[2, 1].transform.position;
        }

        if (Input.GetKey(KeyCode.Alpha9))
        {
            this.gameObject.transform.position = Block.TileGO[2, 2].transform.position;
        }
    }
}
