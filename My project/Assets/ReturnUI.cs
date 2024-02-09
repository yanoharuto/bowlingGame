using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnUI : MonoBehaviour
{
    [SerializeField] Text t;
    // Start is called before the first frame update
    void Start()
    {
        t.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        var p= GameObjectPosition.GetDictionaryObjectPositon("Player");
        if (p.magnitude>2000)
        {
            t.enabled=true;
        }
    }
}
