using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingCounter : MonoBehaviour
{
    [SerializeField] RouteManager rManager;
    [SerializeField] Text t;
    
    // Update is called once per frame
    void Update()
    {
        t.text = rManager.counter + "/" + rManager.allRings;
    }
}
