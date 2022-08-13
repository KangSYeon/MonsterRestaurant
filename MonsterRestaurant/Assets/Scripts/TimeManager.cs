using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ӷκ�� ������ ��ũ��Ʈ���� �����Ҷ� fadein �ɼ��ְ��ϱ�

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private Text timeText;//��¥�� �ð��� ǥ���� �ؽ�Ʈ
    private FadeManager theFade;

    float timeElapsed = 0;
    float day = 1; //���ӽð��� ��¥ ,1�Ϻ��� ����
    float hour = 7; //���ӽð��� �ð�����


    int timeTohour = 30; // ���ǽð�(30��)�� ���ӽð�(1�ð�)�� ���� 12�ð��ϰ�� 6��

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

        if (hour >= 19)//������ ������ �ڵ������� ���ʿ� ������ �ɵ�
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
            timeElapsed += UnityEngine.Time.deltaTime; //�ʴ����� �ð��� ����. ��ŸŸ������ �����Ӹ��� �ð�����
            
            hour = 7+timeElapsed / timeTohour; //���ӽð��� ������ ��ȯ 

            float textDay = Mathf.Floor(day); //�Ҽ����Ʒ� ����
            float texthour = Mathf.Floor(hour); //�Ҽ����Ʒ� ����

            ClockMove();

            timeText.text = "DAY : " + textDay.ToString("0") + "\nHOUR : " + texthour.ToString("0"); //���ڸ����� ǥ��  
        }
    }

    public void Pause()
    {
        Debug.Log(timeActive);
        timeActive = !timeActive;
    }

    void ClockMove() //�ð� ��ħ(ShortClock), ��ħ(LongClock) �̵�
    {
        ShortClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime); //��ŸŸ�� * 30 / timeTohour
        LongClock.transform.Rotate(0, 0, -UnityEngine.Time.deltaTime * 12f); //��ŸŸ�� * 360 / timeTohour

    }
}