using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSeats : MonoBehaviour
{
    DataTable data;

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot1;
    public GameObject MonsterSlot2;//�ӽ� ��ġ�� ���� �߰� �ϴ� ��
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

    public void MonsterSeat(int _monsterNum) //�����ø��Ϳ��� ���° ��������(_monsterNum) �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�(�����ϴ°���)
    {
        //Debug.Log(_monsterNum);
        //Debug.Log(data.WaitingMonster.Count);
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum��ȣ�� ���� ���� ��ȣ�� Selected[0]�� �����ϰ���� (Key���� �޾ƿͼ� Value���� ����)
                                                            //prefab �߰��ϱ�

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
        Debug.Log("���� ���̺� ��ȣ : " + data.nowTable);

        WaitingMonsterPrefab = null;
    }
}
