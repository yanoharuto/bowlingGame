using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCursor : MonoBehaviour
{
    List<TitleItem> items;
    private JoyconInput input;
    private int itemNum = 0;
    public void SetItemList(List<TitleItem> itemList)
    {
        items = itemList;
        itemNum = 0;
        transform.position = items[itemNum].cursorPos;

    }
    public TitleFaseManager.Fase GetFase()
    {
        return items[itemNum].nextFase;
    }
    /// <summary>
    /// ã‰º‚É‚â‚Á‚Ä‚½‚ç€–Ú•ÏŠ·
    /// </summary>
    private void Update()
    {
        var lStickValue = input.lJ.GetStick();
        var isDownS = Mathf.Abs(lStickValue[0]) < 0.1f;
        if (isDownS)
        {
            if(lStickValue[0] < 0)
            {
                itemNum = itemNum >= items.Count ? items.Count - 1 : itemNum + 1;
            }
            else
            {
                itemNum = itemNum <= 0 ? 0 : itemNum -1;
            }
            transform.position = items[itemNum % items.Count].cursorPos;
        }
    }
    /// <summary>
    /// “ü—Í‚ğŒÄ‚Ô
    /// </summary>
    private void Start()
    {
        input = new JoyconInput();
    }
}