using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//<<<<<<< Updated upstream

public class RecipieOpen : MonoBehaviour
{
    int levelat; //���� �������� ��ȣ, ������ �������� ��ȣ
    public GameObject MenuCanvas;

    void Start()
    {
        Button[] stages = MenuCanvas.GetComponentsInChildren<Button>(); //Button****

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
    nowStage += 1; //������ ���� ���������� �ڵ� �̵�
    PlayerPrefs.SetInt("levelReached", nowStage); //���� ���������� ���� ���������� ����
    if (nowStage == data.Count) //���� ������ ����������� �������� ���� â���� ���ư�
    {
        ButtonManager.onClick();
    }
    else this.q(); //�׷��� �ʴٸ� ���� ����������    
}
}
//>>>>>>> Stashed changes
