using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ƒWƒ‡ƒCƒRƒ““ü—Í
/// </summary>
public class JoyconInput 
{
    public Joycon rJ { get; private set; }
    public Joycon lJ { get; private set; }
    
    public JoyconInput()
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
    }
}
