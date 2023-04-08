using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���X�N���v�g
//key_gold�ɃA�^�b�`

public class KeyManager : MonoBehaviour
{
    public bool getKey = false; //���擾�t���O
    public GameObject keyCheck; //������e�L�X�g

    public AudioClip getSound; //������T�E���h

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�v���C���[���ڐG����ƌ������ł����擾�t���O������
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player" && !getKey)
        {
            getKey = true; //������t���O�𗧂Ă�
            keyCheck.GetComponent<Text>().text = "������肵�܂����B"; //�e�L�X�g�X�V
            keyCheck.SetActive(true); //������e�L�X�g�\��
            Invoke("TextDelete", 2); //�e�L�X�g��2�b��ɏ���
            AudioSource.PlayClipAtPoint(getSound, transform.position); //�T�E���h
            transform.GetChild(0).gameObject.SetActive(false);  //�q�I�u�W�F�N�g����\����
        }
    }

    //�e�L�X�g���\����
    void TextDelete()
    {
        keyCheck.SetActive(false); //������e�L�X�g���\����
    }
}
