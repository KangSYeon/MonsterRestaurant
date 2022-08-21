using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffSeats : MonoBehaviour
{
    DataTable data;


    GameObject WaitingStaffPrefab;
    public GameObject StaffSlot1; //�ӽ� ��ġ�� ���� �߰� �ϴ� ��
    public GameObject StaffSlot2;
    public GameObject StaffSlot3;
    GameObject StaffSlotInstance;

    // Start is called before the first frame update
    void Start()
    {
        data = DataTable.GetData;
    }

    public void StaffSeat(int _staffNum) //���° �������� �����ϴ��� �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�
    {
        if (data._staffs[_staffNum]._state.ToString() != "Call") //������ ������ ȣ������ �ƴ϶��
        {
            data.Selected[1] = _staffNum; //���ø���Ʈ�� �߰�

            WaitingStaffPrefab = Resources.Load<GameObject>($"Prefabs/PopUp/Staff{_staffNum}"); //�̰ɷ� ���߿� switch�� ���ֱ�...


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
            Debug.Log("�̹� ȣ������ �����Դϴ�.");
    }
}
