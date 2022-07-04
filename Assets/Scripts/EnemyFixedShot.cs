using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFixedShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;
    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;
    //1��őł��o���e�̐������߂�
    public int bulletWayNum = 3;
    //�ł��o���e�̊Ԋu�𒲐�����
    public float bulletWaySpace = 30;
    //�ł��o���e�̊p�x�𒲐�����
    public int bulletWayAxis = 0;
    //�ł��o���Ԋu�����߂�
    public float time = 1;
    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;
    //���݂̃^�C�}�[����
    float nowTime = 0;


    // Start is called before the first frame update
    //�X�^�[�g�֐�
    void Start()
    {
        //�^�C�}�[��������
        nowTime = delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        //�����v���C���[�̏�񂪓����ĂȂ�������
        if (player == null)
        {
            //�v���W�F�N�g��player��T���ď����擾����
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //�^�C�}�[�����炷
        if (transform.position.z <= 20)
        {
            nowTime -= Time.deltaTime;
        }
        //�����^�C�}�[���ȉ��ɂȂ�����
        if (nowTime <= 0)
        {
            //�p�x�����p�̕ϐ�
            float bulletWaySpaceSplit = 0;

            //���Ŕ��˂���e�����������[�v����
            for (int i = 0; i < bulletWayNum; i++)
            {
                //�e�𐶐�
                CreateShotObject(
                bulletWaySpace - bulletWaySpaceSplit + bulletWayAxis - transform.localEulerAngles.y);
                //�p�x�𒲐�����
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }

            //�^�C�}�[��������
            nowTime = time;
        }

    }

    private void CreateShotObject(float axis)
    {
        //�e�𐶐�����
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);
        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bulletObject = bulletClone.GetComponent<EnemyBullet>();
        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bulletObject.SetCharacter0bject(gameObject);
        //�e��ł��o���p�x��ύX����
        bulletObject.SetForwardAxis(Quaternion.AngleAxis(axis, Vector3.up));
    }
}
