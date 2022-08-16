using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JumpGameManager : MonoBehaviour
{
    //public GameObject[] NumberImage;
    //public Sprite[] Number;

    public GameObject TimeBar;

    private void Update()
    {
        

        if (!JumpDataManager.Instance.PlayerDie)
        {
            JumpDataManager.Instance.playTimeCurrent -= 1 * Time.deltaTime; // 1초에 1씩만 빼기
            TimeBar.transform.Translate(0.5f * Time.deltaTime, 0, 0);

            // 시간이 다 되면 죽음
            if (JumpDataManager.Instance.playTimeCurrent < 0)
            {
                JumpDataManager.Instance.PlayerDie = true;
                // 배경끄기
            }      
        }
    }

}
