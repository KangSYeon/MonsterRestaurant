using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public static GameManager GetManager { get { return Manager; } }

    public GameObject OpenObj;

    BGMManager BGM;

    public TimeManager TimeManager;


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

        TimeManager = FindObjectOfType<TimeManager>();

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

        StartCoroutine(StateChange(1));

        TimeManager.timeActive = true;
    }
    IEnumerator StateChange(int i)
    {
        BGM.FadeOutMusic();

        yield return new WaitForSeconds(1f);

        BGM.Play(i);
        BGM.FadeInMusic();
    }

    void ChangeStateToRunning()
    {
        gamestate = GameState.Running;
        StartCoroutine(StateChange(2));
    }


    void ChangeStateToClosed ()
    {
        gamestate = GameState.Closed;
        StartCoroutine(StateChange(0));
    }
}
