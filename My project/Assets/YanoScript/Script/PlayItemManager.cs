using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayItemManager : MonoBehaviour
{
    private List<PlayItem> items;
    int itemNum = 0;
    bool isHorizon = false;
    public bool isNextFase { get; private set; } = false;
    public bool isLoad { get; private set; } = false;
    public void SetItems(List<PlayItem> setItem,bool setHorizon)
    {
        items = setItem;
        isHorizon = setHorizon;
        itemNum = 0;
        isNextFase = false;
    }

    public PlayFaseManager.Fase GetNextFase()
    {
        return items[itemNum].nextFase;
    }
    public string GetNextLoadStageName()
    {
        return items[itemNum].loadName;
    }
    private void Update()
    {
        var sValue = JoyconInput.lJ.GetStick();

        if (isHorizon && Mathf.Abs(sValue[0]) < 0.1f) 
        {
            if (sValue[0] < 0) 
            {
                itemNum++;
                if (itemNum >= items.Count)
                {
                    itemNum = items.Count - 1;
                }
            }
            else
            {
                itemNum--;
                if (itemNum <= 0)
                {
                    itemNum = 0;
                }
            }
        }
        else if (!isHorizon && Mathf.Abs(sValue[1]) < 0.1f)
        {
            if (sValue[1] < 0)
            {
                itemNum++;
                if (itemNum >= items.Count) 
                {
                    itemNum = items.Count;
                    itemNum -= 1;
                }
            }
            else
            {
                itemNum--;
                if (itemNum <= 0)
                {
                    itemNum = 0;
                }
            }
        }

        isNextFase = JoyconInput.IsPressNextKey(items[itemNum].nextFaseKeyButton);
        isLoad = items[itemNum].isLoad;
    }
}
