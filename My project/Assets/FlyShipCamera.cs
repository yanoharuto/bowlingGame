using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShipCamera : MonoBehaviour
{
    const float firstBetween = -10.0f;
    Vector3 flyShipBetween = new Vector3(0,0,0);
    private void Start()
    {
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        flyShipBetween = GameObjectPosition.GetDictionaryObjectForward("Player") * firstBetween;
        transform.position = playerPos + flyShipBetween;

        transform.LookAt(playerPos);

    }
    private void FixedUpdate()
    {
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        
        transform.position = playerPos + flyShipBetween;
    }
}
