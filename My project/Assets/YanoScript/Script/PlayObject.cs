using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayObject : MonoBehaviour
{
    [SerializeField] List<GameObject> objectList;
    [SerializeField] PlayFaseManager.Fase fase;
    private void Update()
    {
        var isActive = fase == PlayFaseManager.nowFase;
        foreach (GameObject obj in objectList)
        {
            obj.SetActive(isActive);
        }
    }
}
