using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var a = transform.eulerAngles;
        a.z = 0;
        transform.eulerAngles = a;
    }
}
