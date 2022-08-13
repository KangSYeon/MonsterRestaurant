using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//배치하기버튼 call 1~4 누르면 해당 테이블 데이터 저장될 수 있게해야함.
// + 배치하기 버튼이나 음식선택, 괴물선택, 직원선택 불가능하게 해야함.

//직원, 괴물 선택하기 버튼 눌렀을때 가게선택창에 해당 괴물,직원의 정보 뜨게해야함
// ㄴ어떻게 해야할지 감이 안잡히는 부분.. 그냥 노가다로 1번직원버튼-> 1번정보담은 오브젝트활성화 이렇게 해야할지..
// ㄴ더 생각해보고 정 안된다 싶으면 하나하나 수작업해야할듯

// 직원상태(대기, 호출, 휴식)에 따른 좌표는 맵이랑 합치고서 해야할듯


public class WaitMonster : MonoBehaviour
{
    private MonsterSlot[] slots;

    private List<Monster> WaitMonsterList;

    private int count = 0;
    private bool tableEmpty;

    public Transform tf;

    private Image bubbleImage;//말풍선 이미지


    // Start is called before the first frame update
    void Start()
    {
        WaitMonsterList = new List<Monster>(3);

        slots = tf.GetComponentsInChildren<MonsterSlot>();
        
        AddWaitMonster();

    }

    // Update is called once per frame
    void Update()
    {
        if(count == 3) 
        {
            tableEmpty = false; 
        }
        else
        {
            tableEmpty = true;
        }

        if(tableEmpty)
        {
            AddWaitMonster();
        }
    }

    public void AddWaitMonster()
    {
        count++;
        Debug.Log("count : " + count);
        int ran = Random.Range(1, 4);
        switch(ran)
        {
            case 1:
                WaitMonsterList.Add(new Monster(1, 1, "괴물1", "괴물1설명", "동화", "음식1", 60));
                break;
            case 2:
                WaitMonsterList.Add(new Monster(2, 2, "괴물2", "괴물2설명", "악귀", "음식2", 80));
                break;
            case 3:
                WaitMonsterList.Add(new Monster(3, 3, "괴물3", "괴물3설명", "신화", "음식3", 100));
                break;
            case 4:
                WaitMonsterList.Add(new Monster(4, 4, "괴물4", "괴물4설명", "야성", "음식4", 120));
                break;
        }// 어디다 하나 Monster 리스트를 만들어놓고 가져올 수 있으면 좋을듯. 구현에도 용이.


        RemoveSlot();

        for (int i = 0; i < WaitMonsterList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddMonster(WaitMonsterList[i]);
        }

        Debug.Log("대기중인 몬스터 추가");
    }
    
    public void RemoveWaitMonster()
    {
        count--;
        Debug.Log("대기중인 몬스터 제거");
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveMonster();
            slots[i].gameObject.SetActive(false);
        }
    }//몬스터 슬롯 초기화

   
}
