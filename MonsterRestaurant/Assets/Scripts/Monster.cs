using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster
{
    public int monsterID;//���� ID
    public int monsterGrade;//���� ���赵
    public string monsterName; //���� �̸�
    public string monsterDescription; //���� ����
    public Sprite monsterIcon; //���� �̹���
    public string monsterType; //���� �Ӽ�
    public string favoriteFood; //��ȣ�ϴ�����
    public int monsterStayTime; //�ӹ����� �ð�

    /*
    public enum MonsterType
    {
        Wild, //�߼�
        Fairytale, //��ȭ
        Myth, //��ȭ
        Devil //�Ǳ�
    }*/

    public Monster(int _monsterID, int _monsterGrade, string _monsterName, string _monsterDescription, string _monsterType, string _favoriteFood, int _monsterStayTime)//������
    {
        monsterID = _monsterID;
        monsterGrade = _monsterGrade;
        monsterName = _monsterName;
        monsterDescription = _monsterDescription;
        monsterType = _monsterType;
        favoriteFood = _favoriteFood;
        monsterIcon = Resources.Load("MonsterIcon/" + _monsterID.ToString(), typeof(Sprite)) as Sprite;
        monsterStayTime = _monsterStayTime;
    }

}
