using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableSelection : MonoBehaviour
{
    public Text tableNum;
    public int btnNum;
    DataTable data;

    void Start()
    {
        data = DataTable.GetData;
    }

    //��ư���ڿ� �°� n���¼� �ؽ�Ʈ ����
    public void ChangeTableNum(int btnNum)
    {
        data.nowTable = btnNum;
        tableNum.text = string.Format("{0}��\n�¼�", btnNum);
        Debug.Log(tableNum.text);

    }
}
