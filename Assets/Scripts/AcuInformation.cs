using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcuInformation : MonoBehaviour
{
    public TextMeshPro title;
    public TextMeshProUGUI AcuName;
    public TextMeshProUGUI Info;
    public TextMeshProUGUI FuncContent;

    public TextMeshProUGUI content;
    //Dictionary<string, string> LMH_TaiyinInformation = new Dictionary<string, string>();
    //Dictionary<string, string> LMH_TaiyinFunction = new Dictionary<string, string>();
    Dictionary<string, string> RenInformation = new Dictionary<string, string>();
    Dictionary<string, string> RenFunction = new Dictionary<string, string>();
    

    string  huiyinInfo = "Also called as Yin Meeting, " +
                        "locate at the very root of the torso, " +
                        "at the center of the pelvic floor, " +
                        "a half-inch in front of the anus";
    string huiyinFunc = "Rejuvenates the spirit and regulates the two yin. " +
                        "It can cure drowning, suffocation, " +
                        "coma, epilepsy, diarrhea, hemorrhoids.";

    string LianquanInfo = "It is located in the middle of the upper part of the neck, between the lower edge of the mandible and the body of the hyoid bone.";
    string LianquanFunc = "The main treatments include crooked mouth and eyes, tight lips, swollen face, toothache, tooth bleeds, swollen gums, salivation, sores on the mouth and tongue, violent moaning, diminishing thirst and drinking, urinary incontinence, and epilepsy.";

    string ZhongjiInfo = "Also known as Yuquan and Qiyuan. Belongs to Ren Vessel. The meeting of Zusanyin and Renmai. Recruiting points of the bladder. On the lower abdomen, on the front midline, 4 inches below the middle of the umbilicus.";
    string ZhongjiFunc = "Indications for nocturnal emission, impotence, enuresis, lower abdominal pain, irregular menstruation, vaginal bleeding, uterine bleeding, dysmenorrhea, fetal retention, postpartum lochia, vulvar itching, uterine prolapse, pelvic inflammatory disease, urinary retention, urinary incontinence, etc.";

    string GuanyuanInfo = "";
    string GuanyuanFunc = "";

    string ShimenInfo = "";
    string ShimenFunc = "";
    string QihaiInfo = "";
    string QihaiFunc = "";
    string YinjiaoInfo = "";
    string YinjiaoFunc = "";
    string ShenqueInfo = "";
    string ShenqueFunc = "";
    string ShuifenInfo = "";
    string ShuifenFunc = "";
    string XiawanInfo = "";
    string XiawanFunc = "";
    string JianliInfo = "";
    string JianliFunc = "";
    string ZhongwanInfo = "";
    string ZhongwanFunc = "";
    string ShangwanInfo = "";
    string ShangwanFunc = "";

    string QuguInfo = "Also known as Huigu. Belongs to Ren Vessel. "+
                      "Meeting of Ren Meridian and Zu Jueyin. In the lower abdomen, the current midline, at the midpoint of the upper edge of the pubic symphysis";
    string QuguFunc = "Mainly treat lower abdominal pain, "+
                      "irregular menstruation, vaginal discharge, nocturnal emission, impotence, hernia, enuresis, urinary obstruction, etc. ";

    string ChengjiangInfo = "Also known as Tianchi, Suspended Pulp, Suspended Pulp. Belongs to Ren Vessel. Yangming of the hands and feet, the governing channel, and the meeting of the Ren channel. On the face, when the depression in the middle of the chin-labial groove";
    string ChengjiangFunc = "Mainly treat mouth and eyes oblique, swollen face, swollen gums, toothache, salivation, mania, oral ulcers, trigeminal neuralgia, etc.";


    


    // Start is called before the first frame update
    void Awake()
    {
        initializeRen();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void initializeRen()
    {
        RenInformation.Add("Huiyin", huiyinInfo);
        RenInformation.Add("Qugu", QuguInfo);
        RenInformation.Add("Lianquan", LianquanInfo);
        RenInformation.Add("Chengjiang", ChengjiangInfo);

        RenFunction.Add("Huiyin", huiyinFunc);
        RenFunction.Add("Qugu", QuguFunc);
        RenFunction.Add("Lianquan", LianquanFunc);
        RenFunction.Add("Chengjiang", ChengjiangFunc);
    }
    
    public void updateRenPointInfo(string name)
    {
        title.text = "Ren Meridian";
        //content.text = "<size=42><b>" + name + "</b></size>\n\n" + RenInformation[name] + "\n\n<size=42><b>Functions</b></size>\n\n" + RenFunction[name];
        AcuName.text = name;
        Info.text = RenInformation[name];
        FuncContent.text = RenFunction[name];
    }

    public void updateLMHTaiyinPointInfo(string name)
    {
        title.text = "The Lung Meridian Of Hand Taiyin";
    }
    
}
