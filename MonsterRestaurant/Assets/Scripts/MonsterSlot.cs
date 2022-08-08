using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    public Image icon; //���� �̹���
    public Text monsterName_Text; //���� �̸� text
    public Text monsterDescription_Text; //���� ���� text
    public Text monsterType_Text; //���� �Ӽ� text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //�ӹ����ð�
    

    public void AddMonster(Monster _monster) //���� �߰�
    {
        monsterName_Text.text = _monster.monsterName;
        icon.sprite = _monster.monsterIcon;
        monsterDescription_Text.text = _monster.monsterDescription;
        monsterType_Text.text = _monster.monsterType;
        monsterfavoriteFood_Text.text = _monster.favoriteFood;
    }

    public void SetStayTime(Monster _monster , string _stayTime)
    {
        monsterStayTime_Text.text = _stayTime;
    }

    public void RemoveMonster() //���� ����
    {
        monsterName_Text.text = "";
        monsterDescription_Text.text = "";
        monsterType_Text.text = "";
        monsterfavoriteFood_Text.text = "";
        monsterStayTime_Text.text = "";
        icon.sprite = null;
    }
}
