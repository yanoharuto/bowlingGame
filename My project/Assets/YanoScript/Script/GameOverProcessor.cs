using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.Windows;

public class GameOverProcessor : MonoBehaviour
{
    [SerializeField] FlyShip fS;
    [SerializeField] List<Vector3> cursorPos;
    [SerializeField] RectTransform cursor;
    int itemNum = 0;
    bool isInput;
    private void Update()
    {
        cursor.anchoredPosition = cursorPos[itemNum];
        var lStickValue = JoyconInput.lJ.GetStick();
        if (Mathf.Abs(lStickValue[0]) > 0.9f)//ƒJ[ƒ\ƒ‹‚ÌˆÚ“®
        {
            if (!isInput)
            {
                if (lStickValue[0] > 0)
                {
                    itemNum++;
                    itemNum = itemNum >= cursorPos.Count ? cursorPos.Count - 1 : itemNum;
                }
                else
                {
                    itemNum--;
                    itemNum = itemNum <= 0 ? 0 : itemNum;
                }
                isInput = true;
            }
        }
        else
        {
            isInput = false;
        }
    }
    public bool isFlyShipAlive { get { return fS.isAlive; } }
}
