using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSkyBox : MonoBehaviour
{
    public float _anglePerFrame = 0.1f;    // 1�t���[���ɉ��x�񂷂�[unit : deg]
    float _rot = 0.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _rot += _anglePerFrame;
        if (_rot >= 360.0f)
        {    // 0�`360���͈̔͂ɂ����߂���
            _rot -= 360.0f;
        }
        RenderSettings.skybox.SetFloat("_Rotation", _rot);    // ��
    }
}
