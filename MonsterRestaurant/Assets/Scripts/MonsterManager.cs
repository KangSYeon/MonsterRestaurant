using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//대기중인 괴물을 리스트에 추가하고 삭제가능하게 해야함


public class MonsterManager : MonoBehaviour
{
    private MonsterSlot[] slots;

    private List<Monster> WaitMonsterList;
    private List<Monster> AllMonsterList;
    private List<Monster> ShowMonsterList;

    public Transform tf;

    void Start()
    {
        AllMonsterList = new List<Monster>();
        ShowMonsterList = new List<Monster>();

        slots = tf.GetComponentsInChildren<MonsterSlot>();

        //데이터
        AllMonsterList.Add(new Monster(1,1,"괴물1","괴물1설명", "동화", "음식1", 60));
        AllMonsterList.Add(new Monster(2,2, "괴물2", "괴물2설명", "악귀", "음식2", 80));
        AllMonsterList.Add(new Monster(3,3, "괴물3", "괴물3설명", "신화", "음식3", 100));
        AllMonsterList.Add(new Monster(4,4, "괴물4", "괴물4설명", "야성", "음식4", 120));

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

}
