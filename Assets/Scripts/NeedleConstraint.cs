using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NeedleConstraint : MonoBehaviour
{

    private MoveAxisConstraint axis;
    public GameObject SingalCube;
    public GameObject Body;

    private bool isInBody;






    private MeridianReactionController mcontroller;
    private AcuInformation AcuInfoController;

    // Start is called before the first frame update
    void Start()
    {
        axis = this.GetComponent<MoveAxisConstraint>();
        var cubeRenderer = SingalCube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
        mcontroller = Body.GetComponent<MeridianReactionController>();
        AcuInfoController = Body.GetComponent<AcuInformation>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.gameObject.name);
        if (other.gameObject.tag == "Body" && this.gameObject.tag == "Needles")
        {
            Debug.Log("Hit");
            //var cubeRenderer = SingalCube.GetComponent<Renderer>();
            //cubeRenderer.material.SetColor("_Color", Color.green);
            axis.enabled = true;
        }
        if(other.GetType() == typeof(SphereCollider))
        {
            if(!isInBody)
            {
                if (other.gameObject.tag == "Point" && this.gameObject.tag == "Needles")
                {
                    //axis.enabled = true;
                    if (other.transform.parent.gameObject.name == "RenPoints")
                    {
                        Debug.Log("Hit Points: " + other.gameObject.name);
                        //mcontroller.MaterialChanger("Ren", true);
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(13, true);
                        AcuInfoController.updateRenPointInfo(other.gameObject.name);
                    }
                    else if(other.transform.parent.gameObject.name == "LMHTaiyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(0, true);
                    }
                    else if(other.transform.parent.gameObject.name == "LIYangMingPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(1, true);
                    }
                    else if(other.transform.parent.gameObject.name == "STFoot-YangMingPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(2, true);
                    }
                    else if(other.transform.parent.gameObject.name == "SPFoot-TaiyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(3, true);
                    }
                    else if(other.transform.parent.gameObject.name == "HTHand-ShaoyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(4, true);
                    }
                    else if(other.transform.parent.gameObject.name == "SI Hand-TaiYangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(5, true);
                    }
                    else if(other.transform.parent.gameObject.name == "BL Foot-TaiyangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(6, true);
                    }
                    else if(other.transform.parent.gameObject.name == "KI Foot-ShaoyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(7, true);
                    }
                    else if(other.transform.parent.gameObject.name == "PC Hand-JueyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(8, true);
                    }
                    else if(other.transform.parent.gameObject.name == "SJ Hand-ShaoYangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, true);
                        mcontroller.PathChanger(9, true);
                    }
                    isInBody = true;
                    
                }
            }
            
        }
        

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Body" && this.gameObject.tag == "Needles")
        {
            Debug.Log("Leave");
            //var cubeRenderer = SingalCube.GetComponent<Renderer>();
            //cubeRenderer.material.SetColor("_Color", Color.red);
            axis.enabled = false;
        }
        if(isInBody)
        {
            if(other.GetType() == typeof(SphereCollider))
            {
                if(other.gameObject.tag == "Point" && this.gameObject.tag == "Needles")
                {
                    //axis.enabled = true;
                    if(other.transform.parent.gameObject.name == "RenPoints")
                    {
                        Debug.Log("Leave Points: " + other.gameObject.name);
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(13, false);
                    }
                    else if(other.transform.parent.gameObject.name == "LMHTaiyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(0, false);
                        
                    }
                    else if(other.transform.parent.gameObject.name == "LIYangMingPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(1, false);
                    }
                    else if(other.transform.parent.gameObject.name == "STFoot-YangMingPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(2, false);
                    }
                    else if(other.transform.parent.gameObject.name == "SPFoot-TaiyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(3, false);
                    }
                    else if(other.transform.parent.gameObject.name == "HTHand-ShaoyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(4, false);
                    }
                    else if(other.transform.parent.gameObject.name == "SI Hand-TaiYangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(5, false);
                    }
                    else if(other.transform.parent.gameObject.name == "BL Foot-TaiyangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(6, false);
                    }
                    else if(other.transform.parent.gameObject.name == "KI Foot-ShaoyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(7, false);
                    }
                    else if(other.transform.parent.gameObject.name == "PC Hand-JueyinPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(8, false);
                    }
                    else if(other.transform.parent.gameObject.name == "SJ Hand-ShaoYangPoints")
                    {
                        mcontroller.PMChanger(other.gameObject, false);
                        mcontroller.PathChanger(9, false);
                    }
                    isInBody = false;
                }
            }
        }
        

        

    }

    private void meridianReaction()
    {

    }

}
