using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 가림막없애기 : MonoBehaviour
{
   
    {

        GameObject ForDestroy;        //삭제할 오브젝트 선언



        void Start()

        {

            ForDestroy = GameObject.Find("Stage Canvas");        //삭제할 오브젝트 참조.

            Destroy(ForDestroy);                         //삭제, 파괴 함수 Destroy에 오브젝트 이름 참조.

        }

    }
    
}
