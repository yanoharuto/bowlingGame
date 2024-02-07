using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/CountDownText", fileName = "countDownText")]
public class CountDownText : ScriptableObject
{
    [SerializeField] string setStart;
    [SerializeField] string setOne;
    [SerializeField] string setTwo;
    [SerializeField] string setThree;
    [SerializeField] string setEnd;
    public string start { get => setStart; }
    public string one { get => setOne; }
    public string two { get => setTwo; }
    public string three { get => setThree; }
    public string end { get => setEnd; }
}
