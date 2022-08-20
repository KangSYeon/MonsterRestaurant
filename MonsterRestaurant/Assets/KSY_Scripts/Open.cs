using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    DataTable data;

    Money money; //외부스크립트에서 정보가져오기**
    public GameObject button; //배치하기버튼을 담은 오브젝트
    public Button MonsterSelectButton;
    public Button StaffSelectButton;

    public Button SlotBase1; //부모 obj : SlotPanel
    public Button SlotBase2; //부모 obj : SlotPanel
    public Button SlotBase3; //부모 obj : SlotPanel

    GameObject MonsterBubble; //말풍선
    GameObject MonsterPrefab; //배치용. Prefab으로 만들어져 있어야함.
    GameObject ParentInstance; //temp용

    GameObject Floor2; //부모 obj : Eating
    GameObject EatingInstance; //temp용
    GameObject EatingInstance2;

    public GameObject PickSeats; //가게선택 버튼 활성화용

    public GameObject FoodSlot; //해금 관련
    GameObject FoodPrefab;
    GameObject FoodSlotInstance;

    int count = 0;

    bool selectedIsNull = true;

    void Start()
    {
        Debug.Log("Awake");

        data = DataTable.GetData;
        money = Money.GetMoney;

        data.WaitingMonster = new List<int>();
        data.Seats = new Dictionary<int, int[]>();

        AddWaitingMonster();
        AddOpenFood();

        PickSeats.SetActive(true);

    }

    void FixedUpdate()
    {
        //영업 종료 시간 전까지만.
        if(data.WaitingMonster.Count < 3)
        {
            Invoke("AddWaitingMonster", 2f);
            //이게 안 되고 있음.
        }

        SelectedIsNull();

    }

    public void AddWaitingMonster()
    {
        if(data.WaitingMonster.Count < 3)
        {
            int MonsterNum;

            MonsterNum = Random.Range(1, 5);

            /*for(int i = 1; i <=3; i++)
                if (WaitingMonster.ContainsKey(i))
                    count = i - 1;*/

            //count = data.WaitingMonster.Count;

            data.WaitingMonster.Add(MonsterNum);

            Debug.Log(data.WaitingMonster.Count + "번 인덱스까지 존재");

            /*
            switch (MonsterNum)
            {
                case 1:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/빨간구두_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster1Prefab");
                    break;
                case 2:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/구미호_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster2Prefab");
                    break;
                case 3:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/바리공주_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster3Prefab");
                    break;
                case 4:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/좀비_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster4Prefab");
                    break;
            }

            switch (count) //위치만 조정하면 됨. Rect에서의 위치가 조정해도 변하지 않는 문제가 있음.
            {
                case 0:
                    Instantiate(MonsterBubble, new Vector2(0f, 0f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase1.transform, false);
                    Debug.Log("생성1");
                    break;
                case 1:
                    Instantiate(MonsterBubble, new Vector2(0f, 2f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase2.transform, false);
                    Debug.Log("생성2");
                    break;
                case 2:
                    Instantiate(MonsterBubble, new Vector2(0f, 4f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase3.transform, false);
                    Debug.Log("생성3");
                    break;
            }

            MonsterBubble = null;
            MonsterPrefab = null;
            */
        }

    }

    public void AddOpenFood()
    {
        if(data.dish3.IsTrue == true)
        {
            FoodPrefab = Resources.Load<GameObject>("Prefabs/Popup/Food3Prefab");
            FoodSlotInstance = Instantiate(FoodPrefab) as GameObject;
            FoodSlotInstance.transform.SetParent(FoodSlot.transform, false);
        }
    }

    //ButtonClick에서 조정. 거기서 실제로 사용.
    public void SetSeats(int _tablenum) //모든 선택이 완료되면 Seats에 추가하는 함수(배치하기)
    {
            if (selectedIsNull) //선택항목이 null일경우(3개중에 하나라도 선택안될경우)
                Debug.Log("선택이 완료되지 않았습니다.");
            else
            {
                data.Seats.Add(_tablenum, data.Selected); //Seats에 추가
                //+ 해야함)괴물속성, 직원속성 비교해 탁기증감폭설정

                //money.SubGold(data._dishes[data.Selected[2]]._cost); //돈 차감
                
                //몬스터, 직원 테이블로 이동
                if(_tablenum == 0)
                {
                    EatingInstance = Instantiate(data._monsters[data.Selected[_tablenum]].eating, new Vector2(-8.2f, -1.75f), Quaternion.identity) as GameObject;
                    EatingInstance.transform.SetParent(Floor2.transform, false);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(-5.3f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform, false);
                }
                else if (_tablenum == 1)
                {
                    EatingInstance = Instantiate(data._monsters[data.Selected[_tablenum]].eating, new Vector2(-1f, -1.75f), Quaternion.identity) as GameObject;
                    EatingInstance.transform.SetParent(Floor2.transform, false);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(2.0f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform, false);
                }
                else
                {
                    EatingInstance = Instantiate(data._monsters[data.Selected[_tablenum]].eating, new Vector2(6.2f, -1.75f), Quaternion.identity) as GameObject;
                    EatingInstance.transform.SetParent(Floor2.transform, false);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(9.1f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform, false);
                }
                
                //음식도 추가해서 디벨롭하기

                //SelectedClear(); //Selected 리스트 초기화
        }

    }

    public void SelectedIsNull() //선택항목에 null이 있는지 확인하는 함수
    {
            if ((data.Selected[0] != -1) && (data.Selected[1] != -1) && (data.Selected[2] != -1)) //선택항목이 null이 아니라면(다 선택된 경우)
            {
                selectedIsNull = false;
                button.SetActive(true); //배치하기 버튼 활성화
            }
            else
            {
                selectedIsNull = true;
                button.SetActive(false); //배치하기 버튼 비활성화
            }
    }

    public void SelectedClear() //선택항목 초기화하는 함수(선택확정 안될시)
    {
        for (int i = 0; i < data.Selected.Length; i++)
        {
            data.Selected[i] = -1; //null체크는 -1로 함
        }
    }

    public void ClearSeats(int _tablenum) //Seats에서 제거하는 함수(자리비우는 함수)
    {
        //money.AddGold(data._dishes[data.Selected[2]]._price); //괴물이 화폐지불함

        data.Seats.Remove(_tablenum);//Seats에서 제거
    }

    //+ 해야함) 괴물이 머무르는 시간(인보크로 SetSeats에다가 넣거나 / 코루틴으로)

}
