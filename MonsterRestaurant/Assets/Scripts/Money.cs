using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//가진돈이 비용보다 적다면 "돈이 부족합니다"와 같은 팝업창 뜨게하는 부분을 넣을 수도 있지않을까해서(돈이 부족하면 못만들게끔)
//비용<가진돈 일때만 실행될 수 있게 했습니다
        

public class Money : MonoBehaviour
{
    private int gold = 0;
    public Text gold_text;

    public void SetGold(int _gold)
    {
        gold = _gold;
        gold_text.text = gold.ToString();
    }

    public void AddGold(int _price)
    {
        gold += _price;
        SetGold(gold);
    }

    public void SubGold(int _cost)
    {
        if (gold < _cost) //가진돈이 비용보다 적다면 "돈이 부족합니다"와 같은 팝업창 뜨게하기
        {
            //팝업창뜨게하는 부분
            Debug.Log("돈이 부족합니다");
        }
        else
        {
            gold -= _cost;
            SetGold(gold);
        }
    }
}
