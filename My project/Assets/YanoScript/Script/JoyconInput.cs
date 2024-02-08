using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
/// <summary>
/// ジョイコン入力
/// </summary>
public class JoyconInput :MonoBehaviour
{
    static public Joycon rJ { get; private set; }
    static public Joycon lJ { get; private set; }
    static bool isInit=false;
    /// <summary>
    /// 左ボタンの入力段階リスト
    /// </summary>
    static private Dictionary<Joycon.Button,InputFase> lButtons = new Dictionary<Joycon.Button, InputFase>();
    /// <summary>
    /// 右ボタンの入力段階リスト
    /// </summary>
    static private Dictionary<Joycon.Button,InputFase> rButtons = new Dictionary<Joycon.Button, InputFase>();
    public enum InputFase
    {
        free,//押してない
        push,//今押した
        hold,//長押し
        up//離した
    }
    public enum NextFaseKeyButton
    {
        Up,
        Right,
        Down,
        Left,
        Any,
        Plus
    }
    /// <summary>
    /// 入力段階を所得
    /// </summary>
    /// <param name="bType"></param>
    /// <returns></returns>
    public static InputFase GetRButtonFase(Joycon.Button bType)
    {
        return rButtons[bType];
    }
    /// <summary>
    /// 入力段階を所得
    /// </summary>
    /// <param name="bType"></param>
    /// <returns></returns>
    public static InputFase GetLButtonFase(Joycon.Button bType)
    {
        return lButtons[bType];
    }
    public static bool IsPressNextKey(NextFaseKeyButton faseKey)
    {
        switch (faseKey) //カーソルが指しているアイテムが反応するボタンを押したとき
        {
            case JoyconInput.NextFaseKeyButton.Up:
                return JoyconInput.GetRButtonFase(Joycon.Button.DPAD_UP) == JoyconInput.InputFase.push;
            case JoyconInput.NextFaseKeyButton.Right:
                return JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT) == JoyconInput.InputFase.push;
            case JoyconInput.NextFaseKeyButton.Down:
                return JoyconInput.GetRButtonFase(Joycon.Button.DPAD_DOWN) == JoyconInput.InputFase.push;
            case JoyconInput.NextFaseKeyButton.Left:
                return JoyconInput.GetRButtonFase(Joycon.Button.DPAD_LEFT) == JoyconInput.InputFase.push;
            case JoyconInput.NextFaseKeyButton.Any:
                return JoyconInput.IsPressAnyButton(JoyconInput.InputFase.push);
        }
        return false;
    }
    public static bool IsPressAnyButton(InputFase fase)
    {
        foreach (InputFase bFase in lButtons.Values)
        {
            if (bFase == fase)
            {
                return true;
            }
        }
        foreach (InputFase bFase in rButtons.Values)
        {
            if (bFase == fase)
            {
                return true;
            }
        }
        return false;
    }
    private void Awake()
    {
        
        if (!isInit)
        {
            Debug.Log("do");
            foreach (Joycon j in JoyconManager.Instance.j)
            {
                if (j.isLeft)
                {
                    lJ = j;
                }
                else
                {
                    rJ = j;
                }
            }
            rButtons.Add(Joycon.Button.DPAD_DOWN, InputFase.free);
            rButtons.Add(Joycon.Button.DPAD_UP, InputFase.free);
            rButtons.Add(Joycon.Button.DPAD_RIGHT, InputFase.free);
            rButtons.Add(Joycon.Button.DPAD_LEFT, InputFase.free);
            rButtons.Add(Joycon.Button.PLUS, InputFase.free);
            rButtons.Add(Joycon.Button.SHOULDER_1, InputFase.free);

            lButtons.Add(Joycon.Button.DPAD_DOWN, InputFase.free);
            lButtons.Add(Joycon.Button.DPAD_UP, InputFase.free);
            lButtons.Add(Joycon.Button.DPAD_RIGHT, InputFase.free);
            lButtons.Add(Joycon.Button.DPAD_LEFT, InputFase.free);
            lButtons.Add(Joycon.Button.SHOULDER_1, InputFase.free);
            isInit= true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    private void Update()
    {
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_DOWN);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_LEFT);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_UP);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_RIGHT);
        UpdateButton(rButtons,rJ,Joycon.Button.PLUS);
        UpdateButton(rButtons,rJ,Joycon.Button.SHOULDER_1);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_DOWN);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_LEFT);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_UP);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_RIGHT);
        UpdateButton(lButtons, lJ, Joycon.Button.SHOULDER_1);
    }
    /// <summary>
    /// 入力状況更新
    /// </summary>
    /// <param name="buttons">更新したいボタン</param>
    /// <param name="j">押してあるか調べるために必要なジョイコン</param>
    /// <param name="bType">ボタンの種類</param>
    private void UpdateButton(Dictionary<Joycon.Button,InputFase> buttons,Joycon j,Joycon.Button bType)
    {
        if(j.GetButton(bType))
        {
            if (buttons[bType] == InputFase.push)
            {

                buttons[bType] = InputFase.hold;
            }
            else if (buttons[bType] != InputFase.hold) 
            {
                buttons[bType] = InputFase.push;
            }
        }
        else
        {
            switch (buttons[bType])
            {
                case InputFase.hold:
                    buttons[bType] = InputFase.up;
                    break;
                case InputFase.push:
                    buttons[bType] = InputFase.up;
                    break;
                default:
                    buttons[bType] = InputFase.free;
                    break;
            }
        }
    }
}
