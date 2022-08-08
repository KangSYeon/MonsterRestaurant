using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField]
    float _speed = 5.0f;

    Vector2 _position;
    SpriteRenderer spriteRenderer;
    Animator anim;
    [SerializeField]
    Camera _Camera;

    void Awake()
    {
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

        if ((transform.position.x <= -9.5f) && (transform.position.x >= -11.5))
        {
            Debug.Log("Im in Potal");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _Camera.transform.position = new Vector3(-26f, 0f, -10f);
                _position.x = -26;
                _position.y = -3;
            }
        }

        transform.position = _position;

    }

}
