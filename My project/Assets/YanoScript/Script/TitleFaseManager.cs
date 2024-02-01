using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
/// <summary>
/// タイトルの工程管理
/// </summary>
public class TitleFaseManager : MonoBehaviour
{
    //入力
    private JoyconInput input;
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
    
    private TitleFase nowFaseObj;
    [SerializeField] private Fase nowFase = Fase.anyButton;
    /// <summary>
    /// 入力クラスの所得 カーソルの初期化
    /// </summary>
    void Start()
    {
        input = new JoyconInput();
        nowFaseObj = faseList[0];
        cursor.SetItemList(nowFaseObj.itemList);
    }
    /// <summary>
    /// 入力があったら更新
    /// </summary>
    void Update()
    {
        //決定ボタンを押したならフェーズの更新
        if (input.rJ.GetButton(Joycon.Button.DPAD_LEFT))
        {
            foreach (var fase in faseList)
            {
                if (nowFase == fase.nowFase)
                {
                    UpdateFase(fase);
                    break;
                }
            }
        }
        //キャンセルボタンを押したならメニュー画面に戻る
        if(input.rJ.GetButton(Joycon.Button.DPAD_DOWN))
        {
            nowFase = Fase.menu;
        }
    }
    /// <summary>
    /// 工程の更新
    /// </summary>
    void UpdateFase(TitleFase nextFaseObj)
    {
        //カーソルの更新
        cursor.SetItemList(nextFaseObj.itemList);
        //項目を見えなくしたり消したりする
        if (nowFaseObj.objList.Count > 0)
        {
            foreach (var obj in nowFaseObj.objList)
            {
                obj.SetActive(false);
            }
        }
        if (nextFaseObj.objList.Count > 0)
        {
            foreach (var obj in nextFaseObj.objList)
            {
                obj.SetActive(true);
            }
        }
        //次の項目の更新
        nowFaseObj = nextFaseObj;
    }
}