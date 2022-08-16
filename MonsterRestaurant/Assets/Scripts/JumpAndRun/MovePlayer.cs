using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float jump = 10f;
    public float jump2 = 12f;

    int jumpCount = 0;

    public void Jump_press()
    {
        if (!JumpDataManager.Instance.PlayerDie)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (jumpCount == 0) // ������ �� ���� �� ��
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump, 0);
                    jumpCount += 1; // ���� Ƚ�� �߰�
                }
                else if(jumpCount == 1)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, jump2, 0);
                }
            }
        }
    }

    // �ٴڰ� �浹 �� (���� �� �����ϸ�) ���� & Block�� �浹 �� ��Ʈ -1 ����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.CompareTo("Land") == 0)
        {
            jumpCount = 0;
        }

        if(collision.gameObject.tag.CompareTo("Block") == 0)
        {
            JumpDataManager.Instance.heart -= 1;
        }
    }

    
}
