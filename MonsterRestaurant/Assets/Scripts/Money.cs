using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�������� ��뺸�� ���ٸ� "���� �����մϴ�"�� ���� �˾�â �߰��ϴ� �κ��� ���� ���� �����������ؼ�(���� �����ϸ� ������Բ�)
//���<������ �϶��� ����� �� �ְ� �߽��ϴ�
        

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
        if (gold < _cost) //�������� ��뺸�� ���ٸ� "���� �����մϴ�"�� ���� �˾�â �߰��ϱ�
        {
            //�˾�â�߰��ϴ� �κ�
            Debug.Log("���� �����մϴ�");
        }
        else
        {
            gold -= _cost;
            SetGold(gold);
        }
    }
}
