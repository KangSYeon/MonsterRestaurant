using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDataManager : MonoBehaviour
{
    // ���ο� ���� ���� ��� 
    static JumpDataManager instance;
    // ��� �Ǵ�
    public bool PlayerDie = false;
    // ���� �÷��� Ÿ��
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

    // ���� ���ھ� ������ �� 
    public int score = 0;
}
