using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterManager : MonoBehaviour
{
    public float playerStressLevel = 0.0f;
    public float playerMaxStressLevel = 50.0f;

    public int playerMonnyText = 0;
    public float playerStressLevelText = 0.0f;
    public string playerNowCompanyText;
    public int playerCommitAmountText = 0;

    void Update()
    {
        playerStressLevelText = playerStressLevel;
        if (playerStressLevel < 0)
            playerStressLevel = 0;

        if (playerStressLevel >= playerMaxStressLevel)
        {
            SceneManager.LoadScene("StressEnd");
        }
    }
}
