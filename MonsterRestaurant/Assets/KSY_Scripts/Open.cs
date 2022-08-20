using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    DataTable data;

    Money money; //�ܺν�ũ��Ʈ���� ������������**
    public GameObject button; //��ġ�ϱ��ư�� ���� ������Ʈ
    public Button MonsterSelectButton;
    public Button StaffSelectButton;

    public Button SlotBase1; //�θ� obj : SlotPanel
    public Button SlotBase2; //�θ� obj : SlotPanel
    public Button SlotBase3; //�θ� obj : SlotPanel

    GameObject MonsterBubble; //��ǳ��
    GameObject MonsterPrefab; //��ġ��. Prefab���� ������� �־����.
    GameObject ParentInstance; //temp��

    GameObject Floor2; //�θ� obj : Eating
    GameObject EatingInstance; //temp��
    GameObject EatingInstance2;

    public GameObject PickSeats; //���Լ��� ��ư Ȱ��ȭ��

    public GameObject FoodSlot; //�ر� ����
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
        //���� ���� �ð� ��������.
        if(data.WaitingMonster.Count < 3)
        {
            Invoke("AddWaitingMonster", 2f);
            //�̰� �� �ǰ� ����.
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

            Debug.Log(data.WaitingMonster.Count + "�� �ε������� ����");

            /*
            switch (MonsterNum)
            {
                case 1:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/��������_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster1Prefab");
                    break;
                case 2:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����ȣ_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster2Prefab");
                    break;
                case 3:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/�ٸ�����_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster3Prefab");
                    break;
                case 4:
                    MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����_Bubble");
                    MonsterPrefab = Resources.Load<GameObject>("Prefabs/PopUp/Monster4Prefab");
                    break;
            }

            switch (count) //��ġ�� �����ϸ� ��. Rect������ ��ġ�� �����ص� ������ �ʴ� ������ ����.
            {
                case 0:
                    Instantiate(MonsterBubble, new Vector2(0f, 0f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase1.transform, false);
                    Debug.Log("����1");
                    break;
                case 1:
                    Instantiate(MonsterBubble, new Vector2(0f, 2f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase2.transform, false);
                    Debug.Log("����2");
                    break;
                case 2:
                    Instantiate(MonsterBubble, new Vector2(0f, 4f), Quaternion.identity);
                    ParentInstance = Instantiate(MonsterPrefab) as GameObject;
                    ParentInstance.transform.SetParent(SlotBase3.transform, false);
                    Debug.Log("����3");
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

    //ButtonClick���� ����. �ű⼭ ������ ���.
    public void SetSeats(int _tablenum) //��� ������ �Ϸ�Ǹ� Seats�� �߰��ϴ� �Լ�(��ġ�ϱ�)
    {
            if (selectedIsNull) //�����׸��� null�ϰ��(3���߿� �ϳ��� ���þȵɰ��)
                Debug.Log("������ �Ϸ���� �ʾҽ��ϴ�.");
            else
            {
                data.Seats.Add(_tablenum, data.Selected); //Seats�� �߰�
                //+ �ؾ���)�����Ӽ�, �����Ӽ� ���� Ź������������

                //money.SubGold(data._dishes[data.Selected[2]]._cost); //�� ����
                
                //����, ���� ���̺�� �̵�
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
                
                //���ĵ� �߰��ؼ� �𺧷��ϱ�

                //SelectedClear(); //Selected ����Ʈ �ʱ�ȭ
        }

    }

    public void SelectedIsNull() //�����׸� null�� �ִ��� Ȯ���ϴ� �Լ�
    {
            if ((data.Selected[0] != -1) && (data.Selected[1] != -1) && (data.Selected[2] != -1)) //�����׸��� null�� �ƴ϶��(�� ���õ� ���)
            {
                selectedIsNull = false;
                button.SetActive(true); //��ġ�ϱ� ��ư Ȱ��ȭ
            }
            else
            {
                selectedIsNull = true;
                button.SetActive(false); //��ġ�ϱ� ��ư ��Ȱ��ȭ
            }
    }

    public void SelectedClear() //�����׸� �ʱ�ȭ�ϴ� �Լ�(����Ȯ�� �ȵɽ�)
    {
        for (int i = 0; i < data.Selected.Length; i++)
        {
            data.Selected[i] = -1; //nullüũ�� -1�� ��
        }
    }

    public void ClearSeats(int _tablenum) //Seats���� �����ϴ� �Լ�(�ڸ����� �Լ�)
    {
        //money.AddGold(data._dishes[data.Selected[2]]._price); //������ ȭ��������

        data.Seats.Remove(_tablenum);//Seats���� ����
    }

    //+ �ؾ���) ������ �ӹ����� �ð�(�κ�ũ�� SetSeats���ٰ� �ְų� / �ڷ�ƾ����)

}
