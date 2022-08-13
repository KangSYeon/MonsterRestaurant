using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    public Text monsterGrade_Text;//���� ���赵
    public Image icon; //���� �̹���
    public Text monsterName_Text; //���� �̸� text
    public Text monsterDescription_Text; //���� ���� text
    public Text monsterType_Text; //���� �Ӽ� text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //�ӹ����ð�

    public void AddMonster(Monster _monster) //���� �߰�
    {
        for (int i = 0; i < _monster.monsterGrade; i++)
        {
            monsterGrade_Text.text = monsterGrade_Text.text + "��";
        }
        monsterName_Text.text = _monster.monsterName;
        icon.sprite = _monster.monsterIcon;
        monsterDescription_Text.text = _monster.monsterDescription;
        monsterType_Text.text = _monster.monsterType;
        monsterfavoriteFood_Text.text = "��ȣ�ϴ����� \n" + _monster.favoriteFood;
        monsterStayTime_Text.text = string.Format("�ӹ����� �ð� \n{0}��",_monster.monsterStayTime);
    }


    public void RemoveMonster() //���� ����
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
