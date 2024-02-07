using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] List< ParticleSystem> p;
    // Update is called once per frame
    public void StartEffect()
    {
        foreach(ParticleSystem p in p)
        {
            p.Play();
        }
    }
    public void StopEffect()
    {
        foreach (ParticleSystem p in p)
        {
            p.Stop();
        }
    }
}