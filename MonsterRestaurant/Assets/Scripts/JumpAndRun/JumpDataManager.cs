using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataManager : MonoBehaviour
{
    // 새로운 변수 접근 방식 
    static JumpDataManager instance;
    // 사망 판단
    public bool PlayerDie = false;
    // 실제 하트 저장할 곳 
    public int heart = 2;

    // 게임 플레이 타임
    public float playTimeCurrent = 90f;
    public float playTimeMax = 90f;
    public static JumpDataManager Instance
    {
        get
        {
            return instance;
        }

    }
    private void Awake()
    {
        //if(heart == 0)
        //{
        //    PlayerDie = true;
        //}

        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }


}
