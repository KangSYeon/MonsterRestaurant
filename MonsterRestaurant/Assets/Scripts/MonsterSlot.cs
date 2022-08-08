using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterSlot : MonoBehaviour
{
    public Image icon; //±«¹° ÀÌ¹ÌÁö
    public Text monsterName_Text; //±«¹° ÀÌ¸§ text
    public Text monsterDescription_Text; //±«¹° ¼³¸í text
    public Text monsterType_Text; //±«¹° ¼Ó¼º text
    public Text monsterfavoriteFood_Text;
    public Text monsterStayTime_Text; //¸Ó¹«¸¦½Ã°£
    

    public void AddMonster(Monster _monster) //±«¹° Ãß°¡
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

    public void RemoveMonster() //±«¹° Á¦°Å
    {
        monsterName_Text.text = "";
        monsterDescription_Text.text = "";
        monsterType_Text.text = "";
        monsterfavoriteFood_Text.text = "";
        monsterStayTime_Text.text = "";
        icon.sprite = null;
    }
}
