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
        public GameObject sprite;
        public Property _property;
        public int _grade;
        public int _preferDish;
        public int _time;
    }

    public Dictionary<int, Monster> _monsters = new Dictionary<int, Monster>();

    public class Staff
    {
        public string _name;
        public GameObject sprite;
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
    #endregion

    //데이터 초기화(초기의 Raw 데이터로 초기화)
    public void InitData()
    {
        Debug.Log("TestInitData");
        //변화된 값을 일자가 지날 때마다 초기화 해주지 않을 경우
        //turbidity를 0으로 초기화하면 안됨

        #region ClassData : Monster

        //Name
        monster1._name = "monster1";
        monster2._name = "monster2";
        monster3._name = "monster3";
        monster4._name = "monster4";

        //Property
        monster1._property = Property.Wild;
        monster2._property = Property.Fairytale;
        monster3._property = Property.Myth;
        monster4._property = Property.Devil;

        //grade
        monster1._grade = 3;
        monster2._grade = 3;
        monster3._grade = 3;
        monster4._grade = 3;

        //turbidity

        monster1._preferDish = 1;
        monster2._preferDish = 2;
        monster3._preferDish = 3;
        monster4._preferDish = 4;

        //time

        monster1._time = 30;
        monster2._time = 45;
        monster3._time = 60;
        monster4._time = 75;

        #endregion

        #region ClassData : Staff

        //Name
        staff1._name = "staff1";
        staff2._name = "staff2";
        staff3._name = "staff3";
        staff4._name = "staff4";

        //property
        staff1._property = Property.Wild;
        staff1._property = Property.Fairytale;
        staff1._property = Property.Myth;
        staff1._property = Property.Devil;

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
        dish1._name = "dish1";
        dish2._name = "dish2";
        dish3._name = "dish3";

        //property
        dish1._property = Property.Wild;
        dish1._property = Property.Fairytale;
        dish1._property = Property.Myth;
        dish1._property = Property.Devil;

        //cost
        dish1._cost = 300;
        dish2._cost = 400;
        dish3._cost = 500;

        //price
        dish1._price = 700;
        dish2._price = 800;
        dish3._price = 900;

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
        _dishes.Add(2, dish1);
        _dishes.Add(3, dish1);

        #endregion
    }


}
