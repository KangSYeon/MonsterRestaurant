using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster
{
    public int monsterID;//���� ID
    public string monsterName; //���� �̸�
    public string monsterDescription; //���� ����
    public Sprite monsterIcon; //���� �̹���
    public string monsterType; //���� �Ӽ�
    public string favoriteFood; //��ȣ�ϴ�����

    /*
    public enum MonsterType
    {
        Wild, //�߼�
        Fairytale, //��ȭ
        Myth, //��ȭ
        Devil //�Ǳ�
    }*/

    public Monster(int _monsterID, string _monsterName, string _monsterDescription, string _MonsterType, string _favoriteFood)//������
    {
        monsterID = _monsterID;
        monsterName = _monsterName;
        monsterDescription = _monsterDescription;
        monsterType = _MonsterType;
        favoriteFood = _favoriteFood;
        monsterIcon = Resources.Load("MonsterIcon/" + _monsterID.ToString(), typeof(Sprite)) as Sprite;
    }

}
