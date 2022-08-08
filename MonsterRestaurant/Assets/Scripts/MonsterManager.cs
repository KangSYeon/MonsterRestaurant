using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���� ��� �����ٶ� 4�� ��� �������� �����ؾ���
//������� ������ ����Ʈ�� �߰��ϰ� ���������ϰ� �ؾ���
//���̶� ù��������(��������) �����ϰ� List ��ĭ�� ����..?�׷��κ� �����غ����ҵ�..

public class MonsterManager : MonoBehaviour
{
    private MonsterSlot[] slots;

    private List<Monster> WaitMonsterList;
    private List<Monster> AllMonsterList;
    private List<Monster> ShowMonsterList;

    public Transform tf;

    private int count = 0;
    private bool tableEmpty;


    void Start()
    {
        WaitMonsterList = new List<Monster>(2);
        AllMonsterList = new List<Monster>();
        ShowMonsterList = new List<Monster>();

        slots = tf.GetComponentsInChildren<MonsterSlot>();

        //������
        AllMonsterList.Add(new Monster(1,"����1","����1����", "��ȭ", "����1"));
        AllMonsterList.Add(new Monster(2, "����2", "����2����", "�Ǳ�", "����2"));
        AllMonsterList.Add(new Monster(3, "����3", "����3����", "��ȭ", "����3"));
        AllMonsterList.Add(new Monster(4, "����4", "����4����", "�߼�", "����4"));

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
/*
    public void ShowWaitMonster()
    {
        ShowMonsterList.Clear();
        RemoveSlot();

        for (int i = 0; i < WaitMonsterList.Count; i++)
        {           
            ShowMonsterList.Add(WaitMonsterList[i]);           
        }

        for (int i = 0; i< ShowMonsterList.Count;i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].AddMonster(ShowMonsterList[i]);
            count++;
        }
    }*/
    /*
    void Update()
    {
        if (count == 4)
            tableEmpty = false;        
        else
            tableEmpty = true;

        if (tableEmpty)
        {
            int ranMonster = Random.Range(0, 4); //��� ���� ������ŭ ����
            int ranTime = Random.Range(0, 120); //�ӹ��� �ð� ����
            //������� ��������Ʈ�� �߰��ϴ� �Լ�
        }
    }*/
}
