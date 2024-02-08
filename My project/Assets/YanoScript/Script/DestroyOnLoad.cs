using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class DestroyOnLoad : MonoBehaviour
{
    static bool isLoad = false;
    private void Start()
    {
        if (!isLoad)
        {
            DontDestroyOnLoad(gameObject);
            isLoad = true;
        }
    }
}