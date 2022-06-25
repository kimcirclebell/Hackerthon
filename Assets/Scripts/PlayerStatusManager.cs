using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    PlayerCharacterManager PCM;

    public Text haveMonnyText;
    public Text stressLevelText;
    public Text nowConpanyText;
    public Text commitAmountText;

    public Text monnyTextImage;
    public Text commitAmountTextImage;

    void Start()
    {
        PCM = FindObjectOfType<PlayerCharacterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        haveMonnyText.text = "보유 자산: " + PCM.playerMonnyText + " 만원";
        stressLevelText.text = "피로도: " + PCM.playerStressLevel + "/" + PCM.playerMaxStressLevel;
        nowConpanyText.text = "현재 회사: " + PCM.playerNowCompanyText;
        commitAmountText.text = "현재 커밋 수: " + PCM.playerCommitAmountText;

        monnyTextImage.text = PCM.playerMonnyText + "만원";
        commitAmountTextImage.text = PCM.playerCommitAmountText + "커밋";
    }
}
