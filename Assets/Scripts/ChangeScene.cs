using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�V�[���̐؂�ւ��X�N���v�g
//�{�^���ɃA�^�b�`
//sceneName�ɐ؂�ւ��������O�����

public class ChangeScene : MonoBehaviour
{
    public string sceneName; //�V�[���̖��O

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //�V�[���̐؂�ւ�
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
