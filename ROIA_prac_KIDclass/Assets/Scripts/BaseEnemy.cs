using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 敵人基底類別
/// 功能：隨機走動、等待、追蹤玩家、受傷與死亡
/// 狀態機：列舉 Enum、判斷式 switch (基礎語法)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region 欄位
    [Header("基本能力")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    /// <summary>
    /// 隨機等待範圍
    /// </summary>
    public Vector2 v2RandomIdle = new Vector2(1, 5);
    /// <summary>
    /// 隨機走路範圍
    /// </summary>
    public Vector2 v2RandomWalk = new Vector2(3, 6);

    //  public KeyCode key;
    [SerializeField]
    private StateEnemy state;

    private Rigidbody2D rig;
    private Animator ani;
    private AudioSource aud;
    /// <summary>
    /// 等待時間：隨機
    /// </summary>
    private float timeIdle;
    /// <summary>
    /// 等待用計時器
    /// </summary>
    private float timerIdle;
    /// <summary>
    /// 走路時間：隨機
    /// </summary>
    private float timeWalk;
    /// <summary>
    /// 走路用計時器
    /// </summary>
    private float timerWalk;

    #endregion

    #region 事件

    private void Start()
    {
        #region 初始值設定
        timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
        #endregion
    }

    private void Update()
    {
        CheckState();
    }

    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }

    #endregion

    #region 方法
    /// <summary>
    /// 檢查狀態
    /// </summary>
    private void CheckState() 
    {
        //  智能k字 打 switch 按 TAB 輸入(XXX) TAB
          switch (state)
        {
            case StateEnemy.idle:
                break;
            case StateEnemy.walk:
                break;
            case StateEnemy.track:
                break;
            case StateEnemy.attack:
                break;
            case StateEnemy.death:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 等待：隨機秒數後進入到走路狀態
    /// </summary>
    private void Idle()
    {
        if(timerIdle < timeIdle)                //  如果 計時器 < 等待時間
        {
            timerIdle += Time.deltaTime;        //  累加時間
            ani.SetBool("走路開關", false);      //  關閉走路開關，等待動畫
            print("等待");
        }
        else                                                            //  否則
        {
            RandomDirection();                                          //  隨機方向
            state = StateEnemy.walk;                                    //  切換狀態
            timeWalk = Random.Range(v2RandomWalk.x, v2RandomWalk.y);    //  取的隨機走路時間
            timerIdle = 0;                                              //  計時器歸零

        }
        
    }
    /// <summary>
    /// 隨機走路
    /// </summary>
    private void Walk()
    {
        if(timerWalk < timeWalk)
        {
            timerWalk += Time.deltaTime;
            ani.SetBool("走路開關", true);                                 // 開啟走路開關：走路動畫
            // rig.velocity = transform.right * speed * Time.deltaTime + Vector3.up * rig.velocity.y;        
            // rig.velocity = transform.forward * speed * Time.deltaTime;  3D 深度
        }
        else
        {
                                               
            state = StateEnemy.idle;
            rig.velocity = Vector2.zero;
            timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
            timerWalk = 0;

        }
        print("走路");
    }
    /// <summary>
    /// 將物理行為單獨處裡並在 FixedUpdate 乎較;
    /// </summary>
    private void WalkInFixedUpdate()
    {
        //  如果 目前狀態 式移動 就 鋼體.加速度 = 速度 * 1/50 + 上方 * 地心引力
        if (state == StateEnemy.walk) rig.velocity = transform.right * speed * Time.fixedDeltaTime + Vector3.up * rig.velocity.y;
    }
    /// <summary>
    /// 隨機方向：隨機而向右邊或左邊
    /// 右邊：0 , 0 , 0
    /// 左邊：0, 180, 0
    /// </summary>
    private void RandomDirection()
    {
        int random = Random.Range(0, 2);    //  隨機.範圍(最小,最大) - 整數時不包含最大值 (0, 2) - 隨機取得 0 或 1

        if (random == 0) transform.eulerAngles = Vector2.up * 180;
        else transform.eulerAngles = Vector2.zero;

    }

    #endregion

}


//  定義列舉
//  1.使用關鍵字 enum 定義列舉以及包含的選項、可以在類別外定義
//  2.需要有一個欄位定義為此列舉類型
//  語法：修飾詞 enum 列舉名 {選項1、選項2…、選項N}
public enum StateEnemy
{
    idle, walk, track, attack, death
}