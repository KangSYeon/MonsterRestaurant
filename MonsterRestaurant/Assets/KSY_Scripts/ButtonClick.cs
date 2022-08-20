using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    DataTable data;

    public GameObject Floor2; //부모 obj : Eating
    GameObject EatingInstance; //temp용
    GameObject EatingInstance2;
    //배치하기 버튼 클릭
    // Start is called before the first frame update
    void Start()
    {
        data = DataTable.GetData;
    }

    public void Arrangement()
    {
        data.Seats.Add(data.nowTable, data.Selected);

        SetSeats(data.nowTable);

        //Debug.Log(data.Selected[0]);

        //Debug.Log(data.WaitingMonster[0] + "번" + data.WaitingMonster[1] + "번"+ data.WaitingMonster[2] + "번");
        data.WaitingMonster.Remove(data.Selected[0]);

        //Debug.Log(data.WaitingMonster[0] + "번" + data.WaitingMonster[1] + "번");

        //Debug.Log("현재 좌석 Count : " + data.WaitingMonster.Count);

        data._staffs[data.Selected[1]]._state = DataTable.State.Call;

        for (int i = 0; i < data.Selected.Length; i++) // Selected 초기화
        {
            data.Selected[i] = -1; //null체크는 -1로 함
        }
    }

    public void SetSeats(int _tablenum) //모든 선택이 완료되면 Seats에 추가하는 함수(배치하기)
    {
            //data.Seats.Add(_tablenum, data.Selected); //Seats에 추가
                                                      //+ 해야함)괴물속성, 직원속성 비교해 탁기증감폭설정

            //money.SubGold(data._dishes[data.Selected[2]]._cost); //돈 차감

            //몬스터, 직원 테이블로 이동
            if (_tablenum == 1)
            {
                EatingInstance = Instantiate(data._monsters[data.Selected[0]].eating, new Vector2(-8.2f, -1.75f), Quaternion.identity) as GameObject;
                EatingInstance.transform.SetParent(Floor2.transform, false);
                EatingInstance2 = Instantiate(data._staffs[data.Selected[1]].eating, new Vector2(-5.3f, -2.7f), Quaternion.identity) as GameObject;
                EatingInstance2.transform.SetParent(Floor2.transform, false);
            }
            else if (_tablenum == 2)
            {
                EatingInstance = Instantiate(data._monsters[data.Selected[0]].eating, new Vector2(-1f, -1.75f), Quaternion.identity) as GameObject;
                EatingInstance.transform.SetParent(Floor2.transform, false);
                EatingInstance2 = Instantiate(data._staffs[data.Selected[1]].eating, new Vector2(2.0f, -2.7f), Quaternion.identity) as GameObject;
                EatingInstance2.transform.SetParent(Floor2.transform, false);
            }
            else
            {
                EatingInstance = Instantiate(data._monsters[data.Selected[0]].eating, new Vector2(6.2f, -1.75f), Quaternion.identity) as GameObject;
                EatingInstance.transform.SetParent(Floor2.transform, false);
                EatingInstance2 = Instantiate(data._staffs[data.Selected[1]].eating, new Vector2(9.1f, -2.7f), Quaternion.identity) as GameObject;
                EatingInstance2.transform.SetParent(Floor2.transform, false);
            }

            //음식도 추가해서 디벨롭하기

            //SelectedClear(); //Selected 리스트 초기화
    }
}
