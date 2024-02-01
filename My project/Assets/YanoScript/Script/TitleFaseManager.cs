using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;
/// <summary>
/// �^�C�g���̍H���Ǘ�
/// </summary>
public class TitleFaseManager : MonoBehaviour
{
    //����
    private JoyconInput input;
    //�H���̃��X�g
    [SerializeField] List<TitleFase> faseList;
    //�^�C�g���̃J�[�\��
    [SerializeField] TitleCursor cursor;
    //�H���̎��
    public enum Fase
    {
        anyButton,//�ŏ��̉��
        menu,//�^�C�g���̑I��
        stageSelect,//�X�e�[�W�I���@�\���1�X�e�[�W
        option,//����
        manual//������@
    }
    
    private TitleFase nowFaseObj;
    [SerializeField] private Fase nowFase = Fase.anyButton;
    /// <summary>
    /// ���̓N���X�̏��� �J�[�\���̏�����
    /// </summary>
    void Start()
    {
        input = new JoyconInput();
        nowFaseObj = faseList[0];
        cursor.SetItemList(nowFaseObj.itemList);
    }
    /// <summary>
    /// ���͂���������X�V
    /// </summary>
    void Update()
    {
        //����{�^�����������Ȃ�t�F�[�Y�̍X�V
        if (input.rJ.GetButton(Joycon.Button.DPAD_LEFT))
        {
            foreach (var fase in faseList)
            {
                if (nowFase == fase.nowFase)
                {
                    UpdateFase(fase);
                    break;
                }
            }
        }
        //�L�����Z���{�^�����������Ȃ烁�j���[��ʂɖ߂�
        if(input.rJ.GetButton(Joycon.Button.DPAD_DOWN))
        {
            nowFase = Fase.menu;
        }
    }
    /// <summary>
    /// �H���̍X�V
    /// </summary>
    void UpdateFase(TitleFase nextFaseObj)
    {
        //�J�[�\���̍X�V
        cursor.SetItemList(nextFaseObj.itemList);
        //���ڂ������Ȃ�������������肷��
        if (nowFaseObj.objList.Count > 0)
        {
            foreach (var obj in nowFaseObj.objList)
            {
                obj.SetActive(false);
            }
        }
        if (nextFaseObj.objList.Count > 0)
        {
            foreach (var obj in nextFaseObj.objList)
            {
                obj.SetActive(true);
            }
        }
        //���̍��ڂ̍X�V
        nowFaseObj = nextFaseObj;
    }
}