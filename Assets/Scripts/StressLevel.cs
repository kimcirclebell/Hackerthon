using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StressLevel : MonoBehaviour
{
    private PlayerCharacterManager PCM;
    public Slider stressLevel;

    void Start()
    {
        //PCM = GameObject.Find("PlayerCharacterManager").GetComponent<PlayerCharacterManager>();
        PCM = FindObjectOfType<PlayerCharacterManager>();
    }

    void Update()
    {
        stressLevel.value = (float)PCM.playerStressLevel / (float)PCM.playerMaxStressLevel;
    }

}
