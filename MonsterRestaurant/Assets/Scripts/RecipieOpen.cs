using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream

public class RecipieOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
=======
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RecipieOpen : MonoBehaviour
{
    int levelat; //���� �������� ��ȣ, ������ �������� ��ȣ
    public GameObject stageNumObject;

    void Start()
    {
        Button[] stages = stageNumObject.GetComponentsInChildren<Button>();

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
>>>>>>> Stashed changes
