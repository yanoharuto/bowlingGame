using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ‚í‚Á‚©
/// </summary>
public class Ring : MonoBehaviour
{
    [SerializeField] MeshRenderer r;
    //Ž€‚ñ‚¾‚©‚Ç‚¤‚©‚Ì”»’è
    public bool isDead { get; private set; } = false;
    //ŠÑ’Ê‚µ‚½‚çŽ€‚Ê
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