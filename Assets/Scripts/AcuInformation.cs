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

    string GuanyuanInfo = "Also known as the three exchanges, the next, the second, Dantian, the big middle. Ren Ren. It's three-way, it's a meeting. Small. In the lower abdomen, on the front center, when the lower 3 inches.";
    string GuanyuanFunc = "The main treatment of the disease, wheezing, sperm, wilting, squinting, urination, drenching, urine, urine, urine, urine, urine, months, pain Experience, depression, leakage, abdominal pain, venting, dysentery and urinary tract infections, functional sub-bleeding, sub-bleeding, debilitating, fainting, shock, etc.";

    string ShimenInfo = "It is also called Mingmen, Dantian, Liji and Jinglu. It belongs to Ren pulse. The raising point of Sanjiao. Located in the midline of the abdomen, 2 inches below the umbilicus.";
    string ShimenFunc = "Indications for small abdominal pain, hernia, irregular menstruation, dysmenorrhea, menstruation, diarrhea, dysentery, enuresis, uria, and functional uterine bleeding, urinary retention, hypertension, etc.";
    string QihaiInfo = "It is also called neck, lower blindness and lower air sea. It belongs to Ren pulse. The original point of blindness. In the lower abdomen. On the anterior midline, 1.5 inches below the middle of the umbilicus.";
    string QihaiFunc = "Indications for collapse, convulsion, abdominal pain, diarrhea, irregular menstruation, dysmenorrhea, leakage, belt, spermatorrhea, impotence, enuresis, hernia and urine retention, urinary tract infection, intestinal obstruction, etc., with strong effect.";
    string YinjiaoInfo = "Yin Jiao point is also called Shaoguan and Henghu. It belongs to Ren pulse. Ren pulse, Chong pulse, foot Shaoyin meeting. Yin Jiao point is in the lower abdomen, on the anterior midline, 1 inch below the middle of the umbilicus.";
    string YinjiaoFunc = "It is used for treating navel pain, diarrhea, irregular menstruation, dysmenorrhea, vaginal discharge, postpartum blood dizziness, hernia, edema, intestinal obstruction, functional uterine bleeding, uterine prolapse, etc.";
    string ShenqueInfo = "The acupoints of Shenque, alias the middle of the umbilicus, the acupoints of umbilicus, the acupoint of Qi synthase, the acupoint of Qi she, the acupoint of Qi temple, the acupoint of viewill, and the acupoint of vital ti.";
    string ShenqueFunc = "Main treatment: stroke prostration, limbs convulsion cold, autopsy, wind epilepsy, form exhausted body, abdominal pain around the umbilicus, edema bulging, deanal, ejaculation, constipation, defecation can't help, pentagony, women infertility.";
    string ShuifenInfo = "Also called water splitting, middle conserved. Genu Ren Mai, on the upper abdomen, on the anterior midline, when 1 Cun above the umbilicus.";
    string ShuifenFunc = "Indications for abdominal pain, bowel pain, diarrhea, edema, swelling, and nephritis.";
    string XiawanInfo = "Alias pylori. Genus Ren Mai. Foot Taiyin, Ren Mai will. In the upper abdomen, on the anterior midline, and 2 cm above the umbilicus.";
    string XiawanFunc = "Indications stomachache, abdominal distension, vomiting, nausea, bowel ringing, diarrhea, as well as dyspepsia, acute and chronic gastritis.";
    string JianliInfo = "In the upper abdomen, on the anterior midline, and 3 cm above the umbilicus.";
    string JianliFunc = "Indications: stomachache, vomiting, abdominal distension, abdominal pain, bowel ringing, diarrhea, edema, loss of appetite, and acute, chronic gastritis, etc.";
    string ZhongwanInfo = "Aliases superior, Taicang, and epigwan. Genus Ren Mai. Ren Mai, hand sun and Shaoyang, foot Yang Ming will. Recruitment point of stomach. Baihui Jingzhi Fuhui. In the upper abdomen, on the anterior midline, and 4 cm above the umbilicus.";
    string ZhongwanFunc = "Indications stomachache, vomiting, hiccup, nausea, abdominal pain, abdominal distention, diarrhea, diarrhea, malnutrition, jaundice, edema.";
    string ShangwanInfo = "Alias epigen. Genus Ren Mai. Ren Mai, foot Yang Ming, hand sun will. In the upper abdomen, on the anterior midline, and 5 cm above the umbilicus.";
    string ShangwanFunc = "Indications: stomachache, hiccup, vomiting, nausea, epilepsy, as well as acute and chronic gastritis, peptic ulcer, gastroptosis, esophageal spasm, etc.";
    string JuqueInfo = "In the upper abdomen, on the anterior midline, 6 inches above the navel.";
    string JuqueFunc = "Indications: cardiothoracic pain, epigastric pain, hiccup, nausea, acid swallowing, choking, vomiting, palpitations, amnesia, epilepsy, schizophrenia, neurasthenia, biliary ascariasis, etc.";
    string JiuweiInfo = "It is also called tail pannus. It is on the upper abdomen and the front midline. When the chest sword is combined with the lower part, it is 1 inch.";
    string JiuweiFunc = "Indications cardiodynia, stomachache, nausea, palpitations, epilepsy, schizophrenia, angina pectoris, etc.";
    string ZhongtingInfo = "In the chest, on the current median line, the fifth intercostal space is flat, that is, the junction of chest and sword.";
    string ZhongtingFunc = "Indications: chest and hypochasm fullness, vomiting, hiccups, choking, and angina pectoris.";
    string DhozhongInfo = "The patient can adopt the posture of sitting or lying on his back. The acupoint is located at the midpoint of the connecting line between the two nipples on the midline of the human chest.";
    string DhozhongFunc = "Indications: cough, asthma, chest pain, hiccup, choking, hypolactation, angina pectoris, bronchial asthma, mastitis, etc.";
    string YutangInfo = "Alias Yuying. It belongs to Ren pulse. On the chest, the current median line, the third intercostal space";
    string YutangFunc = "Indications for cough, asthma, chest pain, vomiting, angina pectoris, etc";
     string ZigongInfo = "In the chest, the current median line, the second intercostal space.";
    string ZigongFunc = "Indications cough, asthma, hiccup, chest pain, etc.";
    string HuagaiInfo = "In the chest, the current median line, the first intercostal space. In addition, another theory said that it is 2 inches or 1.6 inches below Xuanji point";
    string HuagaiFunc = "The main treatment of cough, asthma, chest pain, hypochondriac rib pain, arthralgia, pharyngeal swelling";
    string XuanjiInfo = "It belongs to Ren pulse. In the chest, the current median line is 1 inch below the Tiantu cave, and another theory said that it is 1.6 inches below the Tiantu cave";
    string XuanjiFunc = "Indications cough, asthma, chest pain, sore throat, bronchial asthma, bronchitis, esophageal spasm and so on.";
    string TiantuInfo = "Alias Yuhu, Tianqu. It belongs to Ren pulse at the meeting point of Yin dimension and Ren pulse. In the neck, on the current median line, in the center of the superior sternal fossa";
    string TiantuFunc = "Indications: cough, asthma, hemoptysis, laryngeal obstruction, aphonia, vomiting, hiccup, choking, gall, etc.";
   
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
        RenInformation.Add("Zhongji", ZhongjiInfo);
        RenInformation.Add("Guanyuan", GuanyuanInfo);
        RenInformation.Add("Shimen", ShimenInfo);
        RenInformation.Add("Qihai", QihaiInfo);
        RenInformation.Add("Yinjiao", YinjiaoInfo);
        RenInformation.Add("Shenque", ShenqueInfo);
        RenInformation.Add("Shuifen", ShuifenInfo);
        RenInformation.Add("Xiawan", XiawanInfo);
        RenInformation.Add("Jianli", JianliInfo);
        RenInformation.Add("Zhongwan", ZhongwanInfo);
        RenInformation.Add("Shangwan", ShangwanInfo);
        RenInformation.Add("Juque", JuqueInfo);
        RenInformation.Add("Jiuwei", JiuweiInfo);
        RenInformation.Add("Zhongting", ZhongtingInfo);
        RenInformation.Add("Danzhong", DhozhongInfo);
        RenInformation.Add("Yutang", YutangInfo);
        RenInformation.Add("Zigong", ZigongInfo);
        RenInformation.Add("Huagai", HuagaiInfo);
        RenInformation.Add("Xuanji", XuanjiInfo);
        RenInformation.Add("Tiantu", TiantuInfo);
        RenInformation.Add("Lianquan", LianquanInfo);
        RenInformation.Add("Chengjiang", ChengjiangInfo);
        Debug.Log("Add: " + RenInformation.ToString());
        

        RenFunction.Add("Huiyin", huiyinFunc);
        RenFunction.Add("Qugu", QuguFunc);
        RenFunction.Add("Zhongji", ZhongjiFunc);
        RenFunction.Add("Guanyuan", GuanyuanFunc);
        RenFunction.Add("Shimen", ShimenFunc);
        RenFunction.Add("Qihai", QihaiFunc);
        RenFunction.Add("Yinjiao", YinjiaoFunc);
        RenFunction.Add("Shenque", ShenqueFunc);
        RenFunction.Add("Shuifen", ShuifenFunc);
        RenFunction.Add("Xiawan", XiawanFunc);
        RenFunction.Add("Jianli", JianliFunc);
        RenFunction.Add("Zhongwan", ZhongwanFunc);
        RenFunction.Add("Shangwan", ShangwanFunc);
        RenFunction.Add("Juque", JuqueFunc);
        RenFunction.Add("Jiuwei", JiuweiFunc);
        RenFunction.Add("Zhongting", ZhongtingFunc);
        RenFunction.Add("Danzhong", DhozhongFunc);
        RenFunction.Add("Yutang", YutangFunc);
        RenFunction.Add("Zigong", ZigongFunc);
        RenFunction.Add("Huagai", HuagaiFunc);
        RenFunction.Add("Xuanji", XuanjiFunc);
        RenFunction.Add("Tiantu", TiantuFunc);
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
