using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public void addHeart()
    {
        if (JumpDataManager.Instance.heart == 1)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(false);
            Heart3.SetActive(false);
        }
        else
        {
            Heart1.SetActive(false);
        }
        if (JumpDataManager.Instance.heart ==2)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(false);
        }
        if (JumpDataManager.Instance.heart >= 3)
        {
            Heart1.SetActive(true);
            Heart2.SetActive(true);
            Heart3.SetActive(true);
        }
    }


}
