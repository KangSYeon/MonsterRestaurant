using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�÷��̾� ��ġ���� �߰��ؾ���


public class PlayerData
{
    public float day = 1; //��¥
    public float gameState; //������ ������
    public int gold = 0; //ȭ��
    public string[] items; //������ �����۵�
    public int recipes;//�رݵ� ������
}


public class DataManager : MonoBehaviour
{
    //�̱���
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();
    public string path; //������ ���

    public GameObject Money;
    public GameObject TimeManager;

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        #endregion

        path = Application.persistentDataPath + "/save";


    }

    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void SaveData()
    {
        Money.GetComponent<Money>().SaveGold();
        TimeManager.GetComponent<TimeManager>().SaveTime();

        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path, data); //���
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path); //���
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

        Money.GetComponent<Money>().LoadGold();
        TimeManager.GetComponent<TimeManager>().LoadTime();
    }

    public void DataClear() //����� �����Ͱ��������
    {
        nowPlayer = new PlayerData();
    }

    public void nowData()
    {
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.day);
    }
}