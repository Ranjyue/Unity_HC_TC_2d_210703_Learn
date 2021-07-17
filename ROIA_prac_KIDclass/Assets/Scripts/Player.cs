using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0,   1000)]
    public float speed  =   10.5f;
    [Header("跳要高度"), Range(0, 3000)]
    public int Jump = 100;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("用來儲存腳色是否在地板上的資訊，在地板上 true，不在地板上 false")]
    public bool onFloor;



    private Rigidbody2D Rigidbody2D;
    private AudioSource AudioSource;
    private Animator animator;
    #endregion




}
