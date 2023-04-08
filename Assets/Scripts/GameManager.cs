using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//プレイ中のUIやBGM、時間管理に関するスクリプト
//Canvasにアタッチ

public class GameManager : MonoBehaviour
{
    public GameObject timebar; //タイムバー
    public GameObject timeText; //タイムテキスト
    public GameObject clearBGM; //クリアBGM

    private TimeController timeCtrl; //タイムコントローラー

    private AudioSource playing; //ゲームプレイBGM

    // Start is called before the first frame update
    void Start()
    {
        //TimeController取得
        timeCtrl = GetComponent<TimeController>();

        //AudioSource取得
        playing = GetComponent<AudioSource>();

        //クリアBGM非表示
        clearBGM.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //「ゲームクリア」状態
        if (PlayerController.gameState == "gameclear")
        {
            //制限時間追加
            if (timeCtrl != null)
            {
                timeCtrl.isTimeOver = true; //タイマー停止
            }
            playing.Stop(); //ゲームプレイBGM停止
            clearBGM.SetActive(true); //クリアBGM再生
        }

        //「ゲームオーバー」状態
        else if(PlayerController.gameState == "gameover")
        {
            //制限時間追加
            if (timeCtrl != null)
            {
                timeCtrl.isTimeOver = true; //タイマー停止
            }
            playing.Stop(); //ゲームプレイBGM停止
            Destroy(clearBGM); //クリアBGM削除

        }

        //「プレイ中」状態
        else if(PlayerController.gameState == "playing")
        {
            //Playerオブジェクトを取得
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            //PlayerController取得
            PlayerController playerCtrl = player.GetComponent<PlayerController>();

            //制限時間追加
            if(timeCtrl != null)
            {
                //初期タイムは正の値
                if(timeCtrl.gameTime > 0.0f)
                {
                    int time = (int)timeCtrl.displayTime; //表示時間(整数)
                    timeText.GetComponent<Text>().text = time.ToString(); //テキスト更新

                    //表示時間が0になればゲームオーバー
                    if(time == 0)
                    {
                        playerCtrl.isGameOver();
                    }
                }
            }
            
        }
    }

}
