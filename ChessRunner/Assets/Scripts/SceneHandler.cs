using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    public static GameObject BlockHandlerGameObject;



    bool instanciedGameOverAlready = false;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBlockHandler());
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLost();
    }

    public void PlayerLost()
    {
        if (Horse.playerIsDead)
        {
            // PlayerLost();
            gameOver.SetActive(true);
        }
    }

    IEnumerator SpawnBlockHandler()
    {
        yield return new WaitForSeconds(0f);
        BlockHandlerGameObject = Instantiate(Resources.Load("BlocksHandler"), new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z), Quaternion.identity, gameObject.transform) as GameObject;
    }
}
