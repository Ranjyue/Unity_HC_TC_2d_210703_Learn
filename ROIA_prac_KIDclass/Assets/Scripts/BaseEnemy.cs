using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// �ĤH�����O
/// �\��G�H�����ʡB���ݡB�l�ܪ��a�B���˻P���`
/// ���A���G�C�| Enum�B�P�_�� switch (��¦�y�k)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region ���

    #region ���G���}
    [Header("�򥻯�O")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    [Header("�ˬd�e��O�_����ê���Φa�O�y��")]
    public Vector3 checkForwardOffset;
    [Range(0, 1)]
    public float checkForwardRadius = 0.3f;

    /// <summary>
    /// �H�����ݽd��
    /// </summary>
    public Vector2 v2RandomIdle = new Vector2(1, 5);
    /// <summary>
    /// �H�������d��
    /// </summary>
    public Vector2 v2RandomWalk = new Vector2(3, 6);

    //  public int[] score;
    //  �{�Ѱ}�C
    //  �y�k�G�������[�W���A���A�Ҧp�Gint[]�Bfloat[]�Bstring[]�BVector2[]
    public Collider2D[] hits;
    /// <summary>
    /// �s��e��O�_�����]�t�a�O�B���x������
    /// </summary>
    public Collider2D[] hitResult;

    //  public KeyCode key;

    #endregion

    #region ���G�p�H
    [SerializeField]
    protected StateEnemy state;

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
    /// <summary>
    /// �����N�o�ɶ�
    /// </summary>
    public float cdAttack = 3;
    /// <summary>
    /// �������A
    /// </summary>
    private float timerAttack;
    #endregion

    #endregion



    #region �ƥ�

    private void Start()
    {
        #region ��l�ȳ]�w
        timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
        #endregion
    }

    protected virtual void Update()
    {
        CheckForward();
        CheckState();

    }

    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }
    //  �����O�������p�G�Ʊ�J���O�Ƽg��`�G
    //  1. �׹��������O public �� protected - �O�@ ���\�l���O�s��
    //  2. �K�[����r virtual ���� - ���\�l���O�Ƽg
    //  3. �l���O�ϥ� override �Ƽg
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f, 0.3f);
        //  transform.right ��e���󪺥k��(2D �Ҧ����e��B����b�Y)
        //  transform.up ��e���󪺤W�� (���b�Y)
        Gizmos.DrawSphere(
            transform.position +
            transform.right * checkForwardOffset.x +
            transform.up * checkForwardOffset.y, 
            checkForwardRadius);

        
    }

    #endregion



    #region ��k
    /// <summary>
    /// �ˬd�e��G�O�_���a�O�λ�ê��
    /// </summary>
    private void CheckForward()
    {
        hits = Physics2D.OverlapCircleAll(
            transform.position +
            transform.right * checkForwardOffset.x +
            transform.up * checkForwardOffset.y,
            checkForwardRadius);

        //  print("�e��I�쪺����G" + hit.name);

        /** �Ǫ���V���z����
        //  ��ر��p���n��V�B�קK�����ê���H�α���
        //  1.�}�C���e�O�Ū� - �S���a��ԤO�|����
        //  2.�}�C���e ���O �a�O �åB(&& [�� ||]) ���O ���x ������ - ����ê��
        //  �d�߻y�� LinQ�G�i�H�d�߰}�C��ơB�Ҧp�G�O�_�t�a�O�B�O�_����Ƶ����K
        */

        //  �I��a�O�B���x�B�D���Ҥ��|��V
        //  hitResult = hits.Where(x => x.name != "�a�O" && x.name != "���x" && x.name !="�i��z���x" && x.name != "player_01").ToArray();
        hitResult = hits.Where(x => x.name != "�a�O" && x.name !="�i��z���x" && x.name != "player_01").ToArray();

        //  �}�C���ŭȡG�}�C�ƶq���s
        //  �p�G �I���ƶq���s (�e��S���a�诸��) �Ϊ� �I�����G�j��s (�e�観��ê��) ���n��V
        if (hits.Length == 0 || hitResult.Length > 0)
        {
            // print("�e��S���a�O�|����");
            TurnDirection();
        }

    }
    /// <summary>
    /// ��V
    /// </summary>
    private void TurnDirection()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles = Vector3.up * 180;
        else transform.eulerAngles = Vector3.zero;
    }
    /// <summary>
    /// �ˬd���A
    /// </summary>
    private void CheckState() 
    {
        //  ����k�r �� switch �� TAB ��J(XXX) TAB
          switch (state)
        {
            case StateEnemy.idle:
                Idle();
                break;
            case StateEnemy.walk:
                Walk();
                break;
            case StateEnemy.track:

                break;
            case StateEnemy.attack:
                Attack();
                break;
            case StateEnemy.death:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// �������A�G��������òK�[�N�o
    /// </summary>
    private void Attack()
    {
        if (timerAttack < cdAttack)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            AttackMethod();
        }
    }
    /// <summary>
    /// �l���O�i�H�M�w�Ӧp���������k
    /// </summary>
    protected virtual void AttackMethod()
    {
        timerAttack = 0;
        ani.SetTrigger("����Ĳ�o");
        print("����");
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