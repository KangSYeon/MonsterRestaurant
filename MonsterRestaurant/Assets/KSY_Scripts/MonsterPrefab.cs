using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterPrefab : MonoBehaviour
{
    DataTable data;

    public int MonsterNum;

    public Text monsterGrade_Text;//���� ���赵
    public GameObject icon; //���� �̹���
    public Text monsterName_Text; //���� �̸� text
    public Text monsterDescription_Text; //���� ���� text
    public Text monsterType_Text; //���� �Ӽ� text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //�ӹ����ð�

    void Start()
    {
        data = DataTable.GetData;
        InitMonsterPrefab(MonsterNum);
    }

    void InitMonsterPrefab(int num)
    {
        string MonsterGrade;

        if (data._monsters[num]._grade == 1)
            MonsterGrade = "��";
        else if (data._monsters[num]._grade == 2)
            MonsterGrade = "�ڡ�";
        else if (data._monsters[num]._grade == 3)
            MonsterGrade = "�ڡڡ�";
        else if (data._monsters[num]._grade == 4)
            MonsterGrade = "�ڡڡڡ�";
        else MonsterGrade = "�ڡڡڡڡ�";

        monsterName_Text.text = data._monsters[num]._name;
        monsterType_Text.text = "[" + data._monsters[num]._property.ToString() + "]";
        monsterfavoriteFood_Text.text = data._dishes[data._monsters[num]._preferDish]._name;
        monsterStayTime_Text.text = data._monsters[num]._time.ToString() + "��";
        monsterGrade_Text.text = MonsterGrade;
        monsterDescription_Text.text = data._monsters[num]._describe.ToString();
    }


}
