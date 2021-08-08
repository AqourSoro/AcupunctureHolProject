using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableController : MonoBehaviour
{
    private TapToPlace tpComponents;
    public TextMeshPro inforTP;

    void Start()
    {
        tpComponents = this.GetComponent<TapToPlace>();
        inforTP.text = "Enabled";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TPButtonControl()
    {
        if(tpComponents.enabled == false)
        {
            tpComponents.enabled = true;
            inforTP.text = "Enabled";
        }
        else
        {
            tpComponents.enabled = false;
            inforTP.text = "Disabled";
        }

    }
}
