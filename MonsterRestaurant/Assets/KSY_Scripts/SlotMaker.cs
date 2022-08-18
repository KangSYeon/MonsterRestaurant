using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMaker : MonoBehaviour
{
    DataTable data;
    #region Staff
    GameObject StaffInfo;


    Text staffGrade_text; //직원 등급 텍스트
    Text staffName_text; //직원 이름 텍스트
    Text staffAttributeType_text; //직원 속성 텍스트
    Text staffState_text; //직원 상태 텍스트

    Image turbidityGauge; //탁기 게이지 이미지
    Text turbidityText; //탁기 표시하는 텍스트

    public void Awake()
    {
        data = DataTable.GetData;
    }
    public void MakeStaffSlot(int num)
    {
        //DataTable data = DataTable.GetData;
        Debug.Log(data._staffs[num]._name);

        //Instantiate(StaffInfo, new Vector2(0, 0), default, GameObject.Find("Canvas").transform);

        //staffName_text.text = data._staffs[num]._name;
        //staffName_text = Instantiate(staffName_text, new Vector2(0, 0), default, GameObject.Find("Canvas").transform);
        //staffName_text.transform.SetParent(StaffInfo.transform, false);
    }

    #endregion
}
