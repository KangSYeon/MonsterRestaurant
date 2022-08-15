using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataManager : MonoBehaviour
{
    // 새로운 변수 접근 방식 
    static JumpDataManager instance;
    // 사망 판단
    public bool PlayerDie = false;
    // 게임 플레이 타임
    public float playTimeCurrent = 10f;
    public float playTimeMax = 10f;
    public static JumpDataManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
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

    // 실제 스코어 저장할 곳 
    public int score = 0;
}
