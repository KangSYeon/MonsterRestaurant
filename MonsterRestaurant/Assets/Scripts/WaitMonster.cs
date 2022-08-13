using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//��ġ�ϱ��ư call 1~4 ������ �ش� ���̺� ������ ����� �� �ְ��ؾ���.
// + ��ġ�ϱ� ��ư�̳� ���ļ���, ��������, �������� �Ұ����ϰ� �ؾ���.

//����, ���� �����ϱ� ��ư �������� ���Լ���â�� �ش� ����,������ ���� �߰��ؾ���
// ����� �ؾ����� ���� �������� �κ�.. �׳� �밡�ٷ� 1��������ư-> 1���������� ������ƮȰ��ȭ �̷��� �ؾ�����..
// ���� �����غ��� �� �ȵȴ� ������ �ϳ��ϳ� ���۾��ؾ��ҵ�

// ��������(���, ȣ��, �޽�)�� ���� ��ǥ�� ���̶� ��ġ�� �ؾ��ҵ�


public class WaitMonster : MonoBehaviour
{
    private MonsterSlot[] slots;

    private List<Monster> WaitMonsterList;

    private int count = 0;
    private bool tableEmpty;

    public Transform tf;

    private Image bubbleImage;//��ǳ�� �̹���


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
                WaitMonsterList.Add(new Monster(1, 1, "����1", "����1����", "��ȭ", "����1", 60));
                break;
            case 2:
                WaitMonsterList.Add(new Monster(2, 2, "����2", "����2����", "�Ǳ�", "����2", 80));
                break;
            case 3:
                WaitMonsterList.Add(new Monster(3, 3, "����3", "����3����", "��ȭ", "����3", 100));
                break;
            case 4:
                WaitMonsterList.Add(new Monster(4, 4, "����4", "����4����", "�߼�", "����4", 120));
                break;
        }// ���� �ϳ� Monster ����Ʈ�� �������� ������ �� ������ ������. �������� ����.


        RemoveSlot();

        for (int i = 0; i < WaitMonsterList.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddMonster(WaitMonsterList[i]);
        }

        Debug.Log("������� ���� �߰�");
    }
    
    public void RemoveWaitMonster()
    {
        count--;
        Debug.Log("������� ���� ����");
    }

    public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveMonster();
            slots[i].gameObject.SetActive(false);
        }
    }//���� ���� �ʱ�ȭ

   
}
