using UnityEngine;

public class Player : MonoBehaviour
{
    #region ���
    [Header("���ʳt��"), Range(0,   1000)]
    public float speed  =   10.5f;
    [Header("���n����"), Range(0, 3000)]
    public int Jump = 100;
    [Header("��q"), Range(0, 200)]
    public float hp = 100;
    [Header("�O�_�b�a�O�W"), Tooltip("�Ψ��x�s�}��O�_�b�a�O�W����T�A�b�a�O�W true�A���b�a�O�W false")]
    public bool onFloor;



    private Rigidbody2D Rigidbody2D;
    private AudioSource AudioSource;
    private Animator animator;
    #endregion




}
