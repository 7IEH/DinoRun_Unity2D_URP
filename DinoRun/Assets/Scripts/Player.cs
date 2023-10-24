using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public enum eType
    {
        Idle
        , Jump
        , None
    }

    public eType Type;
    Rigidbody2D rigidbody;
    public bool mJump;

    // Start is called before the first frame update
    void Start()
    {
        Type = eType.Idle;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (Type)
        {
            case eType.Idle:
                Idle();
                break;
            case eType.Jump:
                Jump();
                break;
            case eType.None:
                break;
        }
    }

    void Idle()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!mJump)
            {
                Type = eType.Jump;
            }
        }
    }
    void Jump()
    {
        Debug.Log("JUMP");
        rigidbody.AddForce(transform.up * 300f);
        Type = eType.Idle;
        mJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer==7)
        {
            mJump = false;
        }

        if(collision.gameObject.layer==8)
        {
            SceneManager.LoadScene("PlayScene");
        }
    }   
}
