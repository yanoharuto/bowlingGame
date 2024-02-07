using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Create/PlayFase", fileName = "playFase")]
public class PlayFase : ScriptableObject
{
    [SerializeField] PlayFaseManager.Fase setFase;
    public PlayFaseManager.Fase getFase { get { return setFase; } }

    [SerializeField] List<PlayItem> setItems;
    public List<PlayItem> items { get { return setItems; } }

    [SerializeField] bool setIsHorizon;
    public bool isHorizon { get { return setIsHorizon; } }
}
