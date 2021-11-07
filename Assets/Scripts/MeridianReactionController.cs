using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeridianReactionController : MonoBehaviour
{
    private GameObject present = null;

    public Material inactive;
    public Material active;

    public Material H1_active;
    public Material H2_active;

    public Material H1_inactive;
    public Material H2_inactive;

    public GameObject Heart;
    public GameObject ball;
    public Material bLight;

    public GameObject Ren;
    public GameObject LMH_Taiyin;

    public TextMeshPro num;

    private int [] Paths = new int[14];

    private bool active_Ren;

    private List<bool> bools;

    private bool[] Ren_bools;

    private float scale = 1;
    // Start is called before the first frame update


    void Awake()
    {
        bools = new List<bool>();
        Ren_bools = new bool[24];
    }
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
        if(scale <= 1)
        {
            scale += 0.2f;
        }
        else if(scale >= 2)
        {
            scale -= 0.2f;
        }
        num.text = scale.ToString();
        if(Paths[13] >= 3)
        {
            //num.text = "Active!";
            ball.SetActive(true);
            ball.GetComponent<Renderer>().sharedMaterial.SetFloat("Size", scale);
            //activeBall();
            
        }
        else
        {
            ball.SetActive(false);
        }
        //activeHeart();
        //num.text = "Num is: " + Ren_pins.ToString();
    }

    public void MaterialChanger(string name, bool a)
    {
        switch (name)
        {
            case "Ren":
                if(a)
                {
                    Ren.GetComponent<Renderer>().material = active;
                    Paths[13] += 1;
                }
                else
                {
                    Paths[13] -= 1;
                    if(Paths[13] == 0)
                    {
                        Ren.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;

            case "LMH_Taiyin":
                if(a)
                {
                    LMH_Taiyin.GetComponent<Renderer>().material = active;
                    Paths[0] += 1;
                }
                else
                {
                    Paths[0] -= 1;
                    if(Paths[0] == 0)
                    {
                        LMH_Taiyin.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            default:
                break;
                
        }
    }

    public void PMChanger(GameObject gameObject, bool a)
    {
        if (a)
        {
            gameObject.GetComponent<Renderer>().material = active;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = inactive;
            
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

    private int RenPointFinder(string name)
    {
        switch(name)
        {
            case "Huiyin":
                return 0;
            case "Qugu":
                return 1;
            case "Zhongqi":
                return 2;
            case "Guanyuan":
                return 3;
            case "Shimen":
                return 4;
            default:
                return -1;
        }
    }


    private void activeHeart()
    {
        if(Paths[13] >= 3)
        {
            Heart.GetComponent<MeshRenderer>().materials[0] = H1_active;
            Heart.GetComponent<MeshRenderer>().materials[1] = H2_active;
        }
        else
        {
            Heart.GetComponent<MeshRenderer>().materials[0] = H1_inactive;
            Heart.GetComponent<MeshRenderer>().materials[1] = H2_inactive;
        }
    }

    private void activeBall()
    {
        for(float i = 1; i < 2; i += 0.1f)
        {
            ball.GetComponent<Renderer>().sharedMaterial.SetFloat("Size", i);
            Debug.Log("Increasing: " + i);
        }
        for(float i = 2; i > 1; i -= 0.1f)
        {
            ball.GetComponent<Renderer>().sharedMaterial.SetFloat("Size", i);
            Debug.Log("Decreasing: " + i);
        }
        
    }

    


    public void setBoolforPoint(bool active, int i)
    {
        bools[i] = active;
    }
}
