using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MainCamera�ɃA�^�b�`
//�J�����͈�l�̎��_
//���C���J�����̓v���C���[����

public class CameraController : MonoBehaviour
{
    public GameObject player; //�v���C���[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //�J�����̓v���C���[�ɒǏ]����
    void Update()
    {
        this.transform.position = player.transform.position;
    }
}
