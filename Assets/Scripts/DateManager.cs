using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateManager : MonoBehaviour
{
    private PlayerCharacterManager PCM;
    private TurnoverManager TM;

    public GameObject panel;
    public GameObject normal;
    public GameObject nightWorking;
    public GameObject rest;
    public GameObject close;
    public GameObject calender1;
    public GameObject calender2;
    public GameObject calender3;
    public GameObject calender4;
    public GameObject calenderFront;
    public GameObject calenderBack;

    public GameObject ok;

    public Text dateText;
    public Text whichWork;
    public Text dDay;

    private int week = 1;

    public int year;
    public int month;
    public int day;
    private int needNextDay = 0;

    public float nextDayTurm = 0.5f;
    private float nextDayCurrTime;

    private bool isActive = true;

    private int[] actionType = new int[4];   //0은 휴식, 1은 일반, 2는 야근

    private void Start()
    {
        PCM = FindObjectOfType<PlayerCharacterManager>();
        TM = FindObjectOfType<TurnoverManager>();

        SwitchActive();
        ok.SetActive(false);
        dateText.text = "Date: " + year.ToString() + "년" + month.ToString() + "월" + day.ToString() + "일";
        nextDayCurrTime = nextDayTurm;

        year = 2021;
        month = 1;
        day = 1;
    }
    public void OnDateButtonClick()
    {
        SwitchActive();
        ok.SetActive(false);
    }

    public void OnCloseButtonClick()
    {
        SwitchActive();
        ok.SetActive(false);
    }

    private void Update()
    {
        if (isActive)
            whichWork.text = week > 4 ? "이 스케쥴대로 진행할까?" : week.ToString() + "번째 주는 어떻게 일할까?";
        else
            whichWork.text = "";


        if(week == 5)
        {
            ok.SetActive(true);
        }

        if (!isActive)
        {
            week = 1;
        }

        if(nextDayCurrTime < nextDayTurm)
        {
            nextDayCurrTime += Time.deltaTime;
        }

        if(needNextDay > 0 && nextDayCurrTime >= nextDayTurm)
        {
            nextDayCurrTime -= nextDayTurm;
            UpdateDate();
            needNextDay--;
        }

        if (!isActive)
            ok.SetActive(false);

        dDay.text = (LeftDDay() > 0) ? "D-" + LeftDDay().ToString() : "D-Day";
    }

    public void OnNightWorkButtonClick()
    {
        if (week != 5)
        {
            actionType[week - 1] = 2;
            string name = "Calender" + week.ToString();
            Image Image = GameObject.Find(name).GetComponent<Image>();
            Image.color = Color.red;
            week++;
        }
    }

    public void OnNormalWorkButtonClick()
    {
        if (week != 5)
        {
            string name = "Calender" + week.ToString();
            Image Image = GameObject.Find(name).GetComponent<Image>();
            Image.color = Color.white;
            actionType[week - 1] = 1;
            week++;
        }
    }

    public void OnRestButtonClick()
    {
        if (week != 5)
        {
            string name = "Calender" + week.ToString();
            Image Image = GameObject.Find(name).GetComponent<Image>();
            Image.color = Color.cyan;
            actionType[week - 1] = 0;
            week++;
        }
    }

    public void OKButtonClick()
    {
        SwitchActive();
        week = 1;

        ok.SetActive(false);

        needNextDay = 30;
    }

    public void SwitchActive()
    {
        
        isActive = !isActive;
        panel.SetActive(isActive);
        normal.SetActive(isActive);
        nightWorking.SetActive(isActive);
        rest.SetActive(isActive);
        close.SetActive(isActive);
        calender1.SetActive(isActive);
        calender2.SetActive(isActive);
        calender3.SetActive(isActive);
        calender4.SetActive(isActive);
        calenderFront.SetActive(isActive);
        calenderBack.SetActive(isActive);

    }

    public void UpdateDate()
    {
        day++;
        if (day > 30)
        {
            day -= 30;
            month++;
        }

        if (month > 12)
        {
            month -= 12;
            year++;
        }

        for (int i = 0; i < 4; i++)
        {
            //여기에 돈이랑 커밋 증가
            if (actionType[i] == 1)
            {
                PCM.playerMonnyText = PCM.playerMonnyText + TM.pay;
                PCM.playerStressLevel = PCM.playerStressLevel + TM.stress;
                PCM.playerCommitAmountText = PCM.playerCommitAmountText + 1;
            }
            else if (actionType[i] == 2)
            {
                PCM.playerMonnyText = PCM.playerMonnyText + TM.pay + 1;
                PCM.playerStressLevel = PCM.playerStressLevel + (TM.stress * 2);
                PCM.playerCommitAmountText = PCM.playerCommitAmountText + 1;
            }
            else if (actionType[i] == 0)
            {
                PCM.playerMonnyText = PCM.playerMonnyText + 0;
                PCM.playerStressLevel = PCM.playerStressLevel - 1;
            }
        }

        dateText.text = "Date: " + year.ToString() + "년" + month.ToString() + "월" + day.ToString() + "일";
    }

    public int LeftDDay()
    {
        return (2021-year) * 360 + (12 - month) * 30 + (30 - day) + 1;
    }

    public int[] GetActionType()
    {
        return actionType;
        //한달동안 뭐했는지 기록한걸 보내준다
        //1주일 단위로 쉬었으면 0, 그냥 일했으면 1, 야근했으면 2이다
        //aciontType[0] = 1이라면 첫번째 주에는 그냥 일한거다
        //actionType[2] = 0이라면 세번째 주에는 쉰거다.
        //그걸로 알아서 잘 해보셈 ㅅㄱ링
    }

}
