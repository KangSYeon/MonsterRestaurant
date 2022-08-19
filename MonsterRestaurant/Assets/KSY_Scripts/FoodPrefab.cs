using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodPrefab : MonoBehaviour
{
    DataTable data;

    public int FoodNum;

    public GameObject icon; //괴물 이미지
    public Text FoodName_Text; //괴물 이름 text
    public Text FoodDescription_Text; //괴물 설명 text
    public Text FoodType_Text; //괴물 속성 text
    public Text FoodCost_Text;
    public Text FoodPrice_Text; //머무를시간

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
