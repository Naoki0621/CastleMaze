using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���ʉ�ʂɊւ���X�N���v�g
//ResultObject�ɃA�^�b�`

public class ResultScore : MonoBehaviour
{
    public Text resultTime; //���U���g�^�C���e�L�X�g
    public Text resultCoin; //���U���g�R�C���e�L�X�g
    public Text resultTotal; //���U���g�g�[�^���e�L�X�g
    public AudioClip resultSE; //���U���gSE
    public GameObject titleButton; //�^�C�g���{�^��

    int time; //�N���A����
    int coin; //�l���d�ݐ�
    int total; //�����X�R�A

    // Start is called before the first frame update
    void Start()
    {
        titleButton.SetActive(false); //�^�C�g���{�^����\��
        time = (int)TimeController.resultTime; //TimeController��resultTime�Q��
        coin = PlayerController.resultCoin; //PlayerController��resultCoin�Q��

        total = (100 - time) * 10 + (coin * 50); //�����X�R�A�̌v�Z

        //���ʂ�\��
        Invoke("ResultTime", 1.0f); //1�b��ɕ\��
        Invoke("ResultCoin", 2.0f); //2�b��ɕ\��
        Invoke("ResultTotal", 3.0f); //3�b��ɕ\��
        Invoke("Button", 3.0f); //3�b��ɕ\��
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //�N���A���Ԃ̕\��
    void ResultTime()
    {
        resultTime.text = string.Format("�N���A���� : {0} �b", time); //���U���g�^�C���e�L�X�g�X�V
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SE�Ȃ炷
    }

    //�l���d�ݐ��̕\��
    void ResultCoin()
    {
        resultCoin.text = string.Format("�l���d�ݐ� : {0} ��", coin); //���U���g�R�C���e�L�X�g�X�V
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SE�Ȃ炷
    }

    //�����X�R�A�̕\��
    void ResultTotal()
    {
        resultTotal.text = string.Format("�����X�R�A : {0} �_", total); //���U���g�g�[�^���e�L�X�g�X�V
        GetComponent<AudioSource>().PlayOneShot(resultSE); //SE�Ȃ炷
    }

    //�{�^���̕\��
    void Button()
    {
        titleButton.SetActive(true); //�^�C�g���{�^����\��
    }
}
