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
        //// 점수 띄우기
        //// 100의 단위
        //int temp = JumpDataManager.Instance.score / 100;
        //NumberImage[0].GetComponent<Image>().sprite = Number[temp];
        //// 10의 단위. 0~99까지 계산
        //int temp2 = JumpDataManager.Instance.score % 100;
        //// 그걸 다시 0~9까지
        //temp2 = temp2 / 10;
        //NumberImage[1].GetComponent<Image>().sprite = Number[temp2];
        //// 1의 단위
        //int temp3 = JumpDataManager.Instance.score % 10;
        //NumberImage[2].GetComponent<Image>().sprite = Number[temp3];

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1초에 1씩만 빼기
            // 시간이 다 되면 죽음
            if(JumpDataManager.Instance.playTimeCurrent < 0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                // 배경끄기
            }      
        }
    }

}
