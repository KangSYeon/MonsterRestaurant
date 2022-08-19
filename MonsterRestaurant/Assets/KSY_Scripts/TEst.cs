using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    DataTable data;

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot; //�ӽ� ��ġ�� ���� �߰� �ϴ� ��
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

    public void MonsterSeats(int _monsterNum) //�����ø��Ϳ��� ���° ��������(_monsterNum) �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�(�����ϴ°���)
    {
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum��ȣ�� ���� ���� ��ȣ�� Selected[0]�� �����ϰ���� (Key���� �޾ƿͼ� Value���� ����)
                                                            //prefab �߰��ϱ�

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
