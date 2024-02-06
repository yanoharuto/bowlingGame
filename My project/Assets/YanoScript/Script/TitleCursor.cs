using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// タイトルの項目を選択する　
/// 上下で項目を変更
/// 今の項目の情報を渡す
/// </summary>
public class TitleCursor : MonoBehaviour
{
    //項目リスト
    List<TitleItem> items;
    //今指している項目の番号
    private int itemNum = 0;
    //位置変更に使う
    private RectTransform rT;
    //入力
    private bool isInput = false;
    [SerializeField] private List<Image> images;
    /// <summary>
    /// 今のフェーズの項目
    /// </summary>
    /// <param name="itemList"></param>
    public void SetItemList(List<TitleItem> itemList)
    {
        items = itemList;
        itemNum = 0;
        foreach(var image in images) 
        {
            var c = image.color;
            c.a = items[itemNum].isNotCursor ? 0 : 255;
            image.color = c;
        }
        if (!items[itemNum].isNotCursor)
        {
            rT.anchoredPosition = items[itemNum].cursorPos;
        }
    }
    /// <summary>
    /// 入力が入ったら次の項目を渡せるようにする
    /// </summary>
    /// <returns></returns>
    public TitleItem GetTitleItem()
    {
        return items[itemNum];
    }
    /// <summary>
    /// 上下にやってたら項目変換
    /// </summary>
    private void Update()
    {
        var lStickValue = JoyconInput.lJ.GetStick();
        if (!isInput && Mathf.Abs(lStickValue[1]) > 0.9f)//カーソルの移動
        {
            if (lStickValue[1] < 0)
            {
                itemNum++;
                itemNum = itemNum >= items.Count ? items.Count - 1 : itemNum;
            }
            else
            {
                itemNum--;
                itemNum = itemNum <= 0 ? 0 : itemNum;
            }
            rT.anchoredPosition = items[itemNum].cursorPos;
            isInput = true;
        }
        else
        {
            isInput= false;
        }
    }
    /// <summary>
    /// 入力を呼ぶ
    /// </summary>
    private void Start()
    {
        rT = GetComponent<RectTransform>();
    }
}