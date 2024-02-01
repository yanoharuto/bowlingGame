using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タイトルの項目
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleItem", fileName = "titleItem")]
public class TitleItem : ScriptableObject
{
    //この位置にカーソルを移動
    [SerializeField] private Vector2 setCursorPos;
    //決定ボタンを押したならこのフェーズに変更
    [SerializeField] private TitleFaseManager.Fase setNextFase;
    //次にロードするシーン
    [SerializeField] private string setNextSceneName;
    //シーンのロードをするかどうか
    [SerializeField] private bool isLoadScene;
    //カーソルの位置
    public Vector2 cursorPos { get => setCursorPos; }
    //決定を押したときのフェーズ
    public TitleFaseManager.Fase nextFase { get => setNextFase;}
    //次にロードするシーン
    public string nextScene { get => setNextSceneName; }
}