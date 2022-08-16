using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpGameManager : MonoBehaviour
{
    public GameObject TimeBar;
    public GameObject EndPanel;

    private void Update()
    {       

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1�ʿ� 1���� ����
            TimeBar.transform.Translate(0.5f * Time.deltaTime, 0, 0);

            // �ð��� �� �Ǹ� ����
            if (JumpDataManager.Instance.playTimeCurrent < 0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                // ������
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
        JumpDataManager.Instance.heart = 0;
        JumpDataManager.Instance.PlayerDie = false;
        JumpDataManager.Instance.playTimeCurrent = JumpDataManager.Instance.playTimeMax;
    }

}
