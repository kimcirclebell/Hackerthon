using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("MainPlayScene");  //여기에 게임 처음 씬 넣기
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
