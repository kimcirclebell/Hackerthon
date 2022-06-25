using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public GameObject playerStatus;
    public TurnoverManager TM;

    void Start()
    {
    }

    void Update()
    {
        
    }

    public void MyStatusButtonClick()
    { 
        playerStatus.SetActive(true);
        TM.turnoverPanel.SetActive(false);
    }
    public void MyStatusButtonBackClick()
    {
        playerStatus.SetActive(false);
        TM.turnoverPanel.SetActive(false);
    }
}
