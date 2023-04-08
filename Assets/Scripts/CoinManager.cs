using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//硬貨スクリプト
//Coinにアタッチ
//硬貨をy軸回転させる

public class CoinManager : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //硬貨を常にy軸回転
    void Update()
    {
        transform.Rotate(0, 1, 0);
    }

    
}
