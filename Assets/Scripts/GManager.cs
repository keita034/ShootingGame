using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GManager : MonoBehaviour
{
    //敵の数を数える用の変数
    private GameObject[] enemy;
    //パネルを登録する
    public GameObject panel;
    public GameObject panel1;

    // Start is called before the first frame update
    void Start()
    {
        //パネルを隠す
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

        //シーンに存在しているEnemyタグを持っているオブジェクト
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        //シーンに1匹もEnemyがいなくなったら
        if (enemy.Length == 0)
        {
            //パネルを表示させる
            panel.SetActive(true);
            panel1.SetActive(true);
        }
    }
}
