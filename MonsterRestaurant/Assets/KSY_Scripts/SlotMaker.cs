using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotMaker : MonoBehaviour
{
    DataTable data;
    #region Staff
    GameObject StaffInfo;


    Text staffGrade_text; //���� ��� �ؽ�Ʈ
    Text staffName_text; //���� �̸� �ؽ�Ʈ
    Text staffAttributeType_text; //���� �Ӽ� �ؽ�Ʈ
    Text staffState_text; //���� ���� �ؽ�Ʈ

    Image turbidityGauge; //Ź�� ������ �̹���
    Text turbidityText; //Ź�� ǥ���ϴ� �ؽ�Ʈ

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
