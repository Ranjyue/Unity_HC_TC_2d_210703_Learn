using UnityEngine;
// �ޥ� Unity ���� ���� API (Unity Engine �R�W�Ŷ�)

// class=���O
// �y�k�G���O����r �}���R�W

 
public class Car : MonoBehaviour
{

    #region ����
    // �����ѡG��[�����B½Ķ�B���������K�|�Q�{������
    //  KID 2021.07.17 (SAT.) �}�o�T���}��

    /*�h�����
     *  Method = �\��
     *  Field = ���
     */

    #endregion

    #region �{�����P�`�Υ|�j����
    //  ���G�x�s²�檺���
    //  �y�k
    //  �׹���    �������    ���W��    ���w�Ÿ�   �w�]��    ����
    //  ���w�Ÿ�    =   (�e�ᵥ�����Ů�i���i�L)
    /*  �׹����G
     *  �p�H private �w�] - �����
     *  ���} public             - ���
     */

    //  �i�H�ϥΤ���A����ĳ  -   �s�X���D�P�ഫ�į���D
    //  �W�߶}�o    or   �ζ��\�i

    //  Unity ���`�Ϊ��|�j����
    //  ���          int          ex �G    1,  99, 0,  -123
    //  �B�I��     float      ex �G     2.3,    3.1415,      -1.123
    //  �r��          string   ex �G    BMW, BENZ, ��ܤ��e@#�K
    //  ���L��     bool     ex �G    true,      false

    //  �w�q���
    public float weight    =   3.5f;
   public int cc  =   4000;
   public string brand    = "Ferrari";
   public bool dormer   =   true;

    //  ����ݩʡG���U����[�B�~�\��
    //  �y�k�G[�ݩʦW��(�ݩʭ�)]
    //  ���D�G[Header(�r��)]
    [Header("���L�ƶq")]
    public int wheelCount;

    //  ���ܡG[ToolTip(�r��)]
    [Tooltip("�o����쪺�@�άO�]�w�T�������סK")]
    public float height = 1.5f;
    //  �d�� �G[Range(�̤p�ȡB�̤j��)]    -   �ȭ��ƭ�����  float   �P   int 
    [Range(2, 10)]
    public int doorCount;
    //  ���~�ܽd�G���O�Ω�   float   �P   int     �H�U������
    [Range(2, 10)]
    public bool canOpenMusic;

    #endregion

    #region ��L����
    //  �C�� color                                                                                        //�����w���¦�z��
    public Color color1;                                                                           //   �ϥιw�]�C��
    public Color color = Color.red;
    public Color yellow = Color.yellow;
    public Color colorCustom1 = new Color(0.5f,     0.5f    ,0);    //  �ۭq�C��(R�AG�AB)
    public Color colorCustom2 = new Color(0.5f, 0.05f, 0,5f);   //  �ۭq�C�� (R�AG�AB�AA)
    

    //  �y�� 2    -   4   ��   Vector2    -   4
    //  �O�s�ƭȸ�T�B�B�I��
    public Vector2 v2;
    public Vector2 Vector2 = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right;
    public Vector2 v2Custom = new Vector2(-99.5f,100.5f);

    public Vector3 v3;
    public Vector4 v4;

    //  ��������
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0;     //  ����  0�A�k��    1�A�u��    2

    //�C������P����
    public GameObject goCamera;     //  �C������]�t���V�W���H�αM�פ����w�
    //  ����ȭ���s���ݩʭ��O�������󪺪���
    public Transform traCar;
    public SpriteRenderer sprPicture;

    #endregion





}