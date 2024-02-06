using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �^�C�g���̍H��
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleFase", fileName = "titleFase")]
public class TitleFase : ScriptableObject
{
    //���̍H��
    [SerializeField] private TitleFaseManager.Fase setNowFase;
    //�\���������I�u�W�F�N�g
    [SerializeField] private List<TitleItem> setItemList;
    public TitleFaseManager.Fase nowFase { get => setNowFase; }
    public List<TitleItem> itemList { get => setItemList; }
}