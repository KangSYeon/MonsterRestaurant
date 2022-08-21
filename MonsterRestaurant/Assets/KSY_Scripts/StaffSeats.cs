using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffSeats : MonoBehaviour
{
    DataTable data;


    GameObject WaitingStaffPrefab;
    public GameObject StaffSlot1; //임시 배치한 직원 뜨게 하는 곳
    public GameObject StaffSlot2;
    public GameObject StaffSlot3;
    GameObject StaffSlotInstance;

    // Start is called before the first frame update
    void Start()
    {
        data = DataTable.GetData;
    }

    public void StaffSeat(int _staffNum) //몇번째 스태프를 선택하는지 받아와서 리스트에 추가하는 함수
    {
        if (data._staffs[_staffNum]._state.ToString() != "Call") //선택한 직원이 호출중이 아니라면
        {
            data.Selected[1] = _staffNum; //선택리스트에 추가

            WaitingStaffPrefab = Resources.Load<GameObject>($"Prefabs/PopUp/Staff{_staffNum}"); //이걸로 나중에 switch문 없애기...


            StaffSlotInstance = Instantiate(WaitingStaffPrefab) as GameObject;

            if (data.nowTable == 1)
            {
                StaffSlotInstance.transform.SetParent(StaffSlot1.transform, false);
            }
            else if (data.nowTable == 2)
            {
                StaffSlotInstance.transform.SetParent(StaffSlot2.transform, false);
            }
            else
            {
                StaffSlotInstance.transform.SetParent(StaffSlot3.transform, false);
            }


            WaitingStaffPrefab = null;
        }
        else
            Debug.Log("이미 호출중인 직원입니다.");
    }
}
