using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//ゲームクリアBGMに関するスクリプト
//ClearBGMにアタッチ
//ゴールすると流れ始め、リザルト画面まで続く
//タイトル画面に戻ると、音は消える

public class ClaerBGM : MonoBehaviour
{
    //シーンをまたいでも流れる
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //タイトル画面に戻ると音を消す
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
        }
    }
}
