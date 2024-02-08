using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPlayer : MonoBehaviour
{
    [SerializeField] List< ParticleSystem> p;

    [SerializeField] ParticleSystem effect_acceleration;
    [SerializeField] ParticleSystem effect_boom;

    Move efP_move;

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

    void Start()
    {
        efP_move = new Move();
    }

    void Update () 
    {
        if(efP_move.getset_buttonAccel == true)
        {
            Debug.Log("‚©‚»‚­‚È‚¤");
            effect_acceleration.Play();
            effect_boom.Play();
        }
        else
        {
            if(effect_acceleration.isPlaying)
            {
                effect_acceleration.Stop();
                effect_boom.Stop();
            }
        }
    }
}