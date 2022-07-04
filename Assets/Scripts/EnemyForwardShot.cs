using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyForwardShot : MonoBehaviour
{
    //�v���C���[
    private GameObject player;
    //�e�̃Q�[���I�u�W�F�N�g������
    public GameObject bullet;
    //�ł��o���Ԋu�����߂�
    public float time = 1;
    //�ŏ��ɑł��o���܂ł̎��Ԃ����߂�
    public float delayTime = 1;
    //���݂̃^�C�}�[����
    float nowtime = 0;

    // Start is called before the first frame update
    void Start()
    {
        //�^�C�}�[��������
        nowtime = delayTime;
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
            nowtime -= Time.deltaTime;
        }

        //�����^�C�}�[�����ɂȂ�����
        if (nowtime <= 0)
        {
            //�e�𐶐�
            createShot0bject(-transform.localEulerAngles.y);
            //�^�C�}�[��������
            nowtime = time;
        }
    }

    private void createShot0bject(float axis)
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
