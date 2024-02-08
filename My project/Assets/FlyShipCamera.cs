using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShipCamera : MonoBehaviour
{
    [SerializeField] FlyShip fS;
    [SerializeField] private float bouncePower;


    public void Update()
    {
        if (!fS.isAlive)
        {
            var v = Vector3.up - transform.forward;
            transform.position += v * bouncePower * Time.deltaTime ;
            transform.LookAt(fS.transform.position);
        }
    }
}
