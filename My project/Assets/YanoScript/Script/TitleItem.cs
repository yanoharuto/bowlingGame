using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タイトルの項目
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleItem", fileName = "titleItem")]
public class TitleItem : ScriptableObject
{
    [SerializeField][Header("この位置にカーソルを移動")] private Vector2 setCursorPos;
    
    [SerializeField][Header("決定ボタンを押したならこのフェーズに変更")] private TitleFaseManager.Fase setNextFase;
    
    [SerializeField][Header("次にロードするシーン")] private string setNextSceneName;
    
    [SerializeField][Header("シーンのロードをするかどうか")] private bool setIsLoadScene;

    [SerializeField] [Header("カーソルが必要か")] private bool setIsNotCursor;
    
    [SerializeField][Header("カーソルが必要か")] private JoyconInput.NextFaseKeyButton setNextKeyButton;
    //カーソルの位置
    public Vector2 cursorPos { get => setCursorPos; }
    //決定を押したときのフェーズ
    public TitleFaseManager.Fase nextFase { get => setNextFase;}
    //次にロードするシーン
    public string nextScene { get => setNextSceneName; }
    public bool isLoadScene { get => setIsLoadScene; }
    public bool isNotCursor { get => setIsNotCursor; }
    public JoyconInput.NextFaseKeyButton keyButton { get => setNextKeyButton;}
}