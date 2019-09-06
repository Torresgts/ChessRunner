using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GraphicsConfigs : MonoBehaviour
{
    [SerializeField]
    private PostProcessLayer _PPGLayer;


    // Start is called before the first frame update
    void Start()
    {
        if(PPManager.GraphicsEnabled)
        {
            TurnOnPP();
        }
        else if(!PPManager.GraphicsEnabled)
        {
            TurnOffPP();
        }
    }

    public void TurnOnPP()
    {
        _PPGLayer.enabled = true;
        PPManager.GraphicsEnabled = true;
    }

    public void TurnOffPP()
    {
        _PPGLayer.enabled = false;
        PPManager.GraphicsEnabled = false;
    }
}
