using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSeats : MonoBehaviour
{
    DataTable data;
    Money money;

    GameObject WaitingFoodPrefab;
    public GameObject FoodSlot1; //�ӽ� ��ġ�� ���� �߰� �ϴ� ��
    public GameObject FoodSlot2;
    public GameObject FoodSlot3;
    GameObject FoodSlotInstance;

    // Start is called before the first frame update
    void Start()
    {
        data = DataTable.GetData;
        money = Money.GetMoney;
    }

    public void DishSeat(int _dishNum) //���° �丮�� �����ϴ��� �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�
    {
        //if (data._dishes[_dishNum].IsTrue)//�丮�� �رݵ� ���¶��
        //{
            //if (data._dishes[_dishNum]._cost < money.gold) //������ ���� ��뺸�� ���ٸ�
            //{
                data.Selected[2] = _dishNum;
                WaitingFoodPrefab = Resources.Load<GameObject>($"Prefabs/PopUp/Food{_dishNum}Prefab"); //�̰ɷ� ���߿� switch�� ���ֱ�...

                FoodSlotInstance = Instantiate(WaitingFoodPrefab) as GameObject;

            if (data.nowTable == 1)
            {
                FoodSlotInstance.transform.SetParent(FoodSlot1.transform, false);
            }
            else if (data.nowTable == 2)
            {
                FoodSlotInstance.transform.SetParent(FoodSlot2.transform, false);
            }
            else
            {
                FoodSlotInstance.transform.SetParent(FoodSlot3.transform, false);
            }

                WaitingFoodPrefab = null;
           //}
            //else
                //Debug.Log("���� �����մϴ�.");
        //}
        //else
            //Debug.Log("�丮�� �رݵ��� �ʾҽ��ϴ�.");

        //prefab �߰��ϱ�
        //�丮 ��ġ �ڵ�
    }
}
