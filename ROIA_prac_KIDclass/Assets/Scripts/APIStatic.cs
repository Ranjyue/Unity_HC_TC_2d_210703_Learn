using UnityEngine;

/// <sumary>
/// �{��  API     �H�βĤ@�إΪk�G�R�A  static
/// </sumary>

public class APIStatic : MonoBehaviour
{
    //  API ���A������j��
    //  1.  �R  �A�G ������r   static
    //  2.  �D�R�A�G �L����r   static

    //  �ݩʡG Properties �i�H�z�Ѭ����P�����  
    //  ��k�G Methods
    //  struct(�i�H���ݩ�) in UnityEngine

    private int count;                              // @ranjyue

    public float radius = 5;                        // @ranjyue
    public float number = 9.99f;                    // @KID
    public Vector3 a = new Vector3(1, 1, 1);        // @KID
    public Vector3 b = new Vector3(22, 22, 22);     // @KID


    private void Start()
    {
        #region �{���R�A�ݩʻP��k
        //  �R�A�ݩ�
        //  1.  ���o
        //  �� �y�k�G���O�A�R�A�ݩ�
        print("�H����" + Random.value);        // 0 - 1
        print("�L���j" + Mathf.Infinity);

        //  2. �]�w
        /*  class in UnityEngine
         *  API ����O���}��=Public
         */
        //  �� �y�k�G���O�A�R�A�ݩ� ���w  �� ;
        Cursor.visible = false;
        //  Random.value = 7.7f;// - �߿W�ݩʤ���]�w = Read only
        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Random.html");
        //  �����o������ Read only �N�N��i�H�]�w�A�δ��ճ̧�(���з|��� set;=�i�H�]�w or get;=�i�H���o

        Screen.fullScreen = true;

        //  �R�A��k
        //  3. �I�s
        //  �� �y�k�G���O�A�R�A�ݩ�(�����޼�);
        float r = Random.Range(7.5f, 9.8f);
        print("�H���d�� 7.5 ~ 9.8" +r);
        #endregion

        #region �Ұ�m�ߡG�m���R�A�ݩʻP��k ranjyue
        //  C# �R�A�ݩʻP��k�m�� 
        //  �R�A�ݩ� Static Properties

        //  �Ҧ���v���ƶq tag�GCamera
        count = Camera.allCamerasCount;
        print("We've got" + count + "cameras");

        //  2D �����O�j�p tag�GPhysics2D
        Physics2D.gravity = new Vector2(0, -20);
        print("Gravedad al 20%" );

        //  ��P�v tag�GMathf
        float perimeter = 2.0f * Mathf.PI * radius;
        Debug.Log("The perimeter of the circle is: " + perimeter);
        // Debug �O�M�Φb API ���� :MonoBehaviour except �N unityEngenine �h��
        // Print ��ݦb public class APIStatic : MonoBehaviour ���ҤU�~�����


        #endregion

        #region �m���R�A�ݩʻP��k // KID
        //  1. ���o�R�A�ݩ�
        print("�Ҧ���v���ƶq�G" + Camera.allCamerasCount);
        print("2D ���O�G" + Physics2D.gravity);
        print("��P�v�G" + Mathf.PI);
        //  2. �]�w�R�A�ݩ�
        Physics2D.gravity = new Vector2(0, -20);
        print("2D ���O�G" + Physics2D.gravity);
        Time.timeScale = 0.5f;                 // �C�ʧ@�B�ְʧ@ 2�B�Ȱ� 0 
        print("�ɶ��j�p�G" + Time.timeScale);
        /// �W�߹C�� movie = videogame

        //  3. �I�s�R�A��k
        /// unity api 
        number = Mathf.Floor(number);
        print("9.99 �h�p���I�G" + number);

        float d = Vector3.Distance(a, b);
        print("A �P B ���Z���G" + d);

        Application.OpenURL("https://unity.com/");
        #endregion

        #region
        #endregion

        #region
        #endregion

    }

    public float hp = 70;                   // KID

    private float fixedDeltaTime;           // ranjyue

    private void Update()
    {
        hp = Mathf.Clamp(hp, 0, 100);        // �ƾǡA����(�ȡB�̤p�ȡB�̤j��) - �N��J���ȧ��b�̤p�̤j�d��
        print("��q�G" + hp);

        #region �Ұ�m�ߡG�m���R�A�ݩʻP��k ranjyue
        //  �O�_��J���N�� tag�GInput
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);

            //  �C���g�L�ɶ� tag�GTime //�ɶ��j�p�]�w�� 0.5 (�C�ʧ@)
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
        }
        #endregion

        #region �m���R�A�ݩʻP��k
        print("�O�_��J���N��G" + Input.anyKey);
        //print("�C���g�L�ɶ��G" + Time.time);

        //  3. �I�s�R�A��k
        bool space = Input.GetKeyDown("Space");
        print("�O�_���U�ť���G" + space);


        #endregion

        #region
        #endregion

        #region
        #endregion



    }

    private void FixedUpdate()
    {
        
    }
}
