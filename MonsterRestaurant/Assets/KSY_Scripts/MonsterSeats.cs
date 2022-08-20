using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSeats : MonoBehaviour
{
    DataTable data;

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot1;
    public GameObject MonsterSlot2;//임시 배치한 몬스터 뜨게 하는 곳
    public GameObject MonsterSlot3;

    GameObject MonsterSlotInstance;

    // Start is called before the first frame update
    void Awake()
    {
        data = DataTable.GetData;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonsterSeat(int _monsterNum) //웨이팅몬스터에서 몇번째 몬스터인지(_monsterNum) 받아와서 리스트에 추가하는 함수(선택하는곳에)
    {
        //Debug.Log(_monsterNum);
        //Debug.Log(data.WaitingMonster.Count);
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum번호에 앉은 몬스터 번호를 Selected[0]에 저장하고싶은 (Key값을 받아와서 Value값을 저장)
                                                            //prefab 뜨게하기

        switch (data.Selected[0])
        {
            case 1:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Popup/Monster1Prefab");
                break;
            case 2:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Popup/Monster2Prefab");
                break;
            case 3:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Popup/Monster3Prefab");
                break;
            case 4:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Popup/Monster4Prefab");
                break;
        }

        MonsterSlotInstance = Instantiate(WaitingMonsterPrefab) as GameObject;

        if (data.nowTable == 1)
        {
            MonsterSlotInstance.transform.SetParent(MonsterSlot1.transform, false);
        }
        else if (data.nowTable == 2)
        {
            MonsterSlotInstance.transform.SetParent(MonsterSlot2.transform, false);
        }
        else {
            MonsterSlotInstance.transform.SetParent(MonsterSlot3.transform, false);
        }

        Debug.Log(data.Selected[0]);
        Debug.Log("현재 테이블 번호 : " + data.nowTable);

        WaitingMonsterPrefab = null;
    }
}
