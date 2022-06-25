using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvenienceManager : MonoBehaviour
{

    PlayerCharacterManager PCM;

    public GameObject panel;
    public GameObject upgradeButton;
    public GameObject closeButton;

    public PlayerCharacterManager pc;

    public PriceManager pm;

    public Text upgradeText;

    public bool isActive = false;

    private string[] drinkName = { "핫식스","몬스터", "몬스터 울트라 시트라"};
    public int drinkLevel = 0;
    public int drinkTier = 0;
    private uint price;

    private void Start()
    {
        PCM = FindObjectOfType<PlayerCharacterManager>();
        price = pm.GetPrice();
    }

    public void OnConvenienceButtonClick()
    {
        isActive = !isActive;
    }

    public void OnUpgradeButtonClick()
    {
        if(PCM.playerMonnyText - price < 0) {
            return;
        }

        else if (drinkTier != 2)
        {
            if (!(drinkTier >= 1 && drinkLevel >= 15))
            {
                drinkLevel++;
            }

            if (drinkLevel >= 15 && drinkTier != 1)
            {
                drinkLevel = 0;
                drinkTier = 1;
            }

            if (drinkLevel >= 15 && drinkTier == 1)
            {
                drinkTier = 2;
            }
        }

        PCM.playerMonnyText = (int)(PCM.playerMonnyText - price);
        price = pm.Expensiver(price);

        pc.playerMaxStressLevel += 10;
    }

    public void OnCloseButtonClick()
    {
        isActive = !isActive;
    }

    public void Update()
    {
        SetConvenience();
        string text;

        if (drinkTier == 2)
            text = drinkName[drinkTier].ToString() + "\n최대 레벨입니다.";
        else
            text = drinkName[drinkTier].ToString() + "+" + drinkLevel.ToString() + "\nUpgrade: " + price.ToString();

        upgradeText.text = text;
    }

    public void SetConvenience()
    {
        panel.SetActive(isActive);
        upgradeButton.SetActive(isActive);
        closeButton.SetActive(isActive);

    }
}
