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
    public GameObject LI_YangMing;

    public GameObject STFoot_YangMing;
    public GameObject SPFoot_Taiyin;
    public GameObject HTHand_Shaoyin;
    public GameObject Ren;
    

    public TextMeshPro num;

    private int [] Paths = new int[14];

    private bool active_Ren;

    private bool[] bools;

    private bool[] Ren_bools;
    private bool[] LMH_Taiyin_bools;

    private float scale = 1;
    // Start is called before the first frame update


    void Awake()
    {
        bools = new bool[14];
        Ren_bools = new bool[24];
        LMH_Taiyin_bools = new bool[11];
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        for(int i = 0; i < Paths.Length; i ++)
        {
            num.text =i.ToString() + ": " + Paths[i].ToString();
            if(Paths[i] >= 3 && i == 13)
            {
                ballChanger(i,true);
                MaterialChanger(i, true);
            }
            else if(Paths[i] > 2)
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
                bools[i] = false;
            
            }
        }
        
        
        //activeHeart();
        //num.text = "Num is: " + Ren_pins.ToString();
    }

    
    public void MaterialChanger(int order, bool a)
    {

        switch (order)
        {
            case 0:
                if(a)
                {
                    LMH_Taiyin.GetComponent<Renderer>().material = active;
                    
                }
                else
                {
                    
                    
                    if(Paths[0] == 0)
                    {
                        LMH_Taiyin.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;

            case 1:
                if(a)
                {
                    LI_YangMing.GetComponent<Renderer>().material = active;
                    
                }
                else
                {
                    
                    if(Paths[1] == 0)
                    {
                        LI_YangMing.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            case 2:
                if(a)
                {
                    STFoot_YangMing.GetComponent<Renderer>().material = active;
                    
                }
                else
                {
                    
                    if(Paths[1] == 0)
                    {
                        STFoot_YangMing.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            case 3:
                if(a)
                {
                    SPFoot_Taiyin.GetComponent<Renderer>().material = active;
                    
                }
                else
                {
                    
                    if(Paths[1] == 0)
                    {
                        SPFoot_Taiyin.GetComponent<Renderer>().material = inactive;
                    }
                }
                break;
            case 13:
                if(a)
                {
                    Ren.GetComponent<Renderer>().material = active;
                    
                }
                else
                {
                    
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


    

    



    

    

}
