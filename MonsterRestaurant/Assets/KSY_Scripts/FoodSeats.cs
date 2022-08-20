using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSeats : MonoBehaviour
{
    DataTable data;
    Money money;

    GameObject WaitingFoodPrefab;
    public GameObject FoodSlot1; //임시 배치한 직원 뜨게 하는 곳
    public GameObject FoodSlot2;
    public GameObject FoodSlot3;
    GameObject FoodSlotInstance;

    // Start is called before the first frame update
    void Start()
    {
        data = DataTable.GetData;
        money = Money.GetMoney;
    }

    public void DishSeat(int _dishNum) //몇번째 요리를 선택하는지 받아와서 리스트에 추가하는 함수
    {
        //if (data._dishes[_dishNum].IsTrue)//요리가 해금된 상태라면
        //{
            //if (data._dishes[_dishNum]._cost < money.gold) //소지한 돈이 비용보다 많다면
            //{
                data.Selected[2] = _dishNum;
                WaitingFoodPrefab = Resources.Load<GameObject>($"Prefabs/PopUp/Food{_dishNum}Prefab"); //이걸로 나중에 switch문 없애기...

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
                //Debug.Log("돈이 부족합니다.");
        //}
        //else
            //Debug.Log("요리가 해금되지 않았습니다.");

        //prefab 뜨게하기
        //요리 배치 코드
    }
}
