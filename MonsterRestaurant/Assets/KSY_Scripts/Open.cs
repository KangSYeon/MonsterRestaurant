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

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot; //임시 배치한 몬스터 뜨게 하는 곳
    GameObject MonsterSlotInstance;

    GameObject WaitingStaffPrefab;
    public GameObject StaffSlot; //임시 배치한 직원 뜨게 하는 곳
    GameObject StaffSlotInstance;

    public GameObject PickSeats; //가게선택 버튼 활성화용

    int count = 0;

    bool selectedIsNull = true;

    public static SoundManager SoundMan;
    public static SoundManager GetSound { get { return SoundMan; } }

    void Start()
    {
        Debug.Log("Awake");

        data = DataTable.GetData;
        money = Money.GetMoney;

        data.WaitingMonster = new List<int>();
        data.Seats = new Dictionary<int, int[]>();

        AddWaitingMonster();

        PickSeats.SetActive(true);

    }

    private void Update()
    {
        //영업 종료 시간 전까지만.
        if(count < 2)
        {
            AddWaitingMonster();
            SoundMan.Play("Sounds/Doorbell2-6450");
        }

    }

    public void AddWaitingMonster()
    {

        int MonsterNum;

        MonsterNum = Random.Range(1, 5);

        /*for(int i = 1; i <=3; i++)
            if (WaitingMonster.ContainsKey(i))
                count = i - 1;*/

        count = data.WaitingMonster.Count;

        data.WaitingMonster.Add(MonsterNum);

        Debug.Log(count);

        switch (MonsterNum)
        {
            case 1:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/빨간구두_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster1Prefab");
                break;
            case 2:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/구미호_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster2Prefab");
                break;
            case 3:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/바리공주_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster3Prefab");
                break;
            case 4:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/좀비_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster4Prefab");
                break;
        }

        switch (count) //위치만 조정하면 됨. Rect에서의 위치가 조정해도 변하지 않는 문제가 있음.
        {
            case 0:
                Instantiate(MonsterBubble, new Vector2(0f, 0f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(200, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase1.transform);
                Debug.Log("생성1");
                break;
            case 1:
                Instantiate(MonsterBubble, new Vector2(0f, 2f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(400, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase2.transform);
                Debug.Log("생성2");
                break;
            case 2:
                Instantiate(MonsterBubble, new Vector2(0f, 4f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(600, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase3.transform);
                Debug.Log("생성3");
                break;
        }

        MonsterBubble = null;
        MonsterPrefab = null;

        
    }

    public void MonsterSeats(int _monsterNum) //웨이팅몬스터에서 몇번째 몬스터인지(_monsterNum) 받아와서 리스트에 추가하는 함수(선택하는곳에)
    {
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum번호에 앉은 몬스터 번호를 Selected[0]에 저장하고싶은 (Key값을 받아와서 Value값을 저장)
                                                            //prefab 뜨게하기

        switch (data.Selected[0])
        {
            case 1:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster1Prefab");
                break;
            case 2:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster2Prefab");
                break;
            case 3:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster3Prefab");
                break;
            case 4:
                WaitingMonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster4Prefab");
                break;
        }

        MonsterSlotInstance = Instantiate(WaitingMonsterPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        MonsterSlotInstance.transform.SetParent(MonsterSlot.transform);

        WaitingMonsterPrefab = null;
    }

    public void StaffSeats(int _staffNum) //몇번째 스태프를 선택하는지 받아와서 리스트에 추가하는 함수
    {
        if (data._staffs[_staffNum]._state.ToString() != "Call") //선택한 직원이 호출중이 아니라면
        {
            data.Selected[1] = _staffNum; //선택리스트에 추가

            WaitingStaffPrefab = Resources.Load<GameObject>($"Prefabs/Staff{_staffNum}Prefab"); //이걸로 나중에 switch문 없애기...


            StaffSlotInstance = Instantiate(WaitingStaffPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            StaffSlotInstance.transform.SetParent(StaffSlot.transform);

            WaitingMonsterPrefab = null;
        }
        else
            Debug.Log("이미 호출중인 직원입니다.");

        
    }

    public void DishSeats(int _dishNum) //몇번째 요리를 선택하는지 받아와서 리스트에 추가하는 함수
    {
        if (true)//요리가 해금된 상태라면
        {
            if (data._dishes[data.Selected[2]]._cost < money.gold) //소지한 돈이 비용보다 많다면
            {
                data.Selected[2] = _dishNum;
            }
            else
                Debug.Log("돈이 부족합니다.");
        }
        else
            Debug.Log("요리가 해금되지 않았습니다.");

        //prefab 뜨게하기
        //요리 배치 코드
    }

    public void SetSeats(int _tablenum) //모든 선택이 완료되면 Seats에 추가하는 함수(배치하기)
    {
        for (int i = 0; i < data.Selected.Length - 1; i++) // -1 은 요리 구현하면 지우기
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
                    EatingInstance.transform.SetParent(Floor2.transform);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(-5.3f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform);
                }
                else if (_tablenum == 1)
                {
                    EatingInstance = Instantiate(data._monsters[data.Selected[_tablenum]].eating, new Vector2(-1f, -1.75f), Quaternion.identity) as GameObject;
                    EatingInstance.transform.SetParent(Floor2.transform);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(2.0f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform);
                }
                else
                {
                    EatingInstance = Instantiate(data._monsters[data.Selected[_tablenum]].eating, new Vector2(6.2f, -1.75f), Quaternion.identity) as GameObject;
                    EatingInstance.transform.SetParent(Floor2.transform);
                    EatingInstance2 = Instantiate(data._staffs[data.Selected[_tablenum]].eating, new Vector2(9.1f, -2.7f), Quaternion.identity) as GameObject;
                    EatingInstance2.transform.SetParent(Floor2.transform);
                }
                
                //음식도 추가해서 디벨롭하기

                SelectedClear(); //Selected 리스트 초기화

                SoundMan.Play("Sounds/Eggcooking-78272");
            }
        }

    }

    public void SelectedIsNull() //선택항목에 null이 있는지 확인하는 함수
    {
        for (int i = 0; i < data.Selected.Length - 1; i++)//음식 구현 후 비활성화
        {
            if (data.Selected[i] != -1) //선택항목이 null이 아니라면(다 선택된 경우)
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
