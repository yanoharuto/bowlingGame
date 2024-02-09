using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// プレイヤーの位置が分かるようにする
/// </summary>
public class FlyShip : MonoBehaviour
{
    [SerializeField] Move move;
    enum GameFase
    {
        start,
        play,
        end,
    }
    public bool isAlive { get; private set; } = true;
    [SerializeField] EffectPlayer eP;
    float time = 0;
    /// <summary>
    /// 位置を伝える
    /// </summary>
    void Start()
    {
        eP.StopEffect();
        GameObjectPosition.AddDictionaryObject(gameObject);
    }
    private void Update()
    {
        move.enabled = PlayFaseManager.nowFade == PlayFaseManager.Fase.playFlight;
        var rBody = GetComponent<Rigidbody>();
        rBody.isKinematic = !move.enabled;
        if (PlayFaseManager.nowFade == PlayFaseManager.Fase.fadeIn) 
        {
            isAlive = true;
        }
        Vector3 v = transform.position;
        if(v.magnitude>4000.0f)
        {
            transform.LookAt(Vector3.zero);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle") 
        {
            isAlive = false;
            move.enabled= false;
            var rBody=GetComponent<Rigidbody>();
            rBody.isKinematic = true;
            rBody.velocity= Vector3.zero;
            eP.StartEffect();

        }
    }
}