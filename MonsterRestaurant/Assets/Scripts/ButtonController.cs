using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class ButtonController : MonoBehaviour
{
    public void Stages_down()
    {
        SceneManager.LoadScene("스테이지 선택");
    }
}
