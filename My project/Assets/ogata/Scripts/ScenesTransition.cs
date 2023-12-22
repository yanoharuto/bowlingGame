using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScenesTransition : MonoBehaviour
{
    string[] ST_SceneNames;
    Dictionary<string, string> ST_Scenes = new Dictionary<string, string>();


    // Start is called before the first frame update
    void Start()
    {
        ST_SceneNames = new string[] { };
        ST_Scenes.Add("タイトル", "");
        ST_Scenes.Add("ゲーム", "");
        ST_Scenes.Add("リザルト", "");
        ST_Scenes.Add("ゲームオーバー", "");

    }

    void ST_ChangeScenes(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
