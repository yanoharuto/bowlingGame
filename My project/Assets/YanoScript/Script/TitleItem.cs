using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �^�C�g���̍���
/// </summary>
[CreateAssetMenu(menuName = "Create/TitleItem", fileName = "titleItem")]
public class TitleItem : ScriptableObject
{
    [SerializeField][Header("���̈ʒu�ɃJ�[�\�����ړ�")] private Vector2 setCursorPos;
    
    [SerializeField][Header("����{�^�����������Ȃ炱�̃t�F�[�Y�ɕύX")] private TitleFaseManager.Fase setNextFase;
    
    [SerializeField][Header("���Ƀ��[�h����V�[��")] private string setNextSceneName;
    
    [SerializeField][Header("�V�[���̃��[�h�����邩�ǂ���")] private bool setIsLoadScene;

    [SerializeField] [Header("�J�[�\�����K�v��")] private bool setIsNotCursor;
    
    [SerializeField][Header("�J�[�\�����K�v��")] private JoyconInput.NextFaseKeyButton setNextKeyButton;
    //�J�[�\���̈ʒu
    public Vector2 cursorPos { get => setCursorPos; }
    //������������Ƃ��̃t�F�[�Y
    public TitleFaseManager.Fase nextFase { get => setNextFase;}
    //���Ƀ��[�h����V�[��
    public string nextScene { get => setNextSceneName; }
    public bool isLoadScene { get => setIsLoadScene; }
    public bool isNotCursor { get => setIsNotCursor; }
    public JoyconInput.NextFaseKeyButton keyButton { get => setNextKeyButton;}
}