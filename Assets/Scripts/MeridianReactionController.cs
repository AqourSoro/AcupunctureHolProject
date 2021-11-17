using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MeridianReactionController : MonoBehaviour
{
    private GameObject present = null;

    public Material inactive;
    public Material active;

    public GameObject ball;
    public GameObject ball_arm;
    public Material bLight;

    public GameObject LMH_Taiyin;
    public GameObject LIYangMing;
    public GameObject Ren;
    

    public TextMeshPro num;

    private int [] Paths = new int[14];

    private bool active_Ren;

    private List<bool> bools;

    private bool[] Ren_bools;
    private bool[] LMH_Taiyin_bools;

    private float scale = 1;
    // Start is called before the first frame update


    void Awake()
    {
        bools = new List<bool>();
        Ren_bools = new bool[24];
        LMH_Taiyin_bools = new bool[11];
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        num.text = scale.ToString();
        for(int i = 0; i < Paths.Length; i ++)
        {
            if(Paths[i] >= 2)
            {
                ballChanger(i,true);
                MaterialChanger(i, true);
            }
            else if(Paths[i]  > 0)
            {
                ballChanger(i,false);
                MaterialChanger(i, true);
            }
            else
            {
                ballChanger(i,false);
                MaterialChanger(i, false);
            
            }
        }
        
        
        //activeHeart();
        //num.text = "Num is: " + Ren_pins.ToString();
    }

    public void MaterialChanger(string name, bool a)
    {
        switch (name)
        {
            case "LMHTaiyin":
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
            case "LIYangMing":
                if(a)
                {
                    LIYangMing.GetComponent<Renderer>().material = active;
                    Paths[1] += 1;
                }
                else
                {
                    Paths[1] -= 1;
                    if(Paths[1] == 0)
                    {
                        LIYangMing.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            
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

            
            default:
                break;
                
        }
    }

    public void MaterialChanger(int order, bool a)
    {
        switch (order)
        {
            case 0:
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

            case 1:
                if(a)
                {
                    LIYangMing.GetComponent<Renderer>().material = active;
                    Paths[1] += 1;
                }
                else
                {
                    Paths[1] -= 1;
                    if(Paths[1] == 0)
                    {
                        LIYangMing.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            case 13:
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

            
            default:
                break;
                
        }
    }

    private void ballChanger(int order, bool a)
    {
        switch (order)
        {
            case 0:
                ball_arm.SetActive(a);
                break;
            case 13:
                ball.SetActive(a);
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

    public void PathChanger(int path, bool active)
    {
        if(active)
        {
            Paths[path] += 1;
        }
        else
        {
            Paths[path] -= 1;
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
