using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーンの切り替えスクリプト
//ボタンにアタッチ
//sceneNameに切り替えたい名前を入力

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //シーンの名前

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //シーンの切り替え
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
