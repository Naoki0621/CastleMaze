using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//���h�A�Ɋւ���X�N���v�g
//CollisionCheck(LockDoor�̎q)�ɃA�^�b�`

public class LockDoorController : MonoBehaviour
{
    public GameObject door; //���h�A
    public GameObject keyCheck; //������e�L�X�g

    private KeyManager key; //���X�N���v�g

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�ukey_gold�v�́uKeyManager]�X�N���v�g���擾
        key = GameObject.Find("key_gold").GetComponent<KeyManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�v���C���[���ڐG�������擾���Ă���ƌ��h�A�͊J��
    void OnTriggerEnter(Collider collision)
    {
        //�ڐG�����̂��v���C���[�Ȃ�
        if(collision.gameObject.tag == "Player")
        {
            //�����擾���Ă����Ȃ�
            if(key.getKey)
            {
                door.transform.Rotate(0, -5, 0); //���h�A���J���悤�ɂȂ�
            }
            //�����擾���Ă��Ȃ��Ȃ�
            else
            {
                keyCheck.GetComponent<Text>().text = "������肵�ĉ������B"; //�e�L�X�g�X�V
                keyCheck.SetActive(true); //������e�L�X�g��\��
                Invoke("TextDelete", 3); //�e�L�X�g��3�b��ɏ���
            }
        }
    }

    //�e�L�X�g���\����
    void TextDelete()
    {
        keyCheck.SetActive(false); //������e�L�X�g���\����
    }
}
