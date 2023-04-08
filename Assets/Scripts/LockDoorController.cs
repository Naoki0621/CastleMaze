using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//鍵ドアに関するスクリプト
//CollisionCheck(LockDoorの子)にアタッチ

public class LockDoorController : MonoBehaviour
{
    public GameObject door; //鍵ドア
    public GameObject keyCheck; //鍵入手テキスト

    private KeyManager key; //鍵スクリプト

    // Start is called before the first frame update
    void Start()
    {
        //オブジェクト「key_gold」の「KeyManager]スクリプトを取得
        key = GameObject.Find("key_gold").GetComponent<KeyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //プレイヤーが接触かつ鍵を取得していると鍵ドアは開く
    void OnTriggerEnter(Collider collision)
    {
        //接触したのがプレイヤーなら
        if(collision.gameObject.tag == "Player")
        {
            //鍵を取得していたなら
            if(key.getKey)
            {
                door.transform.Rotate(0, -5, 0); //鍵ドアが開くようになる
            }
            //鍵を取得していないなら
            else
            {
                keyCheck.GetComponent<Text>().text = "鍵を入手して下さい。"; //テキスト更新
                keyCheck.SetActive(true); //鍵入手テキストを表示
                Invoke("TextDelete", 3); //テキストを3秒後に消す
            }
        }
    }

    //テキストを非表示に
    void TextDelete()
    {
        keyCheck.SetActive(false); //鍵入手テキストを非表示に
    }
}
