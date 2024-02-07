using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 
/// </summary>
public class PlayFaseManager : MonoBehaviour
{
    public enum Fase
    {
        displayRule,
        countDown,
        playFlight,
        gameOver,
        clear,
        menu
    }
    public static Fase nowFase { get; private set; } = Fase.displayRule;
    [SerializeField] PlayFase displayRule;
    [SerializeField] PlayFase playFlight;
    [SerializeField] PlayFase gameOver;
    [SerializeField] PlayFase clear;
    [SerializeField] PlayFase count;
    [SerializeField] CountDown countProccesor;
    [SerializeField] PlayMenu menu;
    [SerializeField] PlayItemManager pIManager;
    [SerializeField] FadeAndLoader fadeLoad;
    private void Start()
    {
        pIManager.SetItems(displayRule.items,displayRule.isHorizon);
    }
    private void Update()
    {
        if (pIManager.isNextFase)
        {
            if(pIManager.isLoad)//���[�h
            {
                var loadName = SceneManager.GetActiveScene().name;
                if (nowFase == Fase.clear) //�N���A�̎��������̃V�[��������
                {
                    loadName = pIManager.GetNextLoadStageName();
                }
                StartCoroutine(fadeLoad.FadeOutAndLoad(loadName));
            }

            //�J�E���g�_�E���I��
            if (nowFase == Fase.countDown && countProccesor.isEndCountDown) 
            {
                nowFase = Fase.playFlight;
            }
            else
            {
                nowFase = pIManager.GetNextFase();
            }
            //����
            switch (nowFase)
            {
                case Fase.displayRule:
                    Debug.Log("�Ȃ񂩂�������");
                    break;
                case Fase.countDown:
                    pIManager.SetItems(count.items,count.isHorizon);
                    break;
                case Fase.playFlight:
                    pIManager.SetItems(playFlight.items,playFlight.isHorizon);
                    break;
                case Fase.gameOver:
                    pIManager.SetItems(gameOver.items,gameOver.isHorizon);
                    break;
                case Fase.clear:
                    pIManager.SetItems(clear.items,clear.isHorizon);
                    break;
                default:
                    break;
            }
        }
    }
}