using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// タイトルUIなど　出てくるタイミングになったらアクティブ
/// </summary>
public class TitleObject : MonoBehaviour
{
    [SerializeField][Header("表示するタイミング")] TitleFaseManager.Fase upperFase;

    [SerializeField] [Header("表示されたり消えたりするもの")]List<GameObject> objList=new List<GameObject>();
    private void Update()
    {
        if (objList.Count > 0)
        {
            var isUpper = upperFase == TitleFaseManager.nowFase;
            foreach (var obj in objList)
            {
                obj.SetActive(isUpper);
            }
        }
    }
}