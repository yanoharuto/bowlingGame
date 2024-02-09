using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMove : MonoBehaviour
{
    const float speed = 11.3f;
    float z;
    private void Start()
    {
        z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        z -= speed;
        Vector3 s = transform.position;
        s.z = z;
        transform.position = s;
        if (z <= -5000)
        {
            z = 5000;
            s.z = z;
            transform.position = s;
        }
    }
}
