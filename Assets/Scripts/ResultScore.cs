using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//結果画面に関するスクリプト
//ResultObjectにアタッチ

public class ResultScore : MonoBehaviour
{
    public Text resultTime; //リザルトタイムテキスト
    public Text resultCoin; //リザルトコインテキスト
    public Text resultTotal; //リザルトトータルテキスト
    public AudioClip resultSE; //リザルトSE
    public GameObject titleButton; //タイトルボタン

    int time; //クリア時間
    int coin; //獲得硬貨数
    int total; //総合スコア

    // Start is called before the first frame update
    void Start()
    {
        titleButton.SetActive(false); //タイトルボタン非表示
        time = (int)TimeController.resultTime; //TimeControllerのresultTime参照
        coin = PlayerController.resultCoin; //PlayerControllerのresultCoin参照

        total = (100 - time) * 10 + (coin * 50); //総合スコアの計算

        //結果を表示
        Invoke("ResultTime", 1.0f); //1秒後に表示
        Invoke("ResultCoin", 2.0f); //2秒後に表示
        Invoke("ResultTotal", 3.0f); //3秒後に表示
        Invoke("Button", 3.0f); //3秒後に表示
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //クリア時間の表示
    void ResultTime()
    {
        resultTime.text = string.Format("クリア時間 : {0} 秒", time); //リザルトタイムテキスト更新
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SEならす
    }

    //獲得硬貨数の表示
    void ResultCoin()
    {
        resultCoin.text = string.Format("獲得硬貨数 : {0} 枚", coin); //リザルトコインテキスト更新
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SEならす
    }

    //総合スコアの表示
    void ResultTotal()
    {
        resultTotal.text = string.Format("総合スコア : {0} 点", total); //リザルトトータルテキスト更新
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SEならす
    }

    //ボタンの表示
    void Button()
    {
        titleButton.SetActive(true); //タイトルボタンを表示
    }
}
