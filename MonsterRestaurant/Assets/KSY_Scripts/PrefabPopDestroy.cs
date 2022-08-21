using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPopDestroy : MonoBehaviour
{
    DataTable data;

    GameObject MonsterBubble; //말풍선
    GameObject MonsterPrefab; //배치용. Prefab으로 만들어져 있어야함.
    GameObject ParentInstance; //temp용
    GameObject BubbleInstance;
    int count;

    GameObject[] WaitingMonsterInstance;
    public GameObject ParentObjBubble;

    void Start()
    {
        data = DataTable.GetData;
        WaitingMonsterInstance = new GameObject[3];
        WaitingMonsterInstance[0] = GameObject.Find("WaitPopup").transform.Find("WaitMonsterPopup").transform.Find("Monster Slot 1").gameObject;
        WaitingMonsterInstance[1] = GameObject.Find("WaitPopup").transform.Find("WaitMonsterPopup").transform.Find("Monster Slot 2").gameObject;
        WaitingMonsterInstance[2] = GameObject.Find("WaitPopup").transform.Find("WaitMonsterPopup").transform.Find("Monster Slot 3").gameObject;

        Debug.Log(GameObject.Find("WaitPopup").transform.Find("WaitMonsterPopup").transform.Find("Monster Slot 1").gameObject);
        Debug.Log(WaitingMonsterInstance[0]);
        count = 0;
    }


    void Update()
    {
        if (GameManager.gamestate.ToString() == "Open")
        {
            CheckWaitingMonsterList();
        }

    }

    public void CheckWaitingMonsterList()
    {
        if ((data.WaitingMonster.Count < 2) && count == 3) //< 2 로 떨어졌을 때 한번만 실행되도록.
        {
            for (int i = 0; i < 3; i++)
            {
                DeleteChilds(WaitingMonsterInstance[i]);
                count--;
                Debug.Log(count + "현재 Count");

            }

        }
        else if (data.WaitingMonster.Count == 3 && count < 3) //문제많다
        {
            for (int j = 0; j < 3; j++)
            {
                switch (data.WaitingMonster[j])
                {
                    case 1:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/빨간구두_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster1Prefab");
                        break;
                    case 2:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/구미호_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster2Prefab");
                        break;
                    case 3:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/바리공주_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster3Prefab");
                        break;
                    case 4:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/좀비_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster4Prefab");
                        break;
                }


                BubbleInstance = Instantiate(MonsterBubble, new Vector2(0f, 0f + (2f * j)), Quaternion.identity);
                BubbleInstance.transform.SetParent(ParentObjBubble.transform, false);
                ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                ParentInstance.transform.SetParent(WaitingMonsterInstance[j].transform, false);

                count++;

                Debug.Log(WaitingMonsterInstance[j].GetComponentInChildren<Transform>() + "생성");

                MonsterBubble = null;
                MonsterPrefab = null;

                Debug.Log(count + "현재 Count");
            }

        }
    }

    public void DeleteChilds(GameObject Me)
    {
        // child 에는 부모와 자식이 함께 설정 된다.
        var child = Me.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            // 부모(this.gameObject)는 삭제 하지 않기 위한 처리
            if (iter != Me.transform)
            {
                Destroy(iter.gameObject);
                Debug.Log(iter.gameObject + "가 부서짐");
            }
        }
    }
}
