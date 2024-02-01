using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �^�C�g���̍���
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleItem", fileName = "titleItem")]
public class TitleItem : ScriptableObject
{
    //���̈ʒu�ɃJ�[�\�����ړ�
    [SerializeField] private Vector2 setCursorPos;
    //����{�^�����������Ȃ炱�̃t�F�[�Y�ɕύX
    [SerializeField] private TitleFaseManager.Fase setNextFase;
    //���Ƀ��[�h����V�[��
    [SerializeField] private string setNextSceneName;
    //�V�[���̃��[�h�����邩�ǂ���
    [SerializeField] private bool isLoadScene;
    //�J�[�\���̈ʒu
    public Vector2 cursorPos { get => setCursorPos; }
    //������������Ƃ��̃t�F�[�Y
    public TitleFaseManager.Fase nextFase { get => setNextFase;}
    //���Ƀ��[�h����V�[��
    public string nextScene { get => setNextSceneName; }
}