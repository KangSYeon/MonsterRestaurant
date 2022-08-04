using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;

    public void Awake()
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


    public List<Staff> staffList = new List<Staff>();

}
