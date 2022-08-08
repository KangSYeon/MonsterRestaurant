using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster
{
    public int monsterID;//괴물 ID
    public string monsterName; //괴물 이름
    public string monsterDescription; //괴물 설명
    public Sprite monsterIcon; //괴물 이미지
    public string monsterType; //괴물 속성
    public string favoriteFood; //선호하는음식

    /*
    public enum MonsterType
    {
        Wild, //야성
        Fairytale, //동화
        Myth, //신화
        Devil //악귀
    }*/

    public Monster(int _monsterID, string _monsterName, string _monsterDescription, string _MonsterType, string _favoriteFood)//생성자
    {
        monsterID = _monsterID;
        monsterName = _monsterName;
        monsterDescription = _monsterDescription;
        monsterType = _MonsterType;
        favoriteFood = _favoriteFood;
        monsterIcon = Resources.Load("MonsterIcon/" + _monsterID.ToString(), typeof(Sprite)) as Sprite;
    }

}
