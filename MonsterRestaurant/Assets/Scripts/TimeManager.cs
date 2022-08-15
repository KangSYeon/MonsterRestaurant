using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//게임로비로 나가는 스크립트에서 시작할때 fadein 될수있게하기

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text DayText;//날짜를 표현할 텍스트
    [SerializeField]
    private Text hourText;

    private FadeManager theFade;

    float timeElapsed = 0;
    float day = 1; //게임시간의 날짜 ,1일부터 시작
    float hour = 7; //게임시간의 시간단위


    int timeTohour = 30; // 현실시간(30초)과 게임시간(1시간)의 배율 12시간일경우 6분

    bool timeActive = true;

    public GameObject ShortClock;
    public GameObject LongClock;



    // Start is called before the first frame update
    void Start()
    {
        theFade = FindObjectOfType<FadeManager>();
    }

    // Update is called once per frame
    void Update()
    {

        StartTime();

        if (hour >= 19)//일차별 데이터 자동저장은 이쪽에 넣으면 될듯
        {
            Pause();
            theFade.FadeOut();//fadeout
            hour = 7;
            day++;
            ShortClock.transform.rotation = Quaternion.identity;
            LongClock.transform.rotation = Quaternion.identity;
            Debug.Log("Hour :"+hour+"Day :"+day);           
        }   
    }

    void StartTime()
    {

        if (timeActive)
        {
            timeElapsed += UnityEngine.Time.deltaTime; //초단위의 시간을 저장. 델타타임으로 프레임마다 시간증가
            
            hour = 7+timeElapsed / timeTohour; //게임시간의 단위로 변환 

            float textDay = Mathf.Floor(day); //소수점아래 버림
            float texthour = Mathf.Floor(hour); //소수점아래 버림 + 12시간 더해줌(원래 19시인데 7시로 계산했기때문에 표기에는 12더해줌)

            ClockMove();

            DayText.text = "DAY : " + textDay.ToString("0");

            if(hour>12) //시간이 12시(표기시각은 24시)
            {
                texthour = Mathf.Floor(hour) - 12;
                hourText.text = "HOUR : " + texthour.ToString("0"); 
            }
            else 
                hourText.text ="HOUR : " + texthour.ToString("0"); //한자리수만 표시  
        }
    }

    public void Pause()
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

    void ClockMove() //시계 시침(ShortClock), 분침(LongClock) 이동
    {
        ShortClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime); //델타타임 * 30 / timeTohour
        LongClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime * 12f); //델타타임 * 360 / timeTohour
    }
}