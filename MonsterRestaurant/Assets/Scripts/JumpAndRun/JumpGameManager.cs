using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpGameManager : MonoBehaviour
{
    public GameObject TimeBar;
    public GameObject EndPanel;
    public GameObject SuccessPanel;


    private void Update()
    {       

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1초에 1씩만 빼기
        // 미니플레이어 이동
            TimeBar.transform.Translate(0.5f * Time.deltaTime/9f, 0, 0);

            // 시간이 다 되면 죽음
            if (JumpDataManager.Instance.playTimeCurrent < 0 && JumpDataManager.Instance.heart !=0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                EndPanel.SetActive(false);
                SuccessPanel.SetActive(true);
            }      
        }

        // 만약 플레이어가 죽었다면 EndPanel 켜기
        if(JumpDataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        }

    }

    //다시 시작 버튼용 함수 추가
    public void Restart_Btn()
    {
        //JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        EndPanel.SetActive(false);

    }

    //클리어 버튼용 함수 추가
    public void Success_Btn()
    {
        JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SuccessPanel.SetActive(false);

    }

}
