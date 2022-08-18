using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public DataTable data;

    public List<int> WaitingMonster;

    public Dictionary<int, int[]> Seats;

    public GameObject SlotBase; //부모 obj : SlotPanel
    GameObject MonsterBubble; //말풍선
    GameObject MonsterPrefab; //배치용. Prefab으로 만들어져 있어야함.
    GameObject ParentInstance; //temp용

    int count = 0;

    void Start()
    {
        Debug.Log("Awake");

        data = DataTable.GetData;
        Debug.Log(data.monster1._name);
        Debug.Log(data._staffs[1]._name);

        WaitingMonster = new List<int>();
        Seats = new Dictionary<int, int[]>();

        AddWaitingMonster();

    }

    private void Update()
    {
        //영업 종료 시간 전까지만.
        if(count < 2)
        {
            AddWaitingMonster();
        }
        
    }

    public void AddWaitingMonster()
    {

        int MonsterNum;

        MonsterNum = Random.Range(1, 4);

        /*for(int i = 1; i <=3; i++)
            if (WaitingMonster.ContainsKey(i))
                count = i - 1;*/

        count = WaitingMonster.Count;

        WaitingMonster.Add(MonsterNum);

        Debug.Log(count);

        switch (MonsterNum)
        {
            case 1:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster1Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster1Prefab");
                break;
            case 2:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster2Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster2Prefab");
                break;
            case 3:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster3Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster3Prefab");
                break;
            case 4:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster4Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster4Prefab");
                break;
        }

        switch (count) //위치만 조정하면 됨. Rect에서의 위치가 조정해도 변하지 않는 문제가 있음.
        {
            case 0:
                Instantiate(MonsterBubble, new Vector2(0f, 0f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(105, -255, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase.transform);
                Debug.Log("생성1");
                break;
            case 1:
                Instantiate(MonsterBubble, new Vector2(0f, 2f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(275, -255, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase.transform);
                Debug.Log("생성2");
                break;
            case 2:
                Instantiate(MonsterBubble, new Vector2(0f, 4f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(445, -255, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase.transform);
                Debug.Log("생성3");
                break;
        }

        MonsterBubble = null;
        MonsterPrefab = null;

    }

    public void MonsterSeats()
    {
        //Waiting Monster을 배치하는 코드
    }

    public void StaffSeats()
    {
        //직원 배치 코드
    }

    public void DishSeats()
    {
        //요리 배치 코드
    }
}
