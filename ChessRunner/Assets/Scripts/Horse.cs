using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horse : MonoBehaviour
{
    public static GameObject horse;

    public static bool playerIsDead = false;

    private void Awake()
    {
        horse = this.gameObject;
        
    }

    void Update()
    {
        DestroyHorseOnLimit();
    }

    private void DestroyHorseOnLimit() //If this block get to a Y (vertex) limit, it's destroyed. 
    {
        float limit = -6.2f;

        if (this.gameObject.transform.position.y <= limit)
        {
            playerIsDead = true;
            Destroy(this.gameObject);
        }
    }
}
