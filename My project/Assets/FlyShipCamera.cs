using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShipCamera : MonoBehaviour
{
    const float playerBetween = -10.0f;
    private void FixedUpdate()
    {
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        transform.position = playerPos;
        transform.position += GameObjectPosition.GetDictionaryObjectForward("Player") * playerBetween ;
        transform.LookAt(playerPos);
    }
}
