using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeridianReactionController : MonoBehaviour
{
    private GameObject present = null;

    public Material inactive;
    public Material active;

    public GameObject Ren;


    private bool active_Ren;

    private List<bool> bools = new List<bool>();

    // Start is called before the first frame update


    void Start()
    {
        bools.Add(active_Ren);

        bools.ForEach(p => 
            { p = false; }
            );

        for (var i = 0; i < bools.Count; i++)
        {
            bools[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bools.ForEach(p =>
        //{
        //    if (p == true)
        //    {
        //        present = meridianFinder(bools.IndexOf(p));
        //
        //        present.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(active);
        //    }
        //    else
        //    {
        //        present = meridianFinder(bools.IndexOf(p));

        //        present.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(inactive);
        //    }
        //}
        //    );
    }

    public void MaterialChanger(int i, bool a)
    {
        switch (i)
        {
            case 0:
                if(a)
                {
                    Ren.GetComponent<Renderer>().material = active;
                }
                else
                {
                    Ren.GetComponent<Renderer>().material = inactive;
                    //Ren.GetComponent<MeshRenderer>().materials[0].CopyPropertiesFromMaterial(inactive);
                }
                break;
            default:
                break;
                
        }
    }
    private GameObject meridianFinder(int i)
    {
        switch(i)
        {
            case 0:
                return Ren;
            default:
                return null;
        }
    }

    public void setBoolforPoint(bool active, int i)
    {
        bools[i] = active;
    }
}
