using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPrefab : MonoBehaviour
{
    DataTable data;

    public int FoodNum;

    public GameObject icon; //���� �̹���
    public Text FoodName_Text; //���� �̸� text
    public Text FoodDescription_Text; //���� ���� text
    public Text FoodType_Text; //���� �Ӽ� text
    public Text FoodCost_Text;
    public Text FoodPrice_Text; //�ӹ����ð�

    void Start()
    {
        data = DataTable.GetData;
        InitMonsterPrefab(FoodNum);
    }

    void InitMonsterPrefab(int num)
    {
        FoodName_Text.text = data._dishes[num]._name;
        FoodType_Text.text = data._dishes[num]._property.ToString();
        FoodCost_Text.text = data._dishes[num]._cost.ToString();
        FoodPrice_Text.text = data._dishes[num]._price.ToString();
    }
}
