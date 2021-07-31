using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0,   1000)]
    public float speed  =   10.5f;
    [Header("���n����"), Range(0, 3000)]
    public int JumpHeight = 100;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"), Tooltip("�Ψ��x�s�}��O�_�b�a�O�W����T�A�b�a�O�W true�A���b�a�O�W false")]
    public bool onFloor;



    private Rigidbody2D Rig;
    private AudioSource AudioSource;
    private Animator animator;
    /// <summary>
    /// ���a������J��
    /// </summary>
    private float hValue;
    #endregion

    #region  �ƥ�
    #endregion

    #region ��k
    #endregion

    #region  �ƥ�

    private void Start()
    {
        // GetComponent() �x���k�A�i�H���w��������
        // �@�ΡG���o������2D���餸��

        Rig = GetComponent<Rigidbody2D>();

    }

    // �@�������60��
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
    }

    //  �@��T�w���� 50���A�x���ĳ���ϥΨ쪫�z API �n�b���ƥ󤺰���
    private void FixedUpdate()
    {
        Move(hValue);
    }

    #endregion


    #region ��k

    /// <summary>
    /// ���a������J��
    /// </summary>
    // private float hValue;

    /// <summary>
    /// ���o���a��J�����b�V�ȡG���P�k A�BD�B���B�k
    /// </summary>
    /// 
    private void GetPlayerInputHorizontal()
    {
        // TAG�Gunity Input axis 

        //  ������=��J.���o�y�V(�y���W��)
        //  �@�ΡG���o���a���U�������䪺�ȡA���k�� 1�B������ -1�B�S���� 0
        hValue = Input.GetAxis("Horizontal");
        print("���a�����ȡG" + hValue);
    }

    [Header("���O"), Range(0.1f, 10)]
    public float gravity = 1;

    #endregion

    #region �Ұ�m�� Lesson 08 Exercise 01: ��k

    #region practice false
    //private void Start()
    //{
    //herir(8);
    //comerProps("�D��W��");
    //}
    #endregion

    // ---------���νu--------- //

    /// <summary>
    /// ���ʡA�S���Ǧ^�����A�a�p���I�����k�ƭ�
    /// </summary>
    /// <param name="horizontal">���ʤ襪�k�V</param>

    private void Mover(float horizontal)
    {
        print("�}�����B�ɳt�G" + horizontal);
        print("�G" );

    }

    private void salto()
    {
        print("�G");
    }

    private void atacar()
    {
        print("�G");
    }

    public void herir(float herida)
    {
        print("���ˡG" + herida);
    }

    private void morir()
    {
        print("�G");
    }

    private void comerProps(string propname)
    {
        print("���ˡG" + propname);
    }

    //  private void Drive(int speed,   string sound= "������",    string effect = "�ǹ�")


    #endregion

    #region �Ұ�m�� Lesson 08 Exercise 01:��k KID // Lesson 11 ����

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {
        //  �ϰ��ܼơG�b��k�欰�A���ϰ�ʡA�ȭ��󦹤�k���s��
        //  ²�g�Gtransform ������ Transform �ܧΤ���
        //  posMOve = �����e�y�� + ���a��J��������
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * speed * Time.fixedDeltaTime;
        //  ����A���ʮy��(�n�e�����y��)
        //  Time.fixedDeltaTime �� 1/50 �� #���ƭ��ܤp
        Rig.MovePosition(posMove);
    }

    /// <summary>
    /// �����V�G�B�z���⭱�V���D�A���k����0�B�����}��180
    /// </summary>
    private void TurnDirection()
    {
        //print("���a���U�k�G" + Input.GetKeyDown(KeyCode.D));

        //  �p�G ���a�� D �N�N���׳]�w�� 0, 0, 0
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }

        //  �p�G ���a�� A �N�N���׳]�w�� 0, 180,0
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180,0);
        }
    }
    /// <summary>
    /// ��ģ
    /// </summary>
    private void Jump() 
    {
        //  �p�G ���a ���U �ťի� ����N���W���D
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rig.AddForce(new Vector2(0, JumpHeight));
        }
    }
    /// <summary>
    /// ����
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    /// ����
    /// </summary>
    /// <param name="damage">�y�����ˮ`</param>
    public void Hurt(float damage)
    {

    }
    /// <summary>
    /// ���`
    /// </summary>
    private void Death()
    {

    }
    /// <summary>
    /// �Y�D��
    /// </summary>
    /// <param name="propName">�Y�쪺�D��W��</param>
    private void EatProp(string propName)
    {

    }

    #endregion



}
