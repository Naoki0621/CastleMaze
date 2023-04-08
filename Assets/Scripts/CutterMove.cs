using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//移動カッターギミックに関するスクリプト
//Cutterにアタッチ

public class CutterMove : MonoBehaviour
{
    public float speed = 1.0f; //移動スピード
    public float range = 0.0f; //移動範囲
    public string direction = "right"; //最初は左右どちらに動くか
    private Vector3 defPos; //移動カッターの初期座標

    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.position; //移動カッターの初期位置
    }

    // Update is called once per frame
    void Update()
    {
        //移動範囲は正の値
        if (range > 0.0f)
        {
            //現在地が移動範囲を超えようとすると、向きを変える
            if (transform.position.z < defPos.z - (range / 2))
            {
                direction = "right";
            }
            if (transform.position.z > defPos.z + (range / 2))
            {
                direction = "left";
            }

            transform.GetChild(1).gameObject.transform.Rotate(0, 5, 0); //ポール部分を常に回転させる
        }
    }

    void FixedUpdate()
    {
        //カッターを移動させる
        if (direction == "right")
        {
            transform.Translate(0, 0, speed);
        }
        else
        {
            transform.Translate(0, 0, -speed);
        }
    }
}
