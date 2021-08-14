using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
/// <summary>
/// 敵人基底類別
/// 功能：隨機走動、等待、追蹤玩家、受傷與死亡
/// 狀態機：列舉 Enum、判斷式 switch (基礎語法)
/// </summary>
public class BaseEnemy : MonoBehaviour
{
    #region 欄位

    #region 欄位：公開
    [Header("基本能力")]
    [Range(50, 5000)]
    public float hp = 100;
    [Range(5, 1000)]
    public float attack = 20;
    [Range(1, 500)]
    public float speed = 1.5f;
    [Header("檢查前方是否有障礙物或地板球體")]
    public Vector3 checkForwardOffset;
    [Range(0, 1)]
    public float checkForwardRadius = 0.3f;

    /// <summary>
    /// 隨機等待範圍
    /// </summary>
    public Vector2 v2RandomIdle = new Vector2(1, 5);
    /// <summary>
    /// 隨機走路範圍
    /// </summary>
    public Vector2 v2RandomWalk = new Vector2(3, 6);

    //  public int[] score;
    //  認識陣列
    //  語法：類型後方加上中括號，例如：int[]、float[]、string[]、Vector2[]
    public Collider2D[] hits;
    /// <summary>
    /// 存放前方是否有不包含地板、跳台的物件
    /// </summary>
    public Collider2D[] hitResult;

    //  public KeyCode key;

    #endregion

    #region 欄位：私人
    [SerializeField]
    protected StateEnemy state;

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
    /// <summary>
    /// 攻擊冷卻時間
    /// </summary>
    public float cdAttack = 3;
    /// <summary>
    /// 攻擊狀態
    /// </summary>
    private float timerAttack;
    #endregion

    #endregion



    #region 事件

    private void Start()
    {
        #region 初始值設定
        timeIdle = Random.Range(v2RandomIdle.x, v2RandomIdle.y);
        #endregion
    }

    protected virtual void Update()
    {
        CheckForward();
        CheckState();

    }

    private void FixedUpdate()
    {
        WalkInFixedUpdate();
    }
    //  父類別的成員如果希望仔類別複寫遵循：
    //  1. 修飾詞必須是 public 或 protected - 保護 允許子類別存取
    //  2. 添加關鍵字 virtual 虛擬 - 允許子類別複寫
    //  3. 子類別使用 override 複寫
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0.3f, 0.3f, 0.3f);
        //  transform.right 當前物件的右方(2D 模式為前方、紅色箭頭)
        //  transform.up 當前物件的上方 (綠色箭頭)
        Gizmos.DrawSphere(
            transform.position +
            transform.right * checkForwardOffset.x +
            transform.up * checkForwardOffset.y, 
            checkForwardRadius);

        
    }

    #endregion



    #region 方法
    /// <summary>
    /// 檢查前方：是否有地板或障礙物
    /// </summary>
    private void CheckForward()
    {
        hits = Physics2D.OverlapCircleAll(
            transform.position +
            transform.right * checkForwardOffset.x +
            transform.up * checkForwardOffset.y,
            checkForwardRadius);

        //  print("前方碰到的物件：" + hit.name);

        /** 怪物轉向物理模擬
        //  兩種情況都要轉向、避免撞到障礙物以及掉落
        //  1.陣列內容是空的 - 沒有地方戰力會掉落
        //  2.陣列內容 不是 地板 並且(&& [或 ||]) 不是 跳台 的物件 - 有障礙物
        //  查詢語言 LinQ：可以查詢陣列資料、例如：是否含地板、是否有資料等等…
        */

        //  碰到地板、跳台、主角皆不會轉向
        //  hitResult = hits.Where(x => x.name != "地板" && x.name != "跳台" && x.name !="可穿透跳台" && x.name != "player_01").ToArray();
        hitResult = hits.Where(x => x.name != "地板" && x.name !="可穿透跳台" && x.name != "player_01").ToArray();

        //  陣列為空值：陣列數量為零
        //  如果 碰撞數量為零 (前方沒有地方站立) 或者 碰撞結果大於零 (前方有障礙物) 都要轉向
        if (hits.Length == 0 || hitResult.Length > 0)
        {
            // print("前方沒有地板會掉落");
            TurnDirection();
        }

    }
    /// <summary>
    /// 轉向
    /// </summary>
    private void TurnDirection()
    {
        float y = transform.eulerAngles.y;
        if (y == 0) transform.eulerAngles = Vector3.up * 180;
        else transform.eulerAngles = Vector3.zero;
    }
    /// <summary>
    /// 檢查狀態
    /// </summary>
    private void CheckState() 
    {
        //  智能k字 打 switch 按 TAB 輸入(XXX) TAB
          switch (state)
        {
            case StateEnemy.idle:
                Idle();
                break;
            case StateEnemy.walk:
                Walk();
                break;
            case StateEnemy.track:

                break;
            case StateEnemy.attack:
                Attack();
                break;
            case StateEnemy.death:
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 攻擊狀態：執行攻擊並添加冷卻
    /// </summary>
    private void Attack()
    {
        if (timerAttack < cdAttack)
        {
            timerAttack += Time.deltaTime;
        }
        else
        {
            AttackMethod();
        }
    }
    /// <summary>
    /// 子類別可以決定該如何攻擊的方法
    /// </summary>
    protected virtual void AttackMethod()
    {
        timerAttack = 0;
        ani.SetTrigger("攻擊觸發");
        print("攻擊");
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