using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    public void ClickBtn()
    {
        //��ư�� ������ �� ȣ��� �Լ�
        print("��ư Ŭ��");

        //��� Ŭ���� ���ӿ�����Ʈ�� �����ͼ� ����
        GameObject clickObject = EventSystem.current.currentSelectedGameObject;

        //��� Ŭ���� ���ӿ�����Ʈ�� �̸��� ��ư �� ���� ���
        print(clickObject.name + ", " + clickObject.GetComponentInChildren<Text>().text);
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
