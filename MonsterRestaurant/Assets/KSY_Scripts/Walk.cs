using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Walk : MonoBehaviour
{

    public GameManager manager;

    [SerializeField]
    float _speed = 5.0f;

    Vector2 _position;
    SpriteRenderer spriteRenderer;
    Animator anim;
    [SerializeField]
    Camera _Camera;

    void Start()
    {
        manager = GameManager.GetManager;

        _position = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _position += _speed * Time.deltaTime * Vector2.left;
            spriteRenderer.flipX = false;
            anim.SetBool("isWalking", true);

        }
        if (Input.GetKey(KeyCode.D))
        {
            _position += _speed * Time.deltaTime * Vector2.right;
            spriteRenderer.flipX = true;
            anim.SetBool("isWalking", true);
        }

        if (Input.anyKey == false)
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Floor1 Left
            if ((transform.position.x <= -9.5f) && (transform.position.x >= -11.5))
            {
                _Camera.transform.position = new Vector3(-26f, 0f, -10f);
                _position.x = -28;
                _position.y = -4;
            }
            //Floor1 right
            if ((transform.position.x >= 9.5f) && (transform.position.x <= 11.5))
            {
                _Camera.transform.position = new Vector3(26f, 0f, -10f);
                _position.x = 17;
                _position.y = -4;
            }
            //Outside Left
            if((transform.position.x <= -36f) && (transform.position.x >= -38f))
            {
                _Camera.transform.position = new Vector3(-52f, 0f, -10f);
                _position.x = -63;
                _position.y = -4;
            }
            //Outside Middle
            if ((transform.position.x >= -27f) && (transform.position.x <= -25))
            {
                _Camera.transform.position = new Vector3(0f, 0f, -10f);
                _position.x = -9;
                _position.y = -4;

                manager.ChangeStateToOpen();
            }
            //Floor2 right
            if ((transform.position.x >= 36f) && (transform.position.x <= 38f))
            {
                _Camera.transform.position = new Vector3(52f, 0f, -10f);
                _position.x = 43;
                _position.y = -4;
            }
            //Floor2 left
            if ((transform.position.x >= 14f) && (transform.position.x <= 16f))
            {
                _Camera.transform.position = new Vector3(0f, 0f, -10f);
                _position.x = 9;
                _position.y = -4;
            }
            //Floor3 left
            if ((transform.position.x >= 40f) && (transform.position.x <= 42f))
            {
                _Camera.transform.position = new Vector3(26f, 0f, -10f);
                _position.x = 35;
                _position.y = -4;
            }

        }

        transform.position = _position;

    }

}
