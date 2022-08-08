using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//휴식중, 대기중, 호출중일때 이미지가 나타날 위치에 이미지 넣어야함



public class StaffManager : MonoBehaviour
{
    public Text staffGrade_text; //직원 등급 텍스트
    public Text staffName_text; //직원 이름 텍스트
    public Text staffAttributeType_text; //직원 속성 텍스트
    public Text staffSituation_text; //직원 상태 텍스트

    public GameObject rest;//휴식중일때 나타날 오브젝트
    public GameObject stanby;//대기중일때 나타날 오브젝트
    public GameObject call; //호출중일때 나타날 오브젝트

    public Image turbidityGauge; //탁기 게이지 이미지
    public Text turbidityText; //탁기 표시하는 텍스트
    public float turbidity = 0; //현재 탁기 수치
    public float max_turbidity = 100; //최대 탁기 수치

    public int staff_grade;//직원등급
    public string staff_name; //직원이름
    public string staff_attributeType;
    public string staff_Situation = "대기중";

    public int amount = 5; //탁기 증가량

    // Start is called before the first frame update
    void Start()
    {
        staffName_text.text = staff_name;
        staffAttributeType_text.text = staff_attributeType;
        staffSituation_text.text = staff_Situation;

        for(int i = 0; i< staff_grade; i++)
        {
            staffGrade_text.text = staffGrade_text.text + "★";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ChangeToStanby() //대기중으로 상태 변경
    {
        staffSituation_text.text = "대기중"; //직원창의 상태 텍스트 대기중으로
        StopAllCoroutines();

        stanby.gameObject.SetActive(true); //stanby 오브젝트를 대기하는곳(의자둘곳)쪽에 위치시키기
        rest.gameObject.SetActive(false);
        call.gameObject.SetActive(false);

    }

    public void ChangeToRest() //휴식중으로 상태 변경
    {
        staffSituation_text.text = "휴식중";//직원창의 상태 텍스트 휴식중으로
        TurbidityMinus();

        rest.gameObject.SetActive(true); //rest 오브젝트를 옥상직원위치로
        stanby.gameObject.SetActive(false);
        call.gameObject.SetActive(false);

    }

    public void ChangeToCall() //호출중으로 상태 변경
    {
        staffSituation_text.text = "호출중";//직원창의 상태 텍스트 호출중으로
        TurbidityPlus();

        call.gameObject.SetActive(true);
        //테이블번호(1~6번)받아와서 call 오브젝트의 위치를 옮기기
        rest.gameObject.SetActive(false);
        stanby.gameObject.SetActive(false);

        //호출버튼 비활성화(호출중으로 변경?)
        //손님속성에 따라 탁기 변화폭 조정
    }


    public void TurbidityPlus(/*string monster_AttributeType, int monster_Danger*/) //호출중일때 탁기증가
    {
        StopAllCoroutines();
        /*
        if (monster_AttributeType == staff_attributeType) // 직원과 괴물이 같은 속성일경우
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
    

    public void TurbidityMinus() //휴식중일때 탁기감소
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

    public void SetTurbidity() //탁기게이지변화
    {  
        if(turbidity >= max_turbidity)//현재 탁기가 최대치를 초과한다면
        {
            turbidity = max_turbidity;
            StopAllCoroutines();
            staff_grade--; //등급 한단계 하락
            //힘듦모션
        }
        else if(turbidity <=0) //탁기가 0이된다면
        {
            turbidity = 0;
            StopAllCoroutines();
        }
        

        turbidityText.text = string.Format("{0}/{1}", turbidity, max_turbidity); //수치표시
        turbidityGauge.fillAmount = turbidity / max_turbidity;//게이지 변화
    }
}
