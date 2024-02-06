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
        Any
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
    private void Start()
    {
        foreach (Joycon j in JoyconManager.Instance.j)
        {
            if(j.isLeft)
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
        lButtons.Add(Joycon.Button.DPAD_DOWN, InputFase.free);
        lButtons.Add(Joycon.Button.DPAD_UP , InputFase.free);
        lButtons.Add(Joycon.Button.DPAD_RIGHT, InputFase.free);
        lButtons.Add(Joycon.Button.DPAD_LEFT, InputFase.free);
    }
    private void Update()
    {
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_DOWN);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_LEFT);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_UP);
        UpdateButton(rButtons,rJ,Joycon.Button.DPAD_RIGHT);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_DOWN);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_LEFT);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_UP);
        UpdateButton(lButtons, lJ, Joycon.Button.DPAD_RIGHT);
    }
    private void UpdateButton(Dictionary<Joycon.Button,InputFase> buttons,Joycon j,Joycon.Button bType)
    {
        if(j.GetButton(bType))
        {
            if (buttons[bType] == InputFase.push)
            {

                buttons[bType] = InputFase.hold;
            }
            else
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
