using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����
/// </summary>
public class Ring : MonoBehaviour
{
    [SerializeField] MeshRenderer r;
    //���񂾂��ǂ����̔���
    public bool isDead { get; private set; } = false;
    //�ђʂ����玀��
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDead = true;
            r.enabled = false;
            Debug.Log("false");
        }
    }
}