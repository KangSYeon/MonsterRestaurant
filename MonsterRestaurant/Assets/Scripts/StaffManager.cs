using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaffManager : MonoBehaviour
{
    private List<Staff> staffList; //���� ����Ʈ
    
    public Text staffGrade_text; //���� ��� �ؽ�Ʈ
    public Text staffName_text; //���� �̸� �ؽ�Ʈ
    public Text staffAttributeType_text; //���� �Ӽ� �ؽ�Ʈ
    public Text staffSituation_text; //���� ���� �ؽ�Ʈ

    public Image turbidityGauge; //Ź�� ������ �̹���
    public Text turbidityText; //Ź�� ǥ���ϴ� �ؽ�Ʈ
    public float turbidity = 0; //���� Ź�� ��ġ
    public float max_turbidity = 100; //�ִ� Ź�� ��ġ

    public int staff_grade;//�������
    public string staff_name; //�����̸�
    public string staff_attributeType;
    public string staff_Situation = "�����";

    public int amount = 5; //Ź�� ������

    // Start is called before the first frame update
    void Start()
    {
        staffName_text.text = staff_name;
        staffAttributeType_text.text = staff_attributeType;
        staffSituation_text.text = staff_Situation;

        for(int i = 0; i< staff_grade; i++)
        {
            staffGrade_text.text = staffGrade_text.text + "��";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeToStanby() //��������� ���� ����
    {
        staffSituation_text.text = "�����"; //����â�� ���� �ؽ�Ʈ ���������
        //ȣ���ư Ȱ��ȭ(����ư<->ȣ���ư?)
    }

    public void ChangeToRest() //�޽������� ���� ����
    {
        staffSituation_text.text = "�޽���";//����â�� ���� �ؽ�Ʈ �޽�������
        //���������� ���� ������
        //Ź����ȭ
    }

    public void ChangeToCall() //ȣ�������� ���� ����
    {
        staffSituation_text.text = "ȣ����";//����â�� ���� �ؽ�Ʈ ȣ��������
        TurbidityPlus();
        //ȣ���ư ��Ȱ��ȭ(ȣ�������� ����?)
        //�մԼӼ��� ���� Ź�� ��ȭ�� ����
    }


    public void TurbidityPlus(/*string monster_AttributeType, int monster_Danger*/) //ȣ�����϶� Ź������
    {
        
        /*
        if (monster_AttributeType == staff_attributeType) // ������ ������ ���� �Ӽ��ϰ��
            amount = 5 - 3 + monster_Danger - (staff_grade-3);
        else 
            amount = 5 - 3 + monster_Danger - (staff_grade-3);*/

        StartCoroutine(TurbidityPlusCoroutine(2f));
    }
    IEnumerator TurbidityPlusCoroutine(float delayTime)
    {
        turbidity += amount;
        Debug.Log("turbidity :" + turbidity);
        SetTurbidity();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(TurbidityPlusCoroutine(2f));
    }
    

    public void TurbidityMinus() //�޽����϶� Ź�Ⱘ��
    {

    }

    public void SetTurbidity() //Ź���������ȭ
    {  
        if(turbidity >= max_turbidity)//���� Ź�Ⱑ �ִ�ġ�� �ʰ��Ѵٸ�
        {
            turbidity = max_turbidity;
            StopAllCoroutines();
            staff_grade--; //��� �Ѵܰ� �϶�
            //������
        }       
        turbidityText.text = string.Format("{0}/{1}", turbidity, max_turbidity); //��ġǥ��
        turbidityGauge.fillAmount = turbidity / max_turbidity;//������ ��ȭ
    }
}
