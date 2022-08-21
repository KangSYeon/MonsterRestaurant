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
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1�ʿ� 1���� ����
        // �̴��÷��̾� �̵�
            TimeBar.transform.Translate(0.5f * Time.deltaTime/9f, 0, 0);

            // �ð��� �� �Ǹ� ����
            if (JumpDataManager.Instance.playTimeCurrent < 0 && JumpDataManager.Instance.heart !=0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                EndPanel.SetActive(false);
                SuccessPanel.SetActive(true);
            }      
        }

        // ���� �÷��̾ �׾��ٸ� EndPanel �ѱ�
        if(JumpDataManager.Instance.PlayerDie == true)
        {
            EndPanel.SetActive(true);
        }

    }

    //�ٽ� ���� ��ư�� �Լ� �߰�
    public void Restart_Btn()
    {
        //JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        EndPanel.SetActive(false);

    }

    //Ŭ���� ��ư�� �Լ� �߰�
    public void Success_Btn()
    {
        JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;

        SuccessPanel.SetActive(false);

    }

}
