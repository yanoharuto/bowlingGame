using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����
/// </summary>
public class Ring : MonoBehaviour
{
    //���񂾂��ǂ����̔���
    public bool isDead { get; private set; } = false;
    //�ђʂ����玀��
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDead = true;
        }
    }
    //�ђʂ̏������I�������
    public void OnExitPlayer()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }
}