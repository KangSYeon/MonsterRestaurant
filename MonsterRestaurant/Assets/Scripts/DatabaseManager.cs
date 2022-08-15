using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    protected static DatabaseManager instance;

    protected void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }


    protected List<Staff> staffList = new List<Staff>();
    protected List<Monster> MonsterList = new List<Monster>();
}
