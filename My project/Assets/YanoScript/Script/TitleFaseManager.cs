using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Windows;

/// <summary>
/// �^�C�g���̍H���Ǘ�
/// </summary>
public class TitleFaseManager : MonoBehaviour
{
    //�H���̃��X�g
    [SerializeField] List<TitleFase> faseList;
    //�^�C�g���̃J�[�\��
    [SerializeField] TitleCursor cursor;
    [SerializeField] FadeAndLoader fade;
    [SerializeField] Image image;
    public static bool isLoadScene { get; private set; }
    //�H���̎��
    public enum Fase
    {
        anyButton,//�ŏ��̉��
        menu,//�^�C�g���̑I��
        stageSelect,//�X�e�[�W�I���@�\���1�X�e�[�W
        option,//����
        manual//������@
    }
    
    //���̍H���ŕK�v�Ȃ��̓Z��
    private TitleFase nowFaseObj;
    static public Fase nowFase { get; private set; } = Fase.anyButton;
    bool fadeF = true;
    /// <summary>
    /// ���̓N���X�̏��� �J�[�\���̏�����
    /// </summary>
    void Start()
    {
        
        nowFaseObj = faseList[0];
        cursor.SetItemList(nowFaseObj.itemList);
        nowFase = nowFaseObj.nowFase;
        isLoadScene = false;
    }
    /// <summary>
    /// ���͂���������X�V
    /// </summary>
    void Update()
    {
        if (!isLoadScene)
        {
            var item = cursor.GetTitleItem();
            var isNextFase = false;
            switch (item.keyButton) //�J�[�\�����w���Ă���A�C�e������������{�^�����������Ƃ�
            {
                case JoyconInput.NextFaseKeyButton.Up:
                    isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_UP) == JoyconInput.InputFase.push;
                    break;
                case JoyconInput.NextFaseKeyButton.Right:
                    isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_RIGHT) == JoyconInput.InputFase.push;
                    break;
                case JoyconInput.NextFaseKeyButton.Down:
                    isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_DOWN) == JoyconInput.InputFase.push;
                    break;
                case JoyconInput.NextFaseKeyButton.Left:
                    isNextFase = JoyconInput.GetRButtonFase(Joycon.Button.DPAD_LEFT) == JoyconInput.InputFase.push;
                    break;
                case JoyconInput.NextFaseKeyButton.Any:
                    isNextFase = JoyconInput.IsPressAnyButton(JoyconInput.InputFase.push);
                    break;
            }
            //���̍��ڂɍs��
            if (isNextFase)
            {
                if (item.isLoadScene)//���[�h
                {
                    StartCoroutine(fade.FadeInAndLoad(image, item.nextScene, 1f)) ;
                    isLoadScene = true;
                }
                else
                {
                    //���̃t�F�[�Y������
                    foreach (TitleFase fase in faseList)
                    {
                        if (item.nextFase == fase.nowFase)
                        {
                            UpdateFase(fase);
                            break;
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// �H���̍X�V
    /// </summary>
    void UpdateFase(TitleFase nextFaseObj)
    {
        //���̍��ڂ̍X�V
        nowFaseObj = nextFaseObj;
        nowFase = nowFaseObj.nowFase;
        //�J�[�\���̍X�V
        cursor.SetItemList(nextFaseObj.itemList);
    }

}