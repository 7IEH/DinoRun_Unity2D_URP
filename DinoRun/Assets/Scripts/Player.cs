using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
//using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    public enum eType
    {
        Idle
        , Move
        , None
    }

    public int Speed;
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
            case eType.Move:
                Move();
                break;
            case eType.None:
                break;
        }
    }

    void Idle()
    {
        float MoveX = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            MoveX -= Time.deltaTime * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveX += Time.deltaTime * Speed;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!mJump)
            {
                Type = eType.Move;
            }
        }

        transform.Translate(new Vector3(MoveX, 0, 0));
    }
    void Move()
    {
        Debug.Log("JUMP");
        rigidbody.AddForce(transform.up * 300f);
        Type = eType.Idle;
        mJump = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        mJump = false;
    }   
}
