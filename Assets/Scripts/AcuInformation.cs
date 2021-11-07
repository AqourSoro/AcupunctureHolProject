using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AcuInformation : MonoBehaviour
{
    public TextMeshPro title;

    public TextMeshProUGUI content;
    Dictionary<string, string> RenInformation = new Dictionary<string, string>();
    Dictionary<string, string> RenFunction = new Dictionary<string, string>();

    string huiyinInfo = "Also called as Yin Meeting, " +
                        "locate at the very root of the torso, " +
                        "at the center of the pelvic floor, " +
                        "a half-inch in front of the anus";
    string huiyinFunc = "Rejuvenates the spirit and regulates the two yin. " +
                        "It can cure drowning, suffocation, " +
                        "coma, epilepsy, diarrhea, hemorrhoids.";

    string QuguInfo = "Also known as Huigu. Belongs to Ren Vessel. "+
                      "Meeting of Ren Meridian and Zu Jueyin. In the lower abdomen, the current midline, at the midpoint of the upper edge of the pubic symphysis";
    string QuguFunc = "Mainly treat lower abdominal pain, "+
                      "irregular menstruation, vaginal discharge, nocturnal emission, impotence, hernia, enuresis, urinary obstruction, etc. ";

    string ChengjiangInfo = "Also known as Tianchi, Suspended Pulp, Suspended Pulp. Belongs to Ren Vessel. Yangming of the hands and feet, the governing channel, and the meeting of the Ren channel. On the face, when the depression in the middle of the chin-labial groove";
    string ChengjiangFunc = "Mainly treat mouth and eyes oblique, swollen face, swollen gums, toothache, salivation, mania, oral ulcers, trigeminal neuralgia, etc.";
    


    // Start is called before the first frame update
    void Awake()
    {

        RenInformation.Add("Huiyin", huiyinInfo);
        RenInformation.Add("Qugu", QuguInfo);
        RenInformation.Add("Chengjiang", ChengjiangInfo);

        RenFunction.Add("Huiyin", huiyinFunc);
        RenFunction.Add("Qugu", QuguFunc);
        RenFunction.Add("Chengjiang", ChengjiangFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    
    public void updateRenPointInfo(string name)
    {
        title.text = "Ren Meridian";
        content.text = "<size=42><b>" + name + "</b></size>\n\n" + RenInformation[name] + "\n\n<size=42><b>Functions</b></size>\n\n" + RenFunction[name];
    }
}
