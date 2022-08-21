using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterPrefab : MonoBehaviour
{
    DataTable data;

    public int MonsterNum;

    public Text monsterGrade_Text;//괴물 위험도
    public GameObject icon; //괴물 이미지
    public Text monsterName_Text; //괴물 이름 text
    public Text monsterDescription_Text; //괴물 설명 text
    public Text monsterType_Text; //괴물 속성 text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //머무를시간

    void Start()
    {
        data = DataTable.GetData;
        InitMonsterPrefab(MonsterNum);
    }

    void InitMonsterPrefab(int num)
    {
        string MonsterGrade;

        if (data._monsters[num]._grade == 1)
            MonsterGrade = "★";
        else if (data._monsters[num]._grade == 2)
            MonsterGrade = "★★";
        else if (data._monsters[num]._grade == 3)
            MonsterGrade = "★★★";
        else if (data._monsters[num]._grade == 4)
            MonsterGrade = "★★★★";
        else MonsterGrade = "★★★★★";

        monsterName_Text.text = data._monsters[num]._name;
        monsterType_Text.text = "[" + data._monsters[num]._property.ToString() + "]";
        monsterfavoriteFood_Text.text = data._dishes[data._monsters[num]._preferDish]._name;
        monsterStayTime_Text.text = data._monsters[num]._time.ToString() + "분";
        monsterGrade_Text.text = MonsterGrade;
        monsterDescription_Text.text = data._monsters[num]._describe.ToString();
    }


}
