using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ԂɊւ���X�N���v�g
//Canvas�ɃA�^�b�`

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; //true=�J�E���g�_�E���v��
    public float gameTime = 0; //�����^�C��
    public bool isTimeOver = false; //true=�^�C�}�[��~
    public float displayTime = 0; //�\������

    private float times = 0; //���݂̎���

    public static float resultTime; //���U���g��ʗp�^�C��

    // Start is called before the first frame update
    //�������Ԃ����߁A�\�����ԂɃZ�b�g����
    void Start()
    {
        //�J�E���g�_�E���v������Ȃ�
        if(isCountDown)
        {
            displayTime = gameTime; //�\�����Ԃ������^�C���ɐݒ�
        }
    }

    // Update is called once per frame

    void Update()
    {
        //�^�C�}�[�͓����Ă���
        if(isTimeOver == false)
        {
            times += Time.deltaTime; //���݂̎��Ԃ�1�b��������(=�o�ߎ���)
            resultTime = times; //���U���g��ʗp�^�C���ɃZ�b�g����

            //�J�E���g�_�E����
            if(isCountDown)
            {
                displayTime = gameTime - times; //�\�����Ԃ́A�����^�C���ƌo�ߎ��Ԃ̍�

                //�\�����Ԃ�0�ɂȂ�����
                if(displayTime <= 0.0f)
                {
                    displayTime = 0.0f; //�\�����Ԃ�0�ɗ��߂�
                    isTimeOver = true; //�^�C�}�[��~
                }
            }
        }
    }
}
