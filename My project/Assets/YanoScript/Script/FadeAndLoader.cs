using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeAndLoader : MonoBehaviour
{
    [SerializeField] private Fade fade;
    public IEnumerator FadeOutAndLoad(string loadSceneStr, float fadeTime = 1.0f)
    {
        fade.FadeIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(loadSceneStr);
        yield break;
    }
}
