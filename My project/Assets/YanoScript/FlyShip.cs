using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyShip : MonoBehaviour
{
    private const float MAX_ROTA_Z = 74.0f;
    private float rotaZPercent = 0.0f;

    [SerializeField] private PlayerSpeed speed;

    private void Start()
    {
        GameObjectPosition.AddDictionaryObject(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        var newRotation = transform.rotation.eulerAngles;

    //    switch (GyroStateManager.zRotaState)
    //    {
    //        case GyroStateManager.GyroState.left:
    //            rotaZPercent -= speed.rotaSpeed * Time.deltaTime;
    //            break;
    //        case GyroStateManager.GyroState.right:
    //            rotaZPercent += speed.rotaSpeed * Time.deltaTime;
    //            break;
    //        case GyroStateManager.GyroState.neutral:
    //            if (rotaZPercent < -speed.rotaSpeed)
    //            {
    //                rotaZPercent += speed.rotaSpeed * Time.deltaTime;
    //            }
    //            else if (rotaZPercent > speed.rotaSpeed)
    //            {
    //                rotaZPercent -= speed.rotaSpeed * Time.deltaTime;
    //            }
    //            else
    //            {
    //                rotaZPercent = 0;
    //            }
    //            break;
    //    }
    //    if (rotaZPercent > speed.rotaSpeed)
    //    {
    //        if (rotaZPercent > 1.0f)
    //        {
    //            rotaZPercent = 1.0f;
    //        }
    //        newRotation.z = Mathf.Lerp(0, MAX_ROTA_Z, Mathf.Abs(rotaZPercent));
    //    }
    //    else if (rotaZPercent < -speed.rotaSpeed)
    //    {
    //        if (rotaZPercent < -1.0f)
    //        {
    //            rotaZPercent = -1.0f;
    //        }
    //        newRotation.z = Mathf.Lerp(0, -MAX_ROTA_Z, Mathf.Abs(rotaZPercent));
    //    }
    //    else
    //    {
    //        newRotation.z = 0;
    //    }
    //    transform.rotation = Quaternion.Euler(newRotation);
    }
}