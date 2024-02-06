using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �^�C�g��UI�Ȃǁ@�o�Ă���^�C�~���O�ɂȂ�����A�N�e�B�u
/// </summary>
public class TitleObject : MonoBehaviour
{
    [SerializeField][Header("�\������^�C�~���O")] TitleFaseManager.Fase upperFase;

    [SerializeField] [Header("�\�����ꂽ��������肷�����")]List<GameObject> objList=new List<GameObject>();
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