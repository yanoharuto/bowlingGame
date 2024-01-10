using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// わっか
/// </summary>
public class Ring : MonoBehaviour
{
    //死んだかどうかの判定
    public bool isDead { get; private set; } = false;
    //貫通したら死ぬ
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDead = true;
        }
    }
    //貫通の処理が終わったら
    public void OnExitPlayer()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }
}