using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainCameraにアタッチ
//カメラは一人称視点
//メインカメラはプレイヤー内に

public class CameraController : MonoBehaviour
{
    public GameObject player; //プレイヤー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //カメラはプレイヤーに追従する
    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
