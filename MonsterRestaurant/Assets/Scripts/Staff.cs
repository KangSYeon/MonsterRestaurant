using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff
{

    public string name; //�����̸�
    public string attributeType;//�Ӽ�
    public float turbidity; //Ź��
    public int grade; //���

    /*
    public enum AttributeType //�Ӽ�
    {
        Wild, //�߼�
        Fairytale, //��ȭ
        Myth, //��ȭ
        Devil //�Ǳ�
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


