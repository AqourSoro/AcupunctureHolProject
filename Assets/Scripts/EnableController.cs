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

    public GameObject ball;

    public GameObject KnowledgePanel;
    public TextMesh textTP;
    public TextMesh textM;
    public TextMesh textN;
    public TextMesh textK;

    private MeridianReactionController meridianReactionController;

    void Start()
    {
        tpComponents = this.GetComponent<TapToPlace>();
        meridianReactionController = this.GetComponent<MeridianReactionController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void controlVisiable(GameObject gameObject, TextMesh textComponents)
    {
        if (gameObject.active == false)
        {
            gameObject.SetActive(true);
            textComponents.text = "On";
        }
        else
        {
            gameObject.SetActive(false);
            textComponents.text = "Off";
        }
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

    public void panelControl()
    {
        if(KnowledgePanel.active == false)
        {
            KnowledgePanel.SetActive(true);
            textK.text = "On";
        }
        else
        {
            KnowledgePanel.SetActive(false);
            textK.text = "Off";
        }
    }

}
