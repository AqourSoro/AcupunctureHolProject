using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NeedleConstraint : MonoBehaviour
{

    private MoveAxisConstraint axis;
    public GameObject SingalCube;
    public GameObject Body;




    private MeridianReactionController mcontroller;

    // Start is called before the first frame update
    void Start()
    {
        axis = this.GetComponent<MoveAxisConstraint>();
        var cubeRenderer = SingalCube.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
        mcontroller = Body.GetComponent<MeridianReactionController>();
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
            if (other.gameObject.tag == "Point" && this.gameObject.tag == "Needles")
            {
                axis.enabled = true;
                if (other.transform.parent.gameObject.name == "RenPoints")
                {
                    Debug.Log("Hit Points: " + other.gameObject.name);
                    mcontroller.MaterialChanger("Ren", true);
                    mcontroller.PMChanger(other.gameObject, true);
                }
                else if(other.transform.parent.gameObject.name == "LMH-TaiyinPoints")
                {
                    mcontroller.MaterialChanger("LMH_Taiyin", true);
                    mcontroller.PMChanger(other.gameObject, true);
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

        if(other.GetType() == typeof(SphereCollider))
        {
            if(other.gameObject.tag == "Point" && this.gameObject.tag == "Needles")
            {
                axis.enabled = true;
                if(other.transform.parent.gameObject.name == "RenPoints")
                {
                    Debug.Log("Leave Points: " + other.gameObject.name);
                    mcontroller.PMChanger(other.gameObject, false);
                    mcontroller.MaterialChanger("Ren", false);
                }
                else if(other.transform.parent.gameObject.name == "LMH-TaiyinPoints")
                {
                    mcontroller.PMChanger(other.gameObject, false);
                    mcontroller.MaterialChanger("LMH_Taiyin", false);
                    
                }
                
            }
        }

        

    }
}
