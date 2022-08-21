using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    DataTable data;

    public GameObject Floor2; //�θ� obj : Eating
    GameObject EatingInstance; //temp��
    GameObject EatingInstance2;
    //��ġ�ϱ� ��ư Ŭ��
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

        //Debug.Log(data.WaitingMonster[0] + "��" + data.WaitingMonster[1] + "��"+ data.WaitingMonster[2] + "��");
        data.WaitingMonster.Remove(data.Selected[0]);

        //Debug.Log(data.WaitingMonster[0] + "��" + data.WaitingMonster[1] + "��");

        //Debug.Log("���� �¼� Count : " + data.WaitingMonster.Count);

        data._staffs[data.Selected[1]]._state = DataTable.State.Call;

        for (int i = 0; i < data.Selected.Length; i++) // Selected �ʱ�ȭ
        {
            data.Selected[i] = -1; //nullüũ�� -1�� ��
        }
    }

    public void SetSeats(int _tablenum) //��� ������ �Ϸ�Ǹ� Seats�� �߰��ϴ� �Լ�(��ġ�ϱ�)
    {
            //data.Seats.Add(_tablenum, data.Selected); //Seats�� �߰�
                                                      //+ �ؾ���)�����Ӽ�, �����Ӽ� ���� Ź������������

            //money.SubGold(data._dishes[data.Selected[2]]._cost); //�� ����

            //����, ���� ���̺�� �̵�
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

            //���ĵ� �߰��ؼ� �𺧷��ϱ�

            //SelectedClear(); //Selected ����Ʈ �ʱ�ȭ
    }
}
