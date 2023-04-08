using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�v���C����UI��BGM�A���ԊǗ��Ɋւ���X�N���v�g
//Canvas�ɃA�^�b�`

public class GameManager : MonoBehaviour
{
    public GameObject timebar; //�^�C���o�[
    public GameObject timeText; //�^�C���e�L�X�g
    public GameObject clearBGM; //�N���ABGM

    private TimeController timeCtrl; //�^�C���R���g���[���[

    private AudioSource playing; //�Q�[���v���CBGM

    // Start is called before the first frame update
    void Start()
    {
        //TimeController�擾
        timeCtrl = GetComponent<TimeController>();

        //AudioSource�擾
        playing = GetComponent<AudioSource>();

        //�N���ABGM��\��
        clearBGM.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //�u�Q�[���N���A�v���
        if (PlayerController.gameState == "gameclear")
        {
            //�������Ԓǉ�
            if (timeCtrl != null)
            {
                timeCtrl.isTimeOver = true; //�^�C�}�[��~
            }
            playing.Stop(); //�Q�[���v���CBGM��~
            clearBGM.SetActive(true); //�N���ABGM�Đ�
        }

        //�u�Q�[���I�[�o�[�v���
        else if(PlayerController.gameState == "gameover")
        {
            //�������Ԓǉ�
            if (timeCtrl != null)
            {
                timeCtrl.isTimeOver = true; //�^�C�}�[��~
            }
            playing.Stop(); //�Q�[���v���CBGM��~
            Destroy(clearBGM); //�N���ABGM�폜

        }

        //�u�v���C���v���
        else if(PlayerController.gameState == "playing")
        {
            //Player�I�u�W�F�N�g���擾
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            //PlayerController�擾
            PlayerController playerCtrl = player.GetComponent<PlayerController>();

            //�������Ԓǉ�
            if(timeCtrl != null)
            {
                //�����^�C���͐��̒l
                if(timeCtrl.gameTime > 0.0f)
                {
                    int time = (int)timeCtrl.displayTime; //�\������(����)
                    timeText.GetComponent<Text>().text = time.ToString(); //�e�L�X�g�X�V

                    //�\�����Ԃ�0�ɂȂ�΃Q�[���I�[�o�[
                    if(time == 0)
                    {
                        playerCtrl.isGameOver();
                    }
                }
            }
            
        }
    }

}
