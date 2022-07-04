using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;
    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;
    //1��őł��o���e�̐������߂�
    public int bulletWayNum = 3;
    //�ł��o���e�̊Ԋu�𒲐�����
    public float bulletWaySpace = 30;
    //�ł��o���Ԋu�����߂�
    public float time = 1;
    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;
    //���݂̃^�C�}�[����
    float nowTime = 0;

    // Start is called before the first frame update
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
            //�v���W�F�N�g��Player��T���ď����擾����
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //�^�C�}�[�����炷
        if (transform.position.z <= 20)
        {
            nowTime -= Time.deltaTime;
        }
        //�����^�C�}�[��0�ȉ��ɂȂ�����
        if (nowTime <= 0)
        {
            // �p�x�����p�̕ϐ�
            float bulletWaySpaceSplit = 0;
            //���Ŕ��˂���e�����������[�v����
            for (int i = 0; i < bulletWayNum; i++)
            {
                //�e�𐶐�
                CreateShot0bject(bulletWaySpace - bulletWaySpaceSplit + transform.localEulerAngles.y);
                //�p�x�𒲐�����
                bulletWaySpaceSplit += (bulletWaySpace / (bulletWayNum - 1)) * 2;
            }

            //�^�C�}�[��������
            nowTime = time;
        }

    }

    private void CreateShot0bject(float axis)
    {
        //�x�N�g�����擾
        var direction = player.transform.position - transform.position;
        //�x�N�g����y��������
        direction.y = 0;
        //�������擾����
        var lookRotation = Quaternion.LookRotation(direction, Vector3.up);
        //�e�𐶐�����
        GameObject bulletClone =
        Instantiate(bullet, transform.position, Quaternion.identity);
        //EnemyBullet�̃Q�b�g�R���|�[�l���g��ϐ��Ƃ��ĕۑ�
        var bullet0bject = bulletClone.GetComponent<EnemyBullet>();
        //�e��ł��o�����I�u�W�F�N�g�̏���n��
        bullet0bject.SetCharacter0bject(gameObject);
        //�e��ł��o���p�x��ύX����
        bullet0bject.SetForwardAxis(lookRotation * Quaternion.AngleAxis(axis, Vector3.up));
    }
}
