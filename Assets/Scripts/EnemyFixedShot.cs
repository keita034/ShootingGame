using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //プレイヤー
    private GameObject player;
    //弾のゲームオブジェクトを入れる
    public GameObject bullet;
    //1回で打ち出す弾の数を決める
    public int bulletWayNum = 3;
    //打ち出す弾の間隔を調整する
    public float bulletWaySpace = 30;
    //打ち出す弾の角度を調整する
    public int bulletWayAxis = 0;
    //打ち出す間隔を決める
    public float time = 1;
    //最初に打ち出すまでの時間を決める
    public float delayTime = 1;
    //現在のタイマー時間
    float nowTime = 0;


    // Start is called before the first frame update
    //スタート関数
    void Start()
    {
        //タイマーを初期化
        nowTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //もしプレイヤーの情報が入ってなかったら
        if (player == null)
        {
            //プロジェクトのplayerを探して情報を取得する
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //タイマーを減らす
        if (transform.position.z <= 20)
        {
            nowTime -= Time.deltaTime;
        }
        //もしタイマーが以下になったら
        if (nowTime <= 0)
        {
            //角度調整用の変数
            float bulletWaySpaceSplit = 0;

            //一回で発射する弾数分だけループする
            for (int i = 0; i < bulletWayNum; i++)
            {
                //弾を生成
                CreateShotObject(
                bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);
                //角度を調整する
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }

            //タイマーを初期化
            nowTime = time;
        }

    }

    private void CreateShotObject(float axis)
    {
        //弾を生成する
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);
        //EnemyBulletのゲットコンポーネントを変数として保存
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();
        //弾を打ち出したオブジェクトの情報を渡す
        bulletObject.SetCharacter0bject(gameObject);
        //弾を打ち出す角度を変更する
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}

