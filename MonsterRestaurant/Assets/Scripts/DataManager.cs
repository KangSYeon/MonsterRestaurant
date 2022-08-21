using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//�÷��̾� ��ġ���� �߰��ؾ���


public class PlayerData
{
    public float day = 1; //��¥
    public string gameState = "Closed"; //������ ������
    public int gold = 0; //ȭ��
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
        Money.GetComponent<Money>().SaveGold(); //������
        TimeManager.GetComponent<TimeManager>().SaveTime();//�ð�����

        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path, data); //���

        Debug.Log("Save");
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.day);
        Debug.Log("gold :" + nowPlayer.gold);
        Debug.Log("gameState :" + nowPlayer.gameState);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path); //���
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

        Money.GetComponent<Money>().LoadGold();
        TimeManager.GetComponent<TimeManager>().LoadTime();

        Debug.Log("Load");
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.day);
        Debug.Log("gold :" + nowPlayer.gold);
        Debug.Log("gameState :" + nowPlayer.gameState);
    }

    public void DataClear() //����� �����Ͱ��������
    {
        nowPlayer = new PlayerData();
    }

    public void nowData()
    {
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.day);
        Debug.Log("gold :" + nowPlayer.gold);
    }
}