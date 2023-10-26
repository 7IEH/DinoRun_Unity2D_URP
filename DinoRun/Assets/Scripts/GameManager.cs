using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstacleObjects = new GameObject[4];
    public GameObject[] skyObjects = new GameObject[5];
    public GameObject[] noonObjects = new GameObject[5];
    public GameObject[] nightObjects = new GameObject[5];
    
    public float mSpeed = 1;
    public float Score = 0;
    public float mTemp = 0;
    public float mCurBackgrounds = 0;

    // Update is called once per frame
    void Update()
    {
        // 점수 및 스피드 시스템
        Score += Time.deltaTime * 2;
        mTemp += Time.deltaTime * 2;
        mSpeed = Score / 20;

        // 장애물 오브젝트 스크롤링
        for(int i=0;i<4;i++)
        {
            obstacleObjects[i].GetComponent<Transform>().Translate(Vector3.left*Time.deltaTime * mSpeed);
            if (obstacleObjects[i].GetComponent<Transform>().position.x <= -10)
            {
                Debug.Log("들어옴");
                int randIndex = Random.Range(0, 2);

                Vector3 vector3 = obstacleObjects[i].transform.position;
                vector3.x = 10;
                obstacleObjects[i].GetComponent<Transform>().transform.position = vector3;
                if(randIndex == 0)
                {
                    obstacleObjects[i].SetActive(false);
                }
                else
                {
                    obstacleObjects[i].SetActive(true);
                }
            }
        }
    }
    void LateUpdate()
    {
        // 점수 확인 후 배경 변경
        if (mTemp > 100)
        {
            if (mCurBackgrounds == 0)
            {
                mCurBackgrounds = 1;
                mTemp = 0;
                for (int i = 0; i < 5; i++)
                {
                    noonObjects[i].SetActive(true);
                    skyObjects[i].SetActive(false);
                }
            }
            else if (mCurBackgrounds == 1)
            {
                mCurBackgrounds = 2;
                mTemp = 0;
                for (int i = 0; i < 5; i++)
                {
                    nightObjects[i].SetActive(true);
                    noonObjects[i].SetActive(false);
                }
            }
            else
            {
                mCurBackgrounds = 0;
                mTemp = 0;
                for (int i = 0; i < 5; i++)
                {
                    skyObjects[i].SetActive(true);
                    noonObjects[i].SetActive(false);
                }
            }
        }
    }
}
