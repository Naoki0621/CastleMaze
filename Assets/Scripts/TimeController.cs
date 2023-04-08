using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制限時間に関するスクリプト
//Canvasにアタッチ

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; //true=カウントダウン計測
    public float gameTime = 0; //初期タイム
    public bool isTimeOver = false; //true=タイマー停止
    public float displayTime = 0; //表示時間

    private float times = 0; //現在の時間

    public static float resultTime; //リザルト画面用タイム

    // Start is called before the first frame update
    //制限時間を決め、表示時間にセットする
    void Start()
    {
        //カウントダウン計測するなら
        if(isCountDown)
        {
            displayTime = gameTime; //表示時間を初期タイムに設定
        }
    }

    // Update is called once per frame

    void Update()
    {
        //タイマーは動いている
        if(isTimeOver == false)
        {
            times += Time.deltaTime; //現在の時間が1秒ずつ増える(=経過時間)
            resultTime = times; //リザルト画面用タイムにセットする

            //カウントダウン中
            if(isCountDown)
            {
                displayTime = gameTime - times; //表示時間は、初期タイムと経過時間の差

                //表示時間が0になったら
                if(displayTime <= 0.0f)
                {
                    displayTime = 0.0f; //表示時間を0に留める
                    isTimeOver = true; //タイマー停止
                }
            }
        }
    }
}
