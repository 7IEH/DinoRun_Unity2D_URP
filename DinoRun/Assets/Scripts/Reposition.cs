using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
     void LateUpdate()
    {
        if(transform.position.x<=-10)
        {
            transform.Translate(18, 0, 0, Space.Self);
        }
    }
}
