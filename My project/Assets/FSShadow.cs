using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSShadow : MonoBehaviour
{
    [SerializeField] Transform gO;
    // Update is called once per frame
    private void FixedUpdate()
    {
        var t = gO.position;
        t.y = -9.5f;
        gameObject.transform.position = t;
        t = Vector3.zero;
        t.y = gO.eulerAngles.y;
        gameObject.transform.eulerAngles= t;    
    }
}
