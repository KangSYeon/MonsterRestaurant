using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    DataTable data;

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot; //임시 배치한 몬스터 뜨게 하는 곳
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

    public void MonsterSeats(int _monsterNum) //웨이팅몬스터에서 몇번째 몬스터인지(_monsterNum) 받아와서 리스트에 추가하는 함수(선택하는곳에)
    {
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum번호에 앉은 몬스터 번호를 Selected[0]에 저장하고싶은 (Key값을 받아와서 Value값을 저장)
                                                            //prefab 뜨게하기

        switch (data.Selected[0])
        {
            case 1:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster1Prefab");
                break;
            case 2:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster2Prefab");
                break;
            case 3:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster3Prefab");
                break;
            case 4:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster4Prefab");
                break;
        }

        MonsterSlotInstance = Instantiate(WaitingMonsterPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        MonsterSlotInstance.transform.SetParent(MonsterSlot.transform);

        WaitingMonsterPrefab = null;
    }
}
