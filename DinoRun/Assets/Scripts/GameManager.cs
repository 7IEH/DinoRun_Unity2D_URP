using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] obstacleObjects = new GameObject[4];
    public float mSpeed = 1;
    public float Score = 0;

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime;

        mSpeed = Score / 10;

        for(int i=0;i<4;i++)
        {
            obstacleObjects[i].GetComponent<Transform>().Translate(Vector3.left*Time.deltaTime * mSpeed);
            if (obstacleObjects[i].GetComponent<Transform>().position.x <= -10)
            {
                Debug.Log("µé¾î¿È");
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
}
