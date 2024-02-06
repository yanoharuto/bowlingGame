using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using static UnityEditor.Progress;
/// <summary>
/// タイトルの工程管理
/// </summary>
public class TitleFaseManager : MonoBehaviour
{
    //工程のリスト
    [SerializeField] List<TitleFase> faseList;
    //タイトルのカーソル
    [SerializeField] TitleCursor cursor;
    //工程の種類
    public enum Fase
    {
        anyButton,//最初の画面
        menu,//タイトルの選択
        stageSelect,//ステージ選択　予定は1ステージ
        option,//音量
        manual//操作方法
    }
    
    //今の工程で必要なもの纏め
    private TitleFase nowFaseObj;
    static public Fase nowFase { get; private set; } = Fase.anyButton;
    /// <summary>
    /// 入力クラスの所得 カーソルの初期化
    /// </summary>
    void Start()
    {
        nowFaseObj = faseList[0];
        cursor.SetItemList(nowFaseObj.itemList);
        nowFase = nowFaseObj.nowFase;
    }
    /// <summary>
    /// 入力があったら更新
    /// </summary>
    void Update()
    {
        var item = cursor.GetTitleItem();
        var isNextFase = false;
        switch (item.keyButton) //カーソルが指しているアイテムが反応するボタンを押したとき
        {
            case JoyconInput.NextFaseKeyButton.Up:
                isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_UP)==JoyconInput.InputFase.push;
                break;
            case JoyconInput.NextFaseKeyButton.Right:
                isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT) == JoyconInput.InputFase.push;
                break;
            case JoyconInput.NextFaseKeyButton.Down: 
                isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_DOWN) == JoyconInput.InputFase.push;
                break;
            case JoyconInput.NextFaseKeyButton.Left:
                isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_LEFT) == JoyconInput.InputFase.push;
                break;
            case JoyconInput.NextFaseKeyButton.Any:
                isNextFase = JoyconInput.IsPressAnyButton(JoyconInput.InputFase.push);
                break;
        }
        //次の項目に行く
        if (isNextFase)
        {
            if (item.isLoadScene)//ロード
            {
                SceneManager.LoadScene(item.nextScene);
            }
            else
            {
                //次のフェーズを所得
                foreach (TitleFase fase in faseList)
                {
                    if (item.nextFase == fase.nowFase)
                    {
                        UpdateFase(fase);
                        break;
                    }
                }
            }
        }
    }
    /// <summary>
    /// 工程の更新
    /// </summary>
    void UpdateFase(TitleFase nextFaseObj)
    {
        //次の項目の更新
        nowFaseObj = nextFaseObj;
        nowFase = nowFaseObj.nowFase;
        //カーソルの更新
        cursor.SetItemList(nextFaseObj.itemList);
    }
}