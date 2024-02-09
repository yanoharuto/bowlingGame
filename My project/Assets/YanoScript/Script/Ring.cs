using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// わっか
/// </summary>
public class Ring : MonoBehaviour
{
    [SerializeField] MeshRenderer r;
    //死んだかどうかの判定
    public bool isDead { get; private set; } = false;
    //貫通したら死ぬ
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