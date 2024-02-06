using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �^�C�g���̍��ڂ�I������@
/// �㉺�ō��ڂ�ύX
/// ���̍��ڂ̏���n��
/// </summary>
public class TitleCursor : MonoBehaviour
{
    //���ڃ��X�g
    List<TitleItem> items;
    //���w���Ă��鍀�ڂ̔ԍ�
    private int itemNum = 0;
    //�ʒu�ύX�Ɏg��
    private RectTransform rT;
    //����
    private bool isInput = false;
    [SerializeField] private List<Image> images;
    /// <summary>
    /// ���̃t�F�[�Y�̍���
    /// </summary>
    /// <param name="itemList"></param>
    public void SetItemList(List<TitleItem> itemList)
    {
        items = itemList;
        itemNum = 0;
        foreach(var image in images) 
        {
            var c = image.color;
            c.a = items[itemNum].isNotCursor ? 0 : 255;
            image.color = c;
        }
        if (!items[itemNum].isNotCursor)
        {
            rT.anchoredPosition = items[itemNum].cursorPos;
        }
    }
    /// <summary>
    /// ���͂��������玟�̍��ڂ�n����悤�ɂ���
    /// </summary>
    /// <returns></returns>
    public TitleItem GetTitleItem()
    {
        return items[itemNum];
    }
    /// <summary>
    /// �㉺�ɂ���Ă��獀�ڕϊ�
    /// </summary>
    private void Update()
    {
        var lStickValue = JoyconInput.lJ.GetStick();
        if (!isInput && Mathf.Abs(lStickValue[1]) > 0.9f)//�J�[�\���̈ړ�
        {
            if (lStickValue[1] < 0)
            {
                itemNum++;
                itemNum = itemNum >= items.Count ? items.Count - 1 : itemNum;
            }
            else
            {
                itemNum--;
                itemNum = itemNum <= 0 ? 0 : itemNum;
            }
            rT.anchoredPosition = items[itemNum].cursorPos;
            isInput = true;
        }
        else
        {
            isInput= false;
        }
    }
    /// <summary>
    /// ���͂��Ă�
    /// </summary>
    private void Start()
    {
        rT = GetComponent<RectTransform>();
    }
}