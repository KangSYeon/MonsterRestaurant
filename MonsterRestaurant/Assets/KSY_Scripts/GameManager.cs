using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public static GameManager GetManager { get { return Manager; } }

    public static SoundManager SoundMan;
    public static SoundManager GetSound { get { return SoundMan; } }

    public GameObject OpenObj;

    public static GameState gamestate = GameState.Closed;

    void Awake()
    {
        Manager = this;
    }

    public enum GameState
    {
        Closed,
        Open,
        Running
    }

    public void ChangeStateToOpen()
    {
        Debug.Log("»£√‚µ Open");
        gamestate = GameState.Open;
        OpenObj.SetActive(true);
        //Open ∫“∑Øø¿±‚
        //SoundMan.Play("Sounds/π„BGM", SoundManager.Sound.Bgm);
    }

    void ChangeStateToRunning()
    {
        gamestate = GameState.Running;

    }

    void ChangeStateToClosed ()
    {
        gamestate = GameState.Closed;

    }
}
