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



    private Rigidbody2D Rigidbody2D;
    private AudioSource AudioSource;
    private Animator animator;
    #endregion

    #region  �ƥ�
    #endregion

    #region ��k
    #endregion

    #region �Ұ�m�� Lesson 08 Exercise 01: ��k

    private void Start()
    {
        herir(8);
        comerProps("�D��W��");
    }

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

    #region �Ұ�m�� Lesson 08 Exercise 01:��k KID

    /// <summary>
    /// ����
    /// </summary>
    /// <param name="horizontal">���k�ƭ�</param>
    private void Move(float horizontal)
    {
        
    }
    /// <summary>
    /// ��ģ
    /// </summary>
    private void Jump() 
    {
    
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
