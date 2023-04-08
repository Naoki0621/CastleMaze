using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//プレイヤー操作に関するスクリプト
//Playerにアタッチ
//状態の切り替えやテキスト、サウンド表示も行う

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f; //プレイヤーの移動スピード
    public float angleSpeed = 2.0f; //アングルスピード
    public float jumpSpeed = 8.0f; //ジャンプ力
    public float gravity = 20.0f; //重力

    public static string gameState = "playing"; //ゲームの状態
    public int coins = 0; //硬貨の枚数
    public static int resultCoin; //リザルト画面表示用の硬貨

    public GameObject overText; //ゲームオーバーテキスト
    public GameObject clearText; //ゲームクリアテキスト
    public GameObject coinText; //コインテキスト
    public GameObject retryButton; //リトライボタン
    public GameObject resultButton; //リザルトボタン

    public AudioClip jumpSound; //ジャンプ音
    public AudioClip deathSound; //死亡音
    public AudioClip coinGet; //硬貨ゲットオ音

    private CharacterController controller; //キャラクターコントローラー使用
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //CharacterController取得
        controller = GetComponent<CharacterController>();

        //リトライ、リザルトボタン非表示
        retryButton.SetActive(false);
        resultButton.SetActive(false);

        gameState = "playing"; //最初の状態は「プレイ中」

    }

    // Update is called once per frame
    void Update()
    {
        //プレイ中なら操作可能
        if(gameState == "playing")
        {
            //プレイヤー操作
            if (controller.isGrounded)
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * angleSpeed, 0); //上下キーでアングル操作
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); //左右キーで移動操作
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                //スペースでジャンプ操作
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
                    GetComponent<AudioSource>().PlayOneShot(jumpSound);
                }
            }

            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    //プレイヤーの接触判定
    private void OnTriggerEnter(Collider collision)
    {
        //Deadタグのオブジェクトに触れたらゲームオーバー
        if (collision.gameObject.tag == "Dead")
        {
            isGameOver();
            GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
        //Chestタグのオブジェクトに触れたらクリア
        if (collision.gameObject.tag == "Chest")
        {
            isGameClear();
        }
        //硬貨を取る
        if (collision.gameObject.tag == "Coin")
        {
            coins++; //硬貨数の増加
            resultCoin = coins; //リザルト画面表示用の硬貨を更新
            coinText.GetComponent<Text>().text = coins.ToString(); //「プレイ中」状態で硬貨数を表示
            GetComponent<AudioSource>().PlayOneShot(coinGet);
            Destroy(collision.gameObject);

        }
    }

    //ゲームオーバー
    public void isGameOver()
    {
        gameState = "gameover"; //「ゲームオーバー」状態
        overText.GetComponent<Text>().text = "しんでしまった"; //テキスト更新
        overText.SetActive(true); //ゲームオーバーテキスト表示
        retryButton.SetActive(true); //リトライボタン表示
    }

    //ゲームクリア
    public void isGameClear()
    {
        gameState = "gameclear"; //「ゲームクリア」状態
        clearText.GetComponent<Text>().text = "ゴール!!"; //テキスト更新
        clearText.SetActive(true); //ゲームクリアテキスト表示
        resultButton.SetActive(true);//リザルトボタン表示
    }

    //リトライボタンを押すとシーンを再読み込み
    public void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
