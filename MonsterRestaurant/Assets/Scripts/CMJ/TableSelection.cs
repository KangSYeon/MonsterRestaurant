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

    //버튼숫자에 맞게 n번좌석 텍스트 변경
    public void ChangeTableNum(int btnNum)
    {
        data.nowTable = btnNum;
        tableNum.text = string.Format("{0}번\n좌석", btnNum);
        Debug.Log(tableNum.text);

    }
}
