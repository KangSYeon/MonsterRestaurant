using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabPopDestroy : MonoBehaviour
{
    DataTable data;

    GameObject MonsterBubble; //��ǳ��
    GameObject MonsterPrefab; //��ġ��. Prefab���� ������� �־����.
    GameObject ParentInstance; //temp��
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
        if ((data.WaitingMonster.Count < 2) && count == 3) //< 2 �� �������� �� �ѹ��� ����ǵ���.
        {
            for (int i = 0; i < 3; i++)
            {
                DeleteChilds(WaitingMonsterInstance[i]);
                count--;
                Debug.Log(count + "���� Count");

            }

        }
        else if (data.WaitingMonster.Count == 3 && count < 3) //��������
        {
            for (int j = 0; j < 3; j++)
            {
                switch (data.WaitingMonster[j])
                {
                    case 1:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/��������_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster1Prefab");
                        break;
                    case 2:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����ȣ_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster2Prefab");
                        break;
                    case 3:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/�ٸ�����_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster3Prefab");
                        break;
                    case 4:
                        MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����_Bubble");
                        MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster4Prefab");
                        break;
                }


                BubbleInstance = Instantiate(MonsterBubble, new Vector2(0f, 0f + (2f * j)), Quaternion.identity);
                BubbleInstance.transform.SetParent(ParentObjBubble.transform, false);
                ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                ParentInstance.transform.SetParent(WaitingMonsterInstance[j].transform, false);

                count++;

                Debug.Log(WaitingMonsterInstance[j].GetComponentInChildren<Transform>() + "����");

                MonsterBubble = null;
                MonsterPrefab = null;

                Debug.Log(count + "���� Count");
            }

        }
    }

    public void DeleteChilds(GameObject Me)
    {
        // child ���� �θ�� �ڽ��� �Բ� ���� �ȴ�.
        var child = Me.GetComponentsInChildren<Transform>();

        foreach (var iter in child)
        {
            // �θ�(this.gameObject)�� ���� ���� �ʱ� ���� ó��
            if (iter != Me.transform)
            {
                Destroy(iter.gameObject);
                Debug.Log(iter.gameObject + "�� �μ���");
            }
        }
    }
}
