using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�Q�[���N���ABGM�Ɋւ���X�N���v�g
//ClearBGM�ɃA�^�b�`
//�S�[������Ɨ���n�߁A���U���g��ʂ܂ő���
//�^�C�g����ʂɖ߂�ƁA���͏�����

public class ClaerBGM : MonoBehaviour
{
    //�V�[�����܂����ł������
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //�^�C�g����ʂɖ߂�Ɖ�������
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(gameObject);
        }
    }
}
