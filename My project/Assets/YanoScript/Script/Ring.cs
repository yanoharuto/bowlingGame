using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ‚í‚Á‚©
/// </summary>
public class Ring : MonoBehaviour
{
    //€‚ñ‚¾‚©‚Ç‚¤‚©‚Ì”»’è
    public bool isDead { get; private set; } = false;
    //ŠÑ’Ê‚µ‚½‚ç€‚Ê
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDead = true;
        }
    }
    //ŠÑ’Ê‚Ìˆ—‚ªI‚í‚Á‚½‚ç
    public void OnExitPlayer()
    {
        if(isDead)
        {
            Destroy(gameObject);
        }
    }
}