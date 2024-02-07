using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    [SerializeField] GameObject newRecode;

    bool scaleSizeRota = true;

    const float magnificationValue = 0.0025f;

    // Update is called once per frame
    void Update()
    {
        if(scaleSizeRota) 
        {
            if (newRecode.gameObject.transform.localScale.x < 0.5005)
            {
                newRecode.gameObject.transform.localScale 
                    +=  new Vector3(magnificationValue,magnificationValue,magnificationValue);
            }
            if (newRecode.gameObject.transform.localScale.x >= 0.5005)
            {
                scaleSizeRota = false;
            }
        }
        else
        {
            if(newRecode.gameObject.transform.localScale.x > 0.25)
            {
                newRecode.gameObject.transform.localScale 
                    -= new Vector3(magnificationValue, magnificationValue, magnificationValue);
            }
            if(newRecode.gameObject.transform.localScale.x <= 0.25)
            {
                scaleSizeRota = true;
            }
        }
    }
}
