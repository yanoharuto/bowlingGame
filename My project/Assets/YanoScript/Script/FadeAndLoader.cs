using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeAndLoader : MonoBehaviour
{
    [SerializeField] private Fade fade;
    bool isInit = false;
    public IEnumerator FadeInAndLoad(Image image,string loadSceneStr, float fadeTime = 1.0f)
    {
        isInit = true;
        while (image.color.a >= 0.99f) 
        {
            var c = image.color;
            c.a += 0.01f;
            image.color = c ;
        }
        SceneManager.LoadScene(loadSceneStr);
        yield break;
    }
}
