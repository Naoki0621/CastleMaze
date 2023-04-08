using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//�v���C���[����Ɋւ���X�N���v�g
//Player�ɃA�^�b�`
//��Ԃ̐؂�ւ���e�L�X�g�A�T�E���h�\�����s��

public class PlayerController : MonoBehaviour
{
    public float speed = 6.0f; //�v���C���[�̈ړ��X�s�[�h
    public float angleSpeed = 2.0f; //�A���O���X�s�[�h
    public float jumpSpeed = 8.0f; //�W�����v��
    public float gravity = 20.0f; //�d��

    public static string gameState = "playing"; //�Q�[���̏��
    public int coins = 0; //�d�݂̖���
    public static int resultCoin; //���U���g��ʕ\���p�̍d��

    public GameObject overText; //�Q�[���I�[�o�[�e�L�X�g
    public GameObject clearText; //�Q�[���N���A�e�L�X�g
    public GameObject coinText; //�R�C���e�L�X�g
    public GameObject retryButton; //���g���C�{�^��
    public GameObject resultButton; //���U���g�{�^��

    public AudioClip jumpSound; //�W�����v��
    public AudioClip deathSound; //���S��
    public AudioClip coinGet; //�d�݃Q�b�g�I��

    private CharacterController controller; //�L�����N�^�[�R���g���[���[�g�p
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        //CharacterController�擾
        controller = GetComponent<CharacterController>();

        //���g���C�A���U���g�{�^����\��
        retryButton.SetActive(false);
        resultButton.SetActive(false);

        gameState = "playing"; //�ŏ��̏�Ԃ́u�v���C���v

    }

    // Update is called once per frame
    void Update()
    {
        //�v���C���Ȃ瑀��\
        if(gameState == "playing")
        {
            //�v���C���[����
            if (controller.isGrounded)
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * angleSpeed, 0); //�㉺�L�[�ŃA���O������
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); //���E�L�[�ňړ�����
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;

                //�X�y�[�X�ŃW�����v����
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

    //�v���C���[�̐ڐG����
    private void OnTriggerEnter(Collider collision)
    {
        //Dead�^�O�̃I�u�W�F�N�g�ɐG�ꂽ��Q�[���I�[�o�[
        if (collision.gameObject.tag == "Dead")
        {
            isGameOver();
            GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
        //Chest�^�O�̃I�u�W�F�N�g�ɐG�ꂽ��N���A
        if (collision.gameObject.tag == "Chest")
        {
            isGameClear();
        }
        //�d�݂����
        if (collision.gameObject.tag == "Coin")
        {
            coins++; //�d�ݐ��̑���
            resultCoin = coins; //���U���g��ʕ\���p�̍d�݂��X�V
            coinText.GetComponent<Text>().text = coins.ToString(); //�u�v���C���v��Ԃōd�ݐ���\��
            GetComponent<AudioSource>().PlayOneShot(coinGet);
            Destroy(collision.gameObject);

        }
    }

    //�Q�[���I�[�o�[
    public void isGameOver()
    {
        gameState = "gameover"; //�u�Q�[���I�[�o�[�v���
        overText.GetComponent<Text>().text = "����ł��܂���"; //�e�L�X�g�X�V
        overText.SetActive(true); //�Q�[���I�[�o�[�e�L�X�g�\��
        retryButton.SetActive(true); //���g���C�{�^���\��
    }

    //�Q�[���N���A
    public void isGameClear()
    {
        gameState = "gameclear"; //�u�Q�[���N���A�v���
        clearText.GetComponent<Text>().text = "�S�[��!!"; //�e�L�X�g�X�V
        clearText.SetActive(true); //�Q�[���N���A�e�L�X�g�\��
        resultButton.SetActive(true);//���U���g�{�^���\��
    }

    //���g���C�{�^���������ƃV�[�����ēǂݍ���
    public void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
