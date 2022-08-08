using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//괴물 목록 보여줄때 4명씩 끊어서 보여지게 수정해야함
//대기중인 괴물을 리스트에 추가하고 삭제가능하게 해야함
//ㄴ이때 첫순서부터(먼저들어온) 삭제하고 List 한칸씩 당기는..?그런부분 생각해봐야할듯..

public class MonsterManager : MonoBehaviour
{
    private MonsterSlot[] slots;

    private List<Monster> WaitMonsterList;
    private List<Monster> AllMonsterList;
    private List<Monster> ShowMonsterList;

    public Transform tf;

    private int count = 0;
    private bool tableEmpty;


    void Start()
    {
        WaitMonsterList = new List<Monster>(2);
        AllMonsterList = new List<Monster>();
        ShowMonsterList = new List<Monster>();

        slots = tf.GetComponentsInChildren<MonsterSlot>();

        //데이터
        AllMonsterList.Add(new Monster(1,"괴물1","괴물1설명", "동화", "음식1"));
        AllMonsterList.Add(new Monster(2, "괴물2", "괴물2설명", "악귀", "음식2"));
        AllMonsterList.Add(new Monster(3, "괴물3", "괴물3설명", "신화", "음식3"));
        AllMonsterList.Add(new Monster(4, "괴물4", "괴물4설명", "야성", "음식4"));

        ShowAllMonster();
    }

    public void RemoveSlot()
    {
        for(int i = 0; i<slots.Length; i++)
        {
            slots[i].RemoveMonster();
            slots[i].gameObject.SetActive(false);
        }
    }//몬스터 슬롯 초기화

    
    public void ShowAllMonster()
    {
        ShowMonsterList.Clear();
        RemoveSlot();
        for(int i = 0; i< AllMonsterList.Count; i++)
        {
            ShowMonsterList.Add(AllMonsterList[i]);         
        }
        
        for (int i = 0; i < ShowMonsterList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddMonster(ShowMonsterList[i]);
        }
    }
/*
    public void ShowWaitMonster()
    {
        ShowMonsterList.Clear();
        RemoveSlot();

        for (int i = 0; i < WaitMonsterList.Count; i++)
        {           
            ShowMonsterList.Add(WaitMonsterList[i]);           
        }

        for (int i = 0; i< ShowMonsterList.Count;i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddMonster(ShowMonsterList[i]);
            count++;
        }
    }*/
    /*
    void Update()
    {
        if (count == 4)
            tableEmpty = false;        
        else
            tableEmpty = true;

        if (tableEmpty)
        {
            int ranMonster = Random.Range(0, 4); //모든 괴물 종류만큼 랜덤
            int ranTime = Random.Range(0, 120); //머무를 시간 랜덤
            //대기중인 괴물리스트에 추가하는 함수
        }
    }*/
}
