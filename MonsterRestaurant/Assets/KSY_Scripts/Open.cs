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

    GameObject WaitingMonsterPrefab;
    public GameObject MonsterSlot; //�ӽ� ��ġ�� ���� �߰� �ϴ� ��
    GameObject MonsterSlotInstance;

    GameObject WaitingStaffPrefab;
    public GameObject StaffSlot; //�ӽ� ��ġ�� ���� �߰� �ϴ� ��
    GameObject StaffSlotInstance;

    public GameObject PickSeats; //���Լ��� ��ư Ȱ��ȭ��

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
        //���� ���� �ð� ��������.
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
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/��������_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster1Prefab");
                break;
            case 2:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����ȣ_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster2Prefab");
                break;
            case 3:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/�ٸ�����_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster3Prefab");
                break;
            case 4:
                MonsterBubble = Resources.Load<GameObject>("Prefabs/Monster/����_Bubble");
                MonsterPrefab = Resources.Load<GameObject>("Prefabs/Monster4Prefab");
                break;
        }

        switch (count) //��ġ�� �����ϸ� ��. Rect������ ��ġ�� �����ص� ������ �ʴ� ������ ����.
        {
            case 0:
                Instantiate(MonsterBubble, new Vector2(0f, 0f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(200, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase1.transform);
                Debug.Log("����1");
                break;
            case 1:
                Instantiate(MonsterBubble, new Vector2(0f, 2f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(400, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase2.transform);
                Debug.Log("����2");
                break;
            case 2:
                Instantiate(MonsterBubble, new Vector2(0f, 4f), Quaternion.identity);
                ParentInstance = Instantiate(MonsterPrefab, new Vector3(600, 250, 0), Quaternion.identity) as GameObject;
                ParentInstance.transform.SetParent(SlotBase3.transform);
                Debug.Log("����3");
                break;
        }

        MonsterBubble = null;
        MonsterPrefab = null;

        
    }

    public void MonsterSeats(int _monsterNum) //�����ø��Ϳ��� ���° ��������(_monsterNum) �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�(�����ϴ°���)
    {
        data.Selected[0] = data.WaitingMonster[_monsterNum];//_monsterNum��ȣ�� ���� ���� ��ȣ�� Selected[0]�� �����ϰ���� (Key���� �޾ƿͼ� Value���� ����)
                                                            //prefab �߰��ϱ�

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

    public void StaffSeats(int _staffNum) //���° �������� �����ϴ��� �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�
    {
        if (data._staffs[_staffNum]._state.ToString() != "Call") //������ ������ ȣ������ �ƴ϶��
        {
            data.Selected[1] = _staffNum; //���ø���Ʈ�� �߰�

            WaitingStaffPrefab = Resources.Load<GameObject>($"Prefabs/Staff{_staffNum}Prefab"); //�̰ɷ� ���߿� switch�� ���ֱ�...


            StaffSlotInstance = Instantiate(WaitingStaffPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            StaffSlotInstance.transform.SetParent(StaffSlot.transform);

            WaitingMonsterPrefab = null;
        }
        else
            Debug.Log("�̹� ȣ������ �����Դϴ�.");

        
    }

    public void DishSeats(int _dishNum) //���° �丮�� �����ϴ��� �޾ƿͼ� ����Ʈ�� �߰��ϴ� �Լ�
    {
        if (true)//�丮�� �رݵ� ���¶��
        {
            if (data._dishes[data.Selected[2]]._cost < money.gold) //������ ���� ��뺸�� ���ٸ�
            {
                data.Selected[2] = _dishNum;
            }
            else
                Debug.Log("���� �����մϴ�.");
        }
        else
            Debug.Log("�丮�� �رݵ��� �ʾҽ��ϴ�.");

        //prefab �߰��ϱ�
        //�丮 ��ġ �ڵ�
    }

    public void SetSeats(int _tablenum) //��� ������ �Ϸ�Ǹ� Seats�� �߰��ϴ� �Լ�(��ġ�ϱ�)
    {
        for (int i = 0; i < data.Selected.Length - 1; i++) // -1 �� �丮 �����ϸ� �����
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
                
                //���ĵ� �߰��ؼ� �𺧷��ϱ�

                SelectedClear(); //Selected ����Ʈ �ʱ�ȭ

                SoundMan.Play("Sounds/Eggcooking-78272");
            }
        }

    }

    public void SelectedIsNull() //�����׸� null�� �ִ��� Ȯ���ϴ� �Լ�
    {
        for (int i = 0; i < data.Selected.Length - 1; i++)//���� ���� �� ��Ȱ��ȭ
        {
            if (data.Selected[i] != -1) //�����׸��� null�� �ƴ϶��(�� ���õ� ���)
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
