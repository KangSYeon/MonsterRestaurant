using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Monster
{
    public int monsterID;//괴물 ID
    public int monsterGrade;//괴물 위험도
    public string monsterName; //괴물 이름
    public string monsterDescription; //괴물 설명
    public Sprite monsterIcon; //괴물 이미지
    public string monsterType; //괴물 속성
    public string favoriteFood; //선호하는음식
    public int monsterStayTime; //머무르는 시간

    /*
    public enum MonsterType
    {
        Wild, //야성
        Fairytale, //동화
        Myth, //신화
        Devil //악귀
    }*/

    public Monster(int _monsterID, int _monsterGrade, string _monsterName, string _monsterDescription, string _monsterType, string _favoriteFood, int _monsterStayTime)//생성자
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
