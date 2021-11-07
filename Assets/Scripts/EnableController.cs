using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnableController : MonoBehaviour
{
    private TapToPlace tpComponents;
    public GameObject MeridianSystem;

    public GameObject DockNeedles;
    public TextMesh textTP;
    public TextMesh textM;
    public TextMesh textN;

    void Start()
    {
        tpComponents = this.GetComponent<TapToPlace>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void TPButtonControl()
    {
        if(tpComponents.enabled == false)
        {
            tpComponents.enabled = true;
            textTP.text = "On";
        }
        else
        {
            tpComponents.enabled = false;
            textTP.text = "Off";
        }

    }

    
    public void TPSButtonControl()
    {
        if (tpComponents.enabled == false)
        {
            tpComponents.enabled = true;
            textTP.text = "On";
        }
        else
        {
            tpComponents.enabled = false;
            textTP.text = "Off";
        }
    }

    public void MeridianButtonControl()
    {
        if (MeridianSystem.active == false)
        {
            MeridianSystem.SetActive(true);
            textM.text = "On";
        }
        else
        {
            MeridianSystem.SetActive(false);
            textM.text = "Off";
        }
    }

    public void NeedleControl()
    {
        if(DockNeedles.active == false)
        {
            DockNeedles.SetActive(true);
            textN.text = "On";
        }
        else
        {
            DockNeedles.SetActive(false);
            textN.text = "Off";
        }
    }

}
