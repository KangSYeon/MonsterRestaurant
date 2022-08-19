using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//플레이어 위치저장 추가해야함


public class PlayerData
{
    public float day = 1; //날짜
    public float gameState; //낮인지 밤인지
    public int gold = 0; //화폐
    public string[] items; //소지한 아이템들
    public int recipes;//해금된 레시피
}


public class DataManager : MonoBehaviour
{
    //싱글톤
    public static DataManager instance;
    public PlayerData nowPlayer = new PlayerData();
    public string path; //저장할 경로

    public GameObject Money;
    public GameObject TimeManager;

    private void Awake()
    {
        #region 싱글톤
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
        File.WriteAllText(path, data); //경로
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path); //경로
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);

        Money.GetComponent<Money>().LoadGold();
        TimeManager.GetComponent<TimeManager>().LoadTime();
    }

    public void DataClear() //저장된 데이터가없을경우
    {
        nowPlayer = new PlayerData();
    }

    public void nowData()
    {
        Debug.Log(path);
        Debug.Log("Day :" + nowPlayer.day);
    }
}