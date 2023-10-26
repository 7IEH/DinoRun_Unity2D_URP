using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public GameManager manager;
    public void Update()
    {
        Vector3 transpos = new Vector3(0, 0, 0);
        transpos.x = -1 * manager.mSpeed * Time.deltaTime;
        transform.Translate(transpos);
    }
}
