using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API ���G������j��
    //  1.  �R  �A�G ������r   static
    //  2.  �D�R�A�G �L����r   static  �� Public Methods

    //  NOTE�GGameObject ���s�����b�ݩʭ��O�@�w�|�� Transform ���� �H�ΦW�����
    //  https://docs.unity3d.com/ScriptReference/Transform.html
    //  �ݩʭ��O ���󳣬O�D�R�A

    //  ------ �ϥΫD�R�A�ݩ�
    //  �ϥΫD�R�A�ݩ� 1. ���w�q���D�R�A�ݩʪ����O���
    //  �ϥΫD�R�A�ݩ� 3. ��쥲����J�n������T������A�� ���ର�ŭ�
    public Transform traA;
    public Camera cam;
    public Transform traB;
    public Light lightA;

    //public Camera DepthA; ranjyue
    // public bool flipY; ranjyue
    public Camera camA;
    public SpriteRenderer srA;
    public Transform traC;
    public Rigidbody2D rigiA;
    // public Rigidbody2D rigi; KID


    private void Start()
    {
        #region �{�ѫD�R�A�ݩ�
        //  1. ���o�D�R�A�ݩ�

        //print("���o�y�СG" + Transform.position);  // ���~�G�ݭn������Ѧ�

        //  ------ �ϥΫD�R�A�ݩ�
        //  �ϥΫD�R�A�ݩ� 2.
        //  �� �ϥλy�k�G���W��.�D�R�A�ݩ�
        print("���o�ߤ���y�СG" + traA.position);  // �y�з|�|�ˤ��J��p���I1 EX�G6.95 �� 7.0
        print("���o��v�����I���C��G" + cam.backgroundColor);

        //  2. �]�w�D�R�A�ݩ�
        //  �� �y�k�G���.�D�R�A�ݩ� ���w ��;
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        //  3. �I�s�D�R�A�ݩ�
        //  �� �y�k�G���.�D�R�A��k(�������޼�);
        traB.Translate(1, 0, 0);
        lightA.Reset();
        #endregion

        #region �Ұ�m�ߡG�D�R�A�ݩʻP��k�m�� ranjyue KID �ץ�

        // �m�ߤ����Q

        // DOC�Ghttps://paper.dropbox.com/doc/C-EsPpCQXko0Vt7P1tmH9so

        //  1. ���o�D�R�A�ݩ�
        //  �� �ϥλy�k�G���W��.�D�R�A�ݩ�
        print("���o��v���`�סG" + camA.depth);
        print("���o�Ϥ�crate���C��G" + srA);


        //  2. �]�w�D�R�A�ݩ�
        //  �� �y�k�G���.�D�R�A�ݩ� ���w ��;
        //  cam.depth = new float(); ranjyue
        //  �� random = �R�A
        camA.backgroundColor = Random.ColorHSV();
        srA.flipY = true;



        //  3. �I�s�D�R�A�ݩ�
        //  �� �y�k�G���.�D�R�A��k(�������޼�);
        // traC.rotation(); ranjyue 
        


        #endregion


    }


   public void Update()
    {
        traC.Rotate(0, 0, 1);
        rigiA.AddForce(new Vector2(0,10));
    }
}
