using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSShadow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var t = gameObject.transform.position;
        t.y = 0;
        gameObject.transform.position = t;
    }
}
