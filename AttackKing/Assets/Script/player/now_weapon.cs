using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class now_weapon : base_weapon
{
    [Header("������܂ł̎���")] public int delete_time;

    [Header("�ړ����x")] public int sord_speed;

    [Header("��������X�L��")] public GameObject skill;



    [System.NonSerialized] public WeaponData WeaponData;            //����f�[�^�쐬

    //�N���[������I�u�W�F�N�g
    private GameObject clone;

    //�܂�Ԃ��܂ł̎���
    private int time = 0;

    //���ꂪ�^�̂Ƃ��U���ł���
    private bool atack_flag = true;

    //�U����������x�N�g��
    private Vector3 mem_shotForward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //�U������
        if (atack_flag == true)
        {
            // �N���b�N�������W�̎擾�i�X�N���[�����W���烏�[���h���W�ɕϊ��j
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // �����̐����iZ�����̏����Ɛ��K���j
            Vector3 shotForward = Vector3.Scale((mouseWorldPos - transform.position), new Vector3(1, 1, 0)).normalized;
            mem_shotForward = shotForward;

            // �e�ɑ��x��^����
            this.gameObject.GetComponent<Rigidbody2D>().velocity = shotForward * sord_speed;

            // transform���擾
            Transform cloneTransform = this.gameObject.transform;

            // ���[���h���W����ɁA��]���擾
            Vector3 worldAngle = cloneTransform.eulerAngles;
            worldAngle.z = GetAim(transform.position, mouseWorldPos) + 135; // ���[���h���W����ɁAz�������ɂ�����]��10�x�ɕύX
            cloneTransform.eulerAngles = worldAngle; // ��]�p�x��ݒ�

            atack_flag = false;
        }

        //�o�����Ԃ̐܂�Ԃ��܂ł���Ɩ߂��Ă���
        if (time == (delete_time / 2))
        {
            this.gameObject.GetComponent<Rigidbody2D>().velocity = -mem_shotForward * sord_speed;
        }
        
        //����
        time++;
        if (time == delete_time)
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            atack_flag = true;
            time = 0;
        }

    }

    /// <summary>
    /// ��_�Ԃ̊p�x�����߂�֐�
    /// </summary>
    /// <param name="p1">���_�ƂȂ�I�u�W�F�N�g���W</param>
    /// <param name="p2">�p�x�����߂����I�u�W�F�N�g���W</param>
    /// <returns>z��_�Ԃ̊p�x</returns>
    public float GetAim(Vector3 p1, Vector3 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }
}
