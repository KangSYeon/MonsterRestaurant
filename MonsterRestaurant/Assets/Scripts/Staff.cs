using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff
{

    public string name; //직원이름
    public string attributeType;//속성
    public float turbidity; //탁기
    public int grade; //등급

    /*
    public enum AttributeType //속성
    {
        Wild, //야성
        Fairytale, //동화
        Myth, //신화
        Devil //악귀
    }*/

    public Staff(string _name, string _attributeType, float _turbidity, int _grade)
    {
        name = _name;
        attributeType = _attributeType;
        turbidity = _turbidity;
        grade = _grade;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}


