using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public static GameObject BlockHandlerGameObject;

    public static bool playerIsDead = false;

    bool instanciedGameOverAlready = false;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {

        BlockHandlerGameObject = Instantiate(Resources.Load("BlocksHandler"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity, gameObject.transform) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLost();
    }

    public void PlayerLost()
    {
        if (playerIsDead)
        {
            // PlayerLost();
            gameOver.SetActive(true);
        }


    }
}
