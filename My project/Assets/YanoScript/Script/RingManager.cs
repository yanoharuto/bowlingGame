using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingManager : MonoBehaviour
{
    [SerializeField] private List<Ring> rings = new List<Ring>();
    public bool isDeadAllRing { get; private set; } = false;
    public void Update()
    {
        if (rings.Count > 0)
        {
            foreach (Ring ring in rings)
            {
                if (ring.isDead)
                {
                    rings.Remove(ring);
                }
                ring.OnExitPlayer();
            }
        }
        else
        {
            isDeadAllRing= true;
        }
    }
}
