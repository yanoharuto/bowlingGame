using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyShipCamera : MonoBehaviour
{
    //�v���C���[�Ƃ̋���
    float betweenSize = -10.0f;
    const float bSizeMax = 30.0f;
    const float bSizeMin = 10.0f;
    //�J�����ƃv���C���[�̋���
    Vector3 flyShipBetween = new Vector3(0,0,0);
    private void Start()
    {
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        flyShipBetween = (playerPos - transform.position).normalized * betweenSize ;
        transform.position = playerPos + flyShipBetween;
        transform.LookAt(playerPos);
    }
    /// <summary>
    /// �J�����X�V
    /// </summary>
    private void FixedUpdate()
    {
        //�X�e�B�b�N���Ȃ��Ă邩���ׂ�
        var stick = JoyconManager.Instance.j[0].GetStick();
        var sX = stick[0];
        //�v���C���[�Ƃ̋������X�V
        if (Mathf.Abs(sX) > 0.1f) 
        {
            var cross = Vector3.Cross(flyShipBetween.normalized, Vector3.up);
            flyShipBetween += sX > 0 ? cross : -cross;
        }
        //�v���C���[�̈ʒu�ɍ��킹�ăJ��������]�ƈړ�
        var playerPos = GameObjectPosition.GetDictionaryObjectPositon("Player");
        
        betweenSize = (playerPos - transform.position).magnitude;
        betweenSize = betweenSize < bSizeMin ? bSizeMin : betweenSize;
        betweenSize = betweenSize > bSizeMax ? bSizeMax : betweenSize;
        flyShipBetween = flyShipBetween.normalized * betweenSize;
        transform.position = playerPos + flyShipBetween;
        transform.LookAt(playerPos);
    }
}
