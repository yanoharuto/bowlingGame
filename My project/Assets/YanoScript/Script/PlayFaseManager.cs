using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// 
/// </summary>
public class PlayFaseManager : MonoBehaviour
{
    public enum Fase
    {
        fadeOut,
        displayRule,
        countDown,
        playFlight,
        gameOver,
        clear,
        menu,
        fadeIn
    }
    public static Fase nowFade { get; private set; } = Fase.fadeOut;
    [SerializeField] PlayFase displayRule;
    [SerializeField] PlayFase playFlight;
    [SerializeField] PlayFase gameOver;
    [SerializeField] PlayFase clear;
    [SerializeField] PlayFase count;
    [SerializeField] CountDown countProccesor;
    [SerializeField] PlayMenu menu;
    [SerializeField] PlayItemManager pIManager;
    [SerializeField] FadeAndLoader fadeLoad;
    [SerializeField] GameOverProcessor gameOverProccesor;
    [SerializeField] RouteManager rManager;
    [SerializeField] Fade fade;
    [SerializeField] Image fadeOut;
    public static bool isLoad { get; private set; }  
    private void Start()
    {
        pIManager.SetItems(displayRule.items,displayRule.isHorizon);
    }
    private void Update()
    {        
        var tempFase = nowFade;
        Debug.Log(nowFade);
        Debug.Log(rManager.isGetRingPerfect);
        if (nowFade == Fase.fadeIn && fadeOut.color.a >= 0.99f) 
        {
            nowFade = Fase.fadeOut;
        }
        else if(nowFade!=Fase.fadeIn&& rManager.isGetRingPerfect)
        {
            nowFade = Fase.fadeIn;
            fadeLoad.FadeInAndLoad("ResultScene");
        }
        else if (pIManager.isNextFase)
        {
            if (pIManager.isLoad)//ロード
            {
                var loadName = pIManager.GetNextLoadStageName();
                Debug.Log(loadName);
                nowFade = Fase.fadeIn;
                fadeLoad.FadeInAndLoad(loadName);
            }
            else
            {
                nowFade = pIManager.GetNextFase();
            }
        }
        //ゲームオーバー
        else if (!gameOverProccesor.isFlyShipAlive)
        {
            nowFade = Fase.gameOver;
        }
        //カウントダウン終了
        else if (nowFade == Fase.countDown)
        {
            if (countProccesor.isEndCountDown)
            {
                nowFade = Fase.playFlight;
            }
        }
        else if (nowFade == Fase.fadeOut)
        {
            var c = fadeOut.color;
            c.a -= 0.1f;
            fadeOut.color = c;
            if (c.a <= 0.01f)
            {
                nowFade = Fase.displayRule;

            }
        }
        if (nowFade != tempFase)
        {
            //分岐
            switch (nowFade)
            {
                case Fase.displayRule:
                    break;
                case Fase.countDown:
                    pIManager.SetItems(count.items, count.isHorizon);
                    break;
                case Fase.playFlight:
                    pIManager.SetItems(playFlight.items, playFlight.isHorizon);
                    break;
                case Fase.gameOver:
                    pIManager.SetItems(gameOver.items, gameOver.isHorizon);
                    break;
                case Fase.clear:
                    pIManager.SetItems(clear.items, clear.isHorizon);
                    break;
                default:
                    break;
            }
        }
    }
}