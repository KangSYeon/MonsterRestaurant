using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffPrefab : MonoBehaviour
{

    DataTable data;

    public int StaffNum;

    public Text staffName_Text;
    public GameObject staffSprite;
    public Text staffType_Text;
    public Text staffGrade_Text;
    public Text staffTurbidity_Text;
    public Text staffState_Text;

    string staffState;

    void Start()
    {
        data = DataTable.GetData;
        InitStaffPrefab(StaffNum);
    }

    // Update is called once per frame
    void Update()
    {
        staffTurbidity_Text.text = data._staffs[StaffNum]._turbidity.ToString();
        staffState_Text.text = staffState;
    }

    void InitStaffPrefab(int num) 
    {
        string staffGrade;

        if(data._staffs[num]._state.ToString() == "Stanby")
            staffState = "대기중";
        else if (data._staffs[num]._state.ToString() == "Call")
            staffState = "영업중";
        else
            staffState = "휴식중";

        if (data._staffs[num]._grade == 1)
            staffGrade = "★";
        else if (data._staffs[num]._grade == 2)
            staffGrade = "★★";
        else if (data._staffs[num]._grade == 3)
            staffGrade = "★★★";
        else if (data._staffs[num]._grade == 4)
            staffGrade = "★★★★";
        else staffGrade = "★★★★★";


        staffName_Text.text = data._staffs[num]._name;
        staffType_Text.text = data._staffs[num]._property.ToString();
        staffGrade_Text.text = staffGrade;
    }
    
}
