using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タイトルの工程
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleFase", fileName = "titleFase")]
public class TitleFase : ScriptableObject
{
    //今の工程
    [SerializeField] private TitleFaseManager.Fase setNowFase;
    //表示したいオブジェクト
    [SerializeField] private List<TitleItem> setItemList;
    public TitleFaseManager.Fase nowFase { get => setNowFase; }
    public List<TitleItem> itemList { get => setItemList; }
}