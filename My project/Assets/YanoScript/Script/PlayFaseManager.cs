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
    public static Fase nowFase { get; private set; } = Fase.fadeOut;
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
    private void Start()
    {
        pIManager.SetItems(displayRule.items,displayRule.isHorizon);
        
    }
    private void Update()
    {        
        var tempFase = nowFase;
        if(rManager.isGetRingPerfect)
        {
            fadeLoad.FadeInAndLoad("ResultScene");
        }
        if (pIManager.isNextFase)
        {
            if (pIManager.isLoad)//ロード
            {
                var loadName = SceneManager.GetActiveScene().name;
                if (nowFase == Fase.clear) //クリアの時だけ次のシーンを所得
                {
                    loadName = pIManager.GetNextLoadStageName();
                }
                fadeLoad.FadeInAndLoad(loadName);
            }
            else
            {
                nowFase = pIManager.GetNextFase();
            }
        }
        //ゲームオーバー
        else if (!gameOverProccesor.isFlyShipAlive)
        {
            nowFase = Fase.gameOver;
        }
        //カウントダウン終了
        else if (nowFase == Fase.countDown)
        {
            if (countProccesor.isEndCountDown)
            {
                nowFase = Fase.playFlight;
            }
        }
        else if(nowFase==Fase.fadeOut)
        {
            var c = fadeOut.color;
            c.a-=0.1f;
            fadeOut.color = c;
            if (c.a <= 0.01f)
            {
                nowFase= Fase.displayRule;
                
            }
        }
        
        Debug.Log(nowFase);
        if (nowFase == tempFase)
        {
            //分岐
            switch (nowFase)
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