using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//鍵スクリプト
//key_goldにアタッチ

public class KeyManager : MonoBehaviour
{
    public bool getKey = false; //鍵取得フラグ
    public GameObject keyCheck; //鍵入手テキスト

    public AudioClip getSound; //鍵入手サウンド

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //プレイヤーが接触すると鍵が消滅し鍵取得フラグがたつ
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" && !getKey)
        {
            getKey = true; //鍵入手フラグを立てる
            keyCheck.GetComponent<Text>().text = "鍵を入手しました。"; //テキスト更新
            keyCheck.SetActive(true); //鍵入手テキスト表示
            Invoke("TextDelete", 2); //テキストを2秒後に消す
            AudioSource.PlayClipAtPoint(getSound, transform.position); //サウンド
            transform.GetChild(0).gameObject.SetActive(false);  //子オブジェクトも非表示に
        }
    }

    //テキストを非表示に
    void TextDelete()
    {
        keyCheck.SetActive(false); //鍵入手テキストを非表示に
    }
}
