using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTable : MonoBehaviour
{
    #region Enum : Property+State
    public enum Property
    {
        Wild,
        Fairytale,
        Myth,
        Devil
    }

    public enum State
    {
        Rest,
        Call,
        Stanby
    }
    #endregion
    public static DataTable Data;
    public static DataTable GetData { get { return Data; } }

    public List<int> WaitingMonster;
    public int[] Selected;
    public Dictionary<int, int[]> Seats;

    public int nowTable = 0;

    void Awake()
    {
        Data = this;
        Debug.Log("AwakeTable");
        InitData();
        Debug.Log(monster1._name);
    }

    #region Class : Monster+Staff+Dish
    public class Monster
    {
        public string _name;
        public Object sprite;
        public Object eating;
        //public Object bubble;
        public Property _property;
        public int _grade;
        public int _preferDish;
        public int _time;
        public string _describe;
    }

    public Dictionary<int, Monster> _monsters = new Dictionary<int, Monster>();

    public class Staff
    {
        public string _name;
        public Object sprite;
        public Object eating;
        public Object sleeping;
        public Property _property;
        public int _grade;
        public int _turbidity;
        public State _state;

    }

    public Dictionary<int, Staff> _staffs = new Dictionary<int, Staff>();

    public class Dish
    {
        public string _name;
        public GameObject sprite;
        public Property _property;
        public int _cost;
        public int _price;
        public bool IsTrue;
    }

    public Dictionary<int, Dish> _dishes = new Dictionary<int, Dish>();
    #endregion

    #region ClassDeclare
    public Monster monster1 = new Monster();
    public Monster monster2 = new Monster();
    public Monster monster3 = new Monster();
    public Monster monster4 = new Monster();

    public Staff staff1 = new Staff();
    public Staff staff2 = new Staff();
    public Staff staff3 = new Staff();
    public Staff staff4 = new Staff();

    public Dish dish1 = new Dish();
    public Dish dish2 = new Dish();
    public Dish dish3 = new Dish();
    public Dish dish4 = new Dish();
    #endregion

    //데이터 초기화(초기의 Raw 데이터로 초기화)
    public void InitData()
    {
        Selected = new int[3];

        Selected[0] = -1;
        Selected[1] = -1;
        Selected[2] = -1;

        Debug.Log("TestInitData");
        //변화된 값을 일자가 지날 때마다 초기화 해주지 않을 경우
        //turbidity를 0으로 초기화하면 안됨

        #region ClassData : Monster

        //Name
        monster1._name = "빨간구두";
        monster2._name = "구미호";
        monster3._name = "바리데기";
        monster4._name = "좀비";

        //기본 sprite
        monster1.sprite = Resources.Load("Prefabs/Monster/빨간구두_base");
        monster2.sprite = Resources.Load("Prefabs/Monster/구미호_base");
        monster3.sprite = Resources.Load("Prefabs/Monster/바리공주_Base");
        monster4.sprite = Resources.Load("Prefabs/Monster/좀비_Base");

        //eating sprite

        monster1.eating = Resources.Load("Prefabs/Monster/빨간구두_Eating");
        monster2.eating = Resources.Load("Prefabs/Monster/구미호_Eating");
        monster3.eating = Resources.Load("Prefabs/Monster/바리공주_Eating");
        monster4.eating = Resources.Load("Prefabs/Monster/좀비_Eating");

        //Property
        monster1._property = Property.Fairytale;
        monster2._property = Property.Wild;
        monster3._property = Property.Myth;
        monster4._property = Property.Devil;

        //grade
        monster1._grade = 5;
        monster2._grade = 3;
        monster3._grade = 4;
        monster4._grade = 1;

        //preferDish

        monster1._preferDish = 1;
        monster2._preferDish = 2;
        monster3._preferDish = 4;
        monster4._preferDish = 3;

        //time

        monster1._time = 40;
        monster2._time = 30;
        monster3._time = 60;
        monster4._time = 50;

        monster1._describe = "발을 자른 죄인";
        monster2._describe = "꼬리가 아홉개인 여우";
        monster3._describe = "저승의 신";
        monster4._describe = "살아있는 시체";

        #endregion

        #region ClassData : Staff

        //Name
        staff1._name = "케빈";
        staff2._name = "키오";
        staff3._name = "웨어";
        staff4._name = "스크";

        //기본 sprite
        staff1.sprite = Resources.Load("Prefabs/Staff/Kevin_Base");
        staff2.sprite = Resources.Load("Prefabs/Staff/Kino_Base");
        staff3.sprite = Resources.Load("Prefabs/Staff/Ware_Base");
        staff4.sprite = Resources.Load("Prefabs/Staff/seku_Base");

        //eating sprite
        staff1.eating = Resources.Load("Prefabs/Staff/Kevin_Call");
        staff2.eating = Resources.Load("Prefabs/Staff/Kino_Call");
        staff3.eating = Resources.Load("Prefabs/Staff/Ware_Call");
        staff4.eating = Resources.Load("Prefabs/Staff/Seku_Call");

        //sleeping sprite
        staff1.sleeping = Resources.Load("Prefabs/Staff/Kevin_Sleeping");
        staff2.sleeping = Resources.Load("Prefabs/Staff/Kino_Sleeping");
        staff3.sleeping = Resources.Load("Prefabs/Staff/Ware_Sleeping");
        staff4.sleeping = Resources.Load("Prefabs/Staff/Seku_Sleeping");


        //property
        staff1._property = Property.Wild;
        staff2._property = Property.Fairytale;
        staff3._property = Property.Myth;
        staff4._property = Property.Devil;

        //grade
        staff1._grade = 3;
        staff2._grade = 3;
        staff3._grade = 3;
        staff4._grade = 3;

        //turbidity
        staff1._turbidity = 0;
        staff2._turbidity = 0;
        staff3._turbidity = 0;
        staff4._turbidity = 0;

        //state
        staff1._state = State.Stanby;
        staff2._state = State.Stanby;
        staff3._state = State.Stanby;
        staff4._state = State.Stanby;

        #endregion

        #region ClassData : Dish
        
        //name
        dish1._name = "칼을 든 천사의 눈알꼬치";
        dish2._name = "차갑게 식어버린 간 스테이크";
        dish3._name = "신선한 해독주스";
        dish4._name = "살풀이꽃전";

        //property
        dish1._property = Property.Fairytale;
        dish2._property = Property.Wild;
        dish3._property = Property.Devil;

        //cost
        dish1._cost = 500;
        dish2._cost = 400;
        dish3._cost = 300;

        //price
        dish1._price = 800;
        dish2._price = 800;
        dish3._price = 700;

        dish1.IsTrue = true;
        dish2.IsTrue = true;
        dish3.IsTrue = false;
        dish4.IsTrue = false;

        #endregion

        //Init 할 때마다 Add하는 게 좋지 않음
        //추후 다른 곳으로 옮길 필요 있음
        #region Dictionary Add

        _monsters.Add(1, monster1);
        _monsters.Add(2, monster2);
        _monsters.Add(3, monster3);
        _monsters.Add(4, monster4);

        _staffs.Add(1, staff1);
        _staffs.Add(2, staff2);
        _staffs.Add(3, staff3);
        _staffs.Add(4, staff4);

        _dishes.Add(1, dish1);
        _dishes.Add(2, dish2);
        _dishes.Add(3, dish3);
        _dishes.Add(4, dish3);

        #endregion
    }


}
