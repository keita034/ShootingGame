using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    //�G�̐��𐔂���p�̕ϐ�
    private GameObject[] enemy;
    //�p�l����o�^����
    public GameObject panel;
    public GameObject panel1;

    // Start is called before the first frame update
    void Start()
    {
        //�p�l�����B��
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.R))
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(activeSceneName);
        }

        //�V�[���ɑ��݂��Ă���Enemy�^�O�������Ă���I�u�W�F�N�g
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //�V�[����1�C��Enemy�����Ȃ��Ȃ�����
        if (enemy.Length == 0)
        {
            //�p�l����\��������
            panel.SetActive(true);
            panel1.SetActive(true);
        }
    }
}
