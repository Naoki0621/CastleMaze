using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�ړ��J�b�^�[�M�~�b�N�Ɋւ���X�N���v�g
//Cutter�ɃA�^�b�`

public class CutterMove : MonoBehaviour
{
    public float speed = 1.0f; //�ړ��X�s�[�h
    public float range = 0.0f; //�ړ��͈�
    public string direction = "right"; //�ŏ��͍��E�ǂ���ɓ�����
    private Vector3 defPos; //�ړ��J�b�^�[�̏������W

    // Start is called before the first frame update
    void Start()
    {
        defPos = transform.position; //�ړ��J�b�^�[�̏����ʒu
    }

    // Update is called once per frame
    void Update()
    {
        //�ړ��͈͂͐��̒l
        if (range > 0.0f)
        {
            //���ݒn���ړ��͈͂𒴂��悤�Ƃ���ƁA������ς���
            if (transform.position.z < defPos.z - (range / 2))
            {
                direction = "right";
            }
            if (transform.position.z > defPos.z + (range / 2))
            {
                direction = "left";
            }

            transform.GetChild(1).gameObject.transform.Rotate(0, 5, 0); //�|�[����������ɉ�]������
        }
    }

    void FixedUpdate()
    {
        //�J�b�^�[���ړ�������
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
