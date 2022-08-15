using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpGameManager : MonoBehaviour
{
    public GameObject[] NumberImage;
    public Sprite[] Number;

    private void Update()
    {
        //// ���� ����
        //// 100�� ����
        //int temp = JumpDataManager.Instance.score / 100;
        //NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        //// 10�� ����. 0~99���� ���
        //int temp2 = JumpDataManager.Instance.score % 100;
        //// �װ� �ٽ� 0~9����
        //temp2 = temp2 / 10;
        //NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        //// 1�� ����
        //int temp3 = JumpDataManager.Instance.score % 10;
        //NumberImage[2].GetComponent<Image>().sprite = Number[temp3];

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1�ʿ� 1���� ����
            // �ð��� �� �Ǹ� ����
            if(JumpDataManager.Instance.playTimeCurrent < 0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                // ������
            }      
        }
    }

}
