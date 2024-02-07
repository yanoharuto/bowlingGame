using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverProcessor : MonoBehaviour
{
    [SerializeField] FlyShip fS;
    [SerializeField] Fade fade;
    // Update is called once per frame
    void Update()
    {
        if(fS.isAlive)
        {
            fade.FadeIn(1f);
        }
    }
}
