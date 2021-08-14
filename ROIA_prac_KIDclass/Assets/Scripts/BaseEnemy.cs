using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �ĤH�����O
/// �\��G�H�����ʡB���ݡB�l�ܪ��a�B���˻P���`
/// ���A���G�C�| Enum�B�P�_�� switch (��¦�y�k)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region ���
    [Header("�򥻯�O")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    /// <summary>
    /// �H�����ݽd��
    /// </summary>
    public Vector2 v2RandomIdle = new Vector2(1, 5);
    /// <summary>
    /// �H�������d��
    /// </summary>
    public Vector2 v2RandomWalk = new Vector2(3, 6);

    //  public KeyCode key;
    [SerializeField]
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    /// <summary>
    /// ���ݮɶ��G�H��
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// ���ݥέp�ɾ�
    /// </summary>
    private float timerIdle;
    /// <summary>
    /// �����ɶ��G�H��
    /// </summary>
    private float timeWalk;
    /// <summary>
    /// �����έp�ɾ�
    /// </summary>
    private float timerWalk;

    #endregion

    #region �ƥ�

    private void Start()
    {
        #region ��l�ȳ]�w
        timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
        #endregion
    }

    private void Update()
    {
        CheckState();
    }

    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }

    #endregion

    #region ��k
    /// <summary>
    /// �ˬd���A
    /// </summary>
    private void CheckState() 
    {
        //  ����k�r �� switch �� TAB ��J(XXX) TAB
          switch (state)
        {
            case StateEnemy.idle:
                break;
            case StateEnemy.walk:
                break;
            case StateEnemy.track:
                break;
            case StateEnemy.attack:
                break;
            case StateEnemy.death:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// ���ݡG�H����ƫ�i�J�쨫�����A
    /// </summary>
    private void Idle()
    {
        if(timerIdle < timeIdle)                //  �p�G �p�ɾ� < ���ݮɶ�
        {
            timerIdle += Time.deltaTime;        //  �֥[�ɶ�
            ani.SetBool("�����}��", false);      //  ���������}���A���ݰʵe
            print("����");
        }
        else                                                            //  �_�h
        {
            RandomDirection();                                          //  �H����V
            state = StateEnemy.walk;                                    //  �������A
            timeWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);    //  �����H�������ɶ�
            timerIdle = 0;                                              //  �p�ɾ��k�s

        }
        
    }
    /// <summary>
    /// �H������
    /// </summary>
    private void Walk()
    {
        if(timerWalk < timeWalk)
        {
            timerWalk += Time.deltaTime;
            ani.SetBool("�����}��", true);                                 // �}�Ҩ����}���G�����ʵe
            // rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;        
            // rig.velocity = transform.forward * speed * Time.deltaTime;  3D �`��
        }
        else
        {
                                               
            state = StateEnemy.idle;
            rig.velocity = Vector2.zero;
            timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
            timerWalk = 0;

        }
        print("����");
    }
    /// <summary>
    /// �N���z�欰��W�B�̨æb FixedUpdate �G��;
    /// </summary>
    private void WalkInFixedUpdate()
    {
        //  �p�G �ثe���A ������ �N ����.�[�t�� = �t�� * 1/50 + �W�� * �a�ߤޤO
        if (state == StateEnemy.walk) rig.velocity = transform.right * speed * Time.fixedDeltaTime + Vector3.up * rig.velocity.y;
    }
    /// <summary>
    /// �H����V�G�H���ӦV�k��Υ���
    /// �k��G0 , 0 , 0
    /// ����G0, 180, 0
    /// </summary>
    private void RandomDirection()
    {
        int random = Random.Range(0, 2);    //  �H��.�d��(�̤p,�̤j) - ��Ʈɤ��]�t�̤j�� (0, 2) - �H�����o 0 �� 1

        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;

    }

    #endregion

}


//  �w�q�C�|
//  1.�ϥ�����r enum �w�q�C�|�H�Υ]�t���ﶵ�B�i�H�b���O�~�w�q
//  2.�ݭn���@�����w�q�����C�|����
//  �y�k�G�׹��� enum �C�|�W {�ﶵ1�B�ﶵ2�K�B�ﶵN}
public enum StateEnemy
{
    idle, walk, track, attack, death
}