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
    public float weight = 3.5f;
    public int cc = 4000;
    public string brand = "Ferrari";
    public bool dormer = true;

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
    public Color colorCustom1 = new Color(0.5f, 0.5f, 0);    //  �ۭq�C��(R�AG�AB)
    public Color colorCustom2 = new Color(0.5f, 0.05f, 0, 5f);   //  �ۭq�C�� (R�AG�AB�AA)


    //  �y�� 2    -   4   ��   Vector2    -   4
    //  �O�s�ƭȸ�T�B�B�I��
    public Vector2 v2;
    public Vector2 Vector2 = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right;
    public Vector2 v2Custom = new Vector2(-99.5f, 100.5f);

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

    #region �ƥ�
    //  Lesson 07
    //  �}�l�ƥ�G����C���ɰ���@���A�B�z��l��
    private void Start()
    {
        #region �m�����
        // ��X(�����������);
        print("Hello Bro~");    // �u���s��ݬݱo��A���a�ݤ���A���F���հ��污�p�γ~
                                // ��X(�����������);
                                //  unity>inspector>cube>�N�ĤĨ��� = �����������

        //  �m�ߦ��w��� Get
        print(brand);
        //  �m�ߦ��w��� Get

        dormer = true;
        cc = 5000;
        weight = 9.9f;

        #endregion

        // Lesson 9
        // �I�s��k�y�k�G��k�W��();

        #region �o�ؤ覡��s���ɭԳ·Ф�²�K
        //Drive50();
        //Drive100();
        //Drive150();
        //Drive200();
        #endregion

        Drive(150,  "������");               //  �I�s�ɤp�A�������٬��޼ơA�ݿ�J�������޼�
        Drive(200,  "�F�F�F");
        Drive(300);                         //  NOTE�G �]�w�w�]�ȰѼƤ���A�����޼ƴN���ݭn���ݬO�ۦP�ƶq���޼ơC
                                            //  #KID�G ���w�]�Ȫ��Ѽƥi�H���ε��޼ơC
                                            //  #EX01; private void Drive(int speed,   string sound )          �� Drive(150,  "������"); / Drive(200,  "�F�F�F");
                                            //  #EX02; private void Drive(int speed,   string sound= "������") �� Drive(200,  "�F�F�F"); / Drive(200);

        //  Drive(80,   "�H��");            //  �ɳt 80�A���� �������A�S�� �H��    �����ļ��X�ӮɬO�H��
        Drive(80, effect: "�H��");          //  �ϥΦh�ӹw�]�ȰѼƮɥi�H�ϥ� �ѼƦW��: ��
        Drive(999, "������", "�z��");        //  ��J�P�w�]�ȬۦP���Ѽ� ���Φh�g �ѼƭȦW��:

        float kg = KG();                    //  �ϰ��ܼơB�Ȧb���A�����ϥΡCNOTE: �Ǧ^�����P�ɳ]�w�ۦP���ݩ�
        print("�ର���窺��T�G" + kg);

        #region BMI �Ѽƽm��

        print("KID �� BMI�G" + BMI(60, 1.68f));   //  �����N�Ǧ^��k���Ȩϥ�

        #endregion



    }

    //  ��s�ƥ�G�j���@�� 60���A60FPS�A�B�z���󲾰ʩΪ̺�ť���a��J
    private void Update()
    {
        print("�ڦb   Update  �� @3@");
    }



    //
    private void FixedUpdate()
    {

    }



    #endregion

    #region ��k (�\��B�禡) Method
    //  ��k�G��@����������欰�A�Ҧp�G�T���b�e�}�B�}�ҨT�������T�ü��񭵼֡K
    //  �зǻy�k�G�׹��� ��    ��  �W��  ���w  �w�]��;
    //  ��k�y�k�G�׹��� �Ǧ^����  �W��(�Ѽ�){   �{���϶�    }
    //  �����Gvoid -   �L�Ǧ^
    //  �w�q��k�G���|���檺�����I�s�A�I�s�覡�G�b�ƥ󤺩I�s����k

    //  Lesson09�G$���@�m�B$�X�R��

    #region �o�ؤ覡��s���ɭԳ·Ф�²�K
    //private void Drive50()
    //{
    //print("�}�����B�ɳt�G50");
    //}

    //private void Drive100()
    //{
    //print("�}�����B�ɳt�G100");
    //}
    //private void Drive200()
    //{
    //print("�}�����B�ɳt�G100");
    //}
    //private void Drive150()
    //{
    //print("�}�����B�ɳt�G150");
    //}
    #endregion

    //  �Ѽƻy�k�G   ���� �ѼƦW�� - �g�b�p�A�����C�Ȧb����k�A��(�i�ϥ�)
    //  �Ѽ�1�A�Ѽ�2�A�Ѽ�3.........�Ѽ�N (NOTE�G�S���W���A����ĳ�ѼƤ��n�Ӧh[<=10�A1-5�`��]�A������ϥΦ��t�Ϊ������{�סA�Ѽƪ��@�Υi��|�ѤF)
    //  �Ѽƹw�]�ȡG���� �ѼƦW�� ���w �� (=��񦡰Ѽ�)
    //  ���w�]�ȥu���b�̥k��
    //  NOTE:   Summary �K�n �f�t�T���׽u
    //  NOTE:   Parameter = param = �Ѽ�
    //  NOTE:   Summary ���@��:
    /* 1. �K�n�A�y���{���]�w���Ѩӵ�
     * 2. �U����s�B�ζ��٦��ˬd�ɪ��@�Ө̾�
     * 3. ���ܦC(KEY�{�����ɭԨt�η|������) �|��ܸӰѼƪ��@��
     * [] ���A�������e�O�w�]�Ȫ��Ѽ�
    */

    /// <summary>
    /// �o�O�}������k�A�i�H�Ψӱ���l���t�סB���ĻP�S��
    /// </summary>
    /// <param name="speed">���l�����ʳt��</param>
    /// <param name="sound">�}���ɪ�����</param>
    /// <param name="effect">�}���ɭn���񪺯S��</param>

    private void Drive(int speed,   string sound= "������",    string effect = "�ǹ�")
    {
        print("�}�����B�ɳt�G" + speed);
        print("�}�����ġG" + sound);
        print("�}���S�ġG" + effect);

    }

    /// <summary>
    /// �����ഫ������
    /// </summary>
    /// <returns>�ର���窺���q��T</returns>

    private float KG()
    {
        return weight * 1000;
    }

    #endregion

    #region BMI

    /// <summary>
    /// �p�� BMI
    /// </summary>
    /// <param name="weight">�魫(����)</param>
    /// <param name="height">����(����)</param>
    /// <returns>BMI ��</returns>

    private float BMI(float weight, float height)
    {
        return weight / (height * height);
    }

    #endregion

    #region 

    #endregion

    #region 
    #endregion

}