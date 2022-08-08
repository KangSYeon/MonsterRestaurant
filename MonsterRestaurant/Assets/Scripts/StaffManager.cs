using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�޽���, �����, ȣ�����϶� �̹����� ��Ÿ�� ��ġ�� �̹��� �־����



public class StaffManager : MonoBehaviour
{
    public Text staffGrade_text; //���� ��� �ؽ�Ʈ
    public Text staffName_text; //���� �̸� �ؽ�Ʈ
    public Text staffAttributeType_text; //���� �Ӽ� �ؽ�Ʈ
    public Text staffSituation_text; //���� ���� �ؽ�Ʈ

    public GameObject rest;//�޽����϶� ��Ÿ�� ������Ʈ
    public GameObject stanby;//������϶� ��Ÿ�� ������Ʈ
    public GameObject call; //ȣ�����϶� ��Ÿ�� ������Ʈ

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
        StopAllCoroutines();

        stanby.gameObject.SetActive(true); //stanby ������Ʈ�� ����ϴ°�(���ڵѰ�)�ʿ� ��ġ��Ű��
        rest.gameObject.SetActive(false);
        call.gameObject.SetActive(false);

    }

    public void ChangeToRest() //�޽������� ���� ����
    {
        staffSituation_text.text = "�޽���";//����â�� ���� �ؽ�Ʈ �޽�������
        TurbidityMinus();

        rest.gameObject.SetActive(true); //rest ������Ʈ�� ����������ġ��
        stanby.gameObject.SetActive(false);
        call.gameObject.SetActive(false);

    }

    public void ChangeToCall() //ȣ�������� ���� ����
    {
        staffSituation_text.text = "ȣ����";//����â�� ���� �ؽ�Ʈ ȣ��������
        TurbidityPlus();

        call.gameObject.SetActive(true);
        //���̺��ȣ(1~6��)�޾ƿͼ� call ������Ʈ�� ��ġ�� �ű��
        rest.gameObject.SetActive(false);
        stanby.gameObject.SetActive(false);

        //ȣ���ư ��Ȱ��ȭ(ȣ�������� ����?)
        //�մԼӼ��� ���� Ź�� ��ȭ�� ����
    }


    public void TurbidityPlus(/*string monster_AttributeType, int monster_Danger*/) //ȣ�����϶� Ź������
    {
        StopAllCoroutines();
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
        StopAllCoroutines();
        StartCoroutine(TurbidityMinusCoroutine(2f));
    }
    IEnumerator TurbidityMinusCoroutine(float delayTime)
    {
        turbidity -= 10;
        Debug.Log("turbidity :" + turbidity);
        SetTurbidity();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(TurbidityMinusCoroutine(2f));
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
        else if(turbidity <=0) //Ź�Ⱑ 0�̵ȴٸ�
        {
            turbidity = 0;
            StopAllCoroutines();
        }
        

        turbidityText.text = string.Format("{0}/{1}", turbidity, max_turbidity); //��ġǥ��
        turbidityGauge.fillAmount = turbidity / max_turbidity;//������ ��ȭ
    }
}
