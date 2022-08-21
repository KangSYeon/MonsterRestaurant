using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RecipieOpen : MonoBehaviour
{
    int levelat; //현재 스테이지 번호, 오픈한 스테이지 번호
    public MenuCanvas RecipieNum;

    void Start()
    {
        Button[] stages = RecipieNum.GetComponentsInChildren<Button>();

        levelat = PlayerPrefs.GetInt("levelReached");
        print(levelat);
        for (int i = levelat + 1; i < stages.Length; i++)
        {
            stages[i].interactable = false;
        }
    }

   if (X.activeSelf == true)
        {
            X.SetActive(false);
        }
        else
{
    O.SetActive(false);
    nowStage += 1; //맞으면 다음 스테이지로 자동 이동
    PlayerPrefs.SetInt("levelReached", nowStage); //현재 스테이지를 깨면 스테이지락 해제
    if (nowStage == data.Count) //만약 마지막 스테이지라면 스테이지 선택 창으로 돌아감
    {
        ButtonManager.onClick();
    }
    else this.q(); //그렇지 않다면 다음 스테이지로    
}
}
