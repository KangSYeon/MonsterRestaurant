using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//������� ������ ����Ʈ�� �߰��ϰ� ���������ϰ� �ؾ���


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

        //������
        AllMonsterList.Add(new Monster(1,1,"����1","����1����", "��ȭ", "����1", 60));
        AllMonsterList.Add(new Monster(2,2, "����2", "����2����", "�Ǳ�", "����2", 80));
        AllMonsterList.Add(new Monster(3,3, "����3", "����3����", "��ȭ", "����3", 100));
        AllMonsterList.Add(new Monster(4,4, "����4", "����4����", "�߼�", "����4", 120));

        ShowAllMonster();
    }

    public void RemoveSlot()
    {
        for(int i = 0; i<slots.Length; i++)
        {
            slots[i].RemoveMonster();
            slots[i].gameObject.SetActive(false);
        }
    }//���� ���� �ʱ�ȭ

    
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
