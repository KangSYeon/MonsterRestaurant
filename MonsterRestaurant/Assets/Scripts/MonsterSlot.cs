using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    public Text monsterGrade_Text;//괴물 위험도
    public Image icon; //괴물 이미지
    public Text monsterName_Text; //괴물 이름 text
    public Text monsterDescription_Text; //괴물 설명 text
    public Text monsterType_Text; //괴물 속성 text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //머무를시간

    public void AddMonster(Monster _monster) //괴물 추가
    {
        for (int i = 0; i < _monster.monsterGrade; i++)
        {
            monsterGrade_Text.text = monsterGrade_Text.text + "★";
        }
        monsterName_Text.text = _monster.monsterName;
        icon.sprite = _monster.monsterIcon;
        monsterDescription_Text.text = _monster.monsterDescription;
        monsterType_Text.text = _monster.monsterType;
        monsterfavoriteFood_Text.text = "선호하는음식 \n" + _monster.favoriteFood;
        monsterStayTime_Text.text = string.Format("머무르는 시간 \n{0}초",_monster.monsterStayTime);
    }


    public void RemoveMonster() //괴물 제거
    {
        monsterGrade_Text.text = "";
        monsterName_Text.text = "";
        monsterDescription_Text.text = "";
        monsterType_Text.text = "";
        monsterfavoriteFood_Text.text = "";
        icon.sprite = null;
        monsterStayTime_Text.text = "";
    }
}
