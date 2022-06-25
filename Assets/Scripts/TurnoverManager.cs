using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TurnoverManager : MonoBehaviour
{
    PlayerCharacterManager PCM;
    GameUIManager GUIM;

    public GameObject turnoverPanel;
    public Button upgradeButton;
    public Text upgradeText;

    private int buttonPressesNumber = 0;

    public string playerCompany = "느그 상사";
    public int pay = 1;
    public int stress = 1;
    private int needCommitAmount = 250;

    void Start()
    {
        PCM = FindObjectOfType<PlayerCharacterManager>();
        turnoverPanel.SetActive(false);
        GUIM.playerStatus.SetActive(false);
    }


    void Update()
    {
        PCM.playerNowCompanyText = playerCompany;
        upgradeText.text = "필요한 Commit" + "\n" + needCommitAmount;

        if(buttonPressesNumber >= 3)
        {
            SceneManager.LoadScene("HappyEnd");
        }
    }

    public void UpgradeButton()
    {
        if (buttonPressesNumber == 0 && needCommitAmount < PCM.playerCommitAmountText)
        {
            playerCompany = "주식회사 토마토";
            pay = 4;
            stress = 2;
            needCommitAmount = 700;
            buttonPressesNumber++;
        }

        if (buttonPressesNumber == 1 && needCommitAmount < PCM.playerCommitAmountText)
        {
            playerCompany = "샘송전자";
            pay = 10;
            stress = 4;
            needCommitAmount = 1250;
            buttonPressesNumber++;
        }

        if (buttonPressesNumber == 2 && needCommitAmount < PCM.playerCommitAmountText)
        {
            playerCompany = "잡플래닝";
            pay = 15;
            stress = 7;
            needCommitAmount = 2000;
            buttonPressesNumber++;
        }

        if (buttonPressesNumber == 3 && needCommitAmount < PCM.playerCommitAmountText)
        {
            playerCompany = "게임회사 넥센";
            pay = 400;
            stress = 2;
            needCommitAmount = 1800000;
        }
    }

    public void Commpany()
    {
        turnoverPanel.SetActive(true);
        GUIM.playerStatus.SetActive(false);
    }

    public void ExitCommpany()
    {
        turnoverPanel.SetActive(false);
        GUIM.playerStatus.SetActive(false);
    }
}