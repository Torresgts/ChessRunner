using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAux : MonoBehaviour
{
    public static GameObject aux;

    private void Awake()
    {
        aux = this.gameObject;
    }
}
