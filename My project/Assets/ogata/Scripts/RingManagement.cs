using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManagement : MonoBehaviour
{
    /// <summary>
    /// �擾���ɏo���G�t�F�N�g
    /// </summary>
    [SerializeField] GameObject collectEffect;


    /// <summary>
    /// �����Ɠ����ɃG�t�F�N�g���C���X�^���X��
    /// </summary>
    private void OnDisable()
    {
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);
    }
}
