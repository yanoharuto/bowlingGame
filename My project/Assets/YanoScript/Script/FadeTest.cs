using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTest : MonoBehaviour
{

    public Fade fade;              //�t�F�[�h�L�����o�X�擾

    // Use this for initialization
    void Start()
    {
        //�g�����W�V�������|���ăV�[���J�ڂ���
        fade.FadeIn(1f, () =>
        {
        });
    }

    // Update is called once per frame
    void Update()
    {

    }


    //�Q�[���X�^�[�g
    public void StartBt()
    {

    }
}
