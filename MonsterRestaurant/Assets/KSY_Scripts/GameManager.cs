using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public static GameManager GetManager { get { return Manager; } }

    public GameObject OpenObj;

    BGMManager BGM;

    public static GameState gamestate = GameState.Closed;

    void Awake()
    {
        Manager = this;

    }

    void Start()
    {
        BGM = FindObjectOfType<BGMManager>();

        BGM.Play(0);
        BGM.FadeInMusic();
    }

    public enum GameState
    {
        Closed,
        Open,
        Running
    }

    public void ChangeStateToOpen()
    {
        Debug.Log("호출됨Open");
        gamestate = GameState.Open;
        OpenObj.SetActive(true);
        //Open 불러오기

        StartCoroutine(BGMChange(1));
    }
    IEnumerator BGMChange(int i)
    {
        BGM.FadeOutMusic();
        yield return new WaitForSeconds(3f);
        BGM.Play(i);
        BGM.FadeInMusic();
    }

    void ChangeStateToRunning()
    {
        gamestate = GameState.Running;
        StartCoroutine(BGMChange(2));
    }


    void ChangeStateToClosed ()
    {
        gamestate = GameState.Closed;
        StartCoroutine(BGMChange(0));
    }
}
