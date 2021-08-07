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
    [Header("���O"), Range(0.1f, 10)]
    public float gravity = 1;
    [Header("�ˬd�a�O�ϰ�G�첾�P�b�|")]
    public Vector3 groundOffset;
    [Range(0, 2)]
    public float groundRadius = 0.5f;



    private Rigidbody2D Rig;
    private AudioSource AudioSource;
    private Animator ani;
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
        ani = GetComponent<Animator>();


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



    // ø�s�ϥܨƥ�G���U�}�o�̥ΡA�ȷ|��ܦb�s�边 Unity ��
    private void OnDrawGizmos()
    {
        //  ���M�w�C��bø�s�ϥ�
        Gizmos.color = new Color(1,0,0,0.3f);   //  �b�z������
        // Gizmos.DrawSphere(transform.position, 2);   // ø�s�y��(�����I�A�b�|)
        Gizmos.DrawSphere(transform.position + groundOffset, groundRadius);
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
        /** �Ĥ@�ز��ʤ覡�G�ۭq���O
        //  �ϰ��ܼơG�b��k�欰�A���ϰ�ʡA�ȭ��󦹤�k���s��
        //  ²�g�Gtransform ������ Transform �ܧΤ���
        //  posMOve = �����e�y�� + ���a��J��������
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * speed * Time.fixedDeltaTime;
        //  ����A���ʮy��(�n�e�����y��)
        //  Time.fixedDeltaTime �� 1/50 �� #���ƭ��ܤp
        Rig.MovePosition(posMove);
        */

        /** �ĤG�ز��ʤ覡�G�ϥαM�פ������O - ���w�C */
        Rig.velocity = new Vector2(horizontal * speed * Time.fixedDeltaTime, Rig.velocity.y);

        ani.SetBool("�����}��", horizontal != 0);
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
        //  Vector2 �Ѽƥi�H�ϥ� Vector3 �N�J �����|�۰ʧ� z �b����
        //  << �첾�B��l
        //  ���w�ϼh�y�k�G 1<< �ϼh�s��
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundOffset, groundRadius, 1 << 6);

        //  �p�G �I�쪫��s�b �N�N��b�a�O�W �_�h �N�N���A�a���W
        //  NOTE�G�p�G���L���u���@���i�H�ٲ� {}
        if(hit) onFloor = true;
        else onFloor = false;

        ani.SetBool("���D�}��", !onFloor);

        //print("�I�쪺����G" +hit.name);

        //  �p�G �b�a�O�W �åB ���a ���U �ťի� ����N���W���D
        if(onFloor && Input.GetKeyDown(KeyCode.Space))
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
