using UnityEngine;

public class Player : MonoBehaviour
{
    #region 欄位
    [Header("移動速度"), Range(0,   1000)]
    public float speed  =   10.5f;
    [Header("跳要高度"), Range(0, 3000)]
    public int JumpHeight = 100;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("是否在地板上"), Tooltip("用來儲存腳色是否在地板上的資訊，在地板上 true，不在地板上 false")]
    public bool onFloor;



    private Rigidbody2D Rig;
    private AudioSource AudioSource;
    private Animator animator;
    /// <summary>
    /// 玩家水平輸入值
    /// </summary>
    private float hValue;
    #endregion

    #region  事件
    #endregion

    #region 方法
    #endregion

    #region  事件

    private void Start()
    {
        // GetComponent() 泛行方法，可以指定任何類型
        // 作用：取得此物件的2D剛體元件

        Rig = GetComponent<Rigidbody2D>();

    }

    // 一秒約執行60次
    private void Update()
    {
        GetPlayerInputHorizontal();
        TurnDirection();
        Jump();
    }

    //  一秒固定執行 50次，官方建議有使用到物理 API 要在此事件內執行
    private void FixedUpdate()
    {
        Move(hValue);
    }

    #endregion


    #region 方法

    /// <summary>
    /// 玩家水平輸入值
    /// </summary>
    // private float hValue;

    /// <summary>
    /// 取得玩家輸入水平軸向值：左與右 A、D、左、右
    /// </summary>
    /// 
    private void GetPlayerInputHorizontal()
    {
        // TAG：unity Input axis 

        //  水平值=輸入.取得肘向(肘像名稱)
        //  作用：取得玩家按下水平按鍵的值，按右為 1、按左為 -1、沒按為 0
        hValue = Input.GetAxis("Horizontal");
        print("玩家水平值：" + hValue);
    }

    [Header("重力"), Range(0.1f, 10)]
    public float gravity = 1;

    #endregion

    #region 課堂練習 Lesson 08 Exercise 01: 方法

    #region practice false
    //private void Start()
    //{
    //herir(8);
    //comerProps("道具名稱");
    //}
    #endregion

    // ---------分割線--------- //

    /// <summary>
    /// 移動，沒有傳回類型，帶小數點的左右數值
    /// </summary>
    /// <param name="horizontal">移動方左右向</param>

    private void Mover(float horizontal)
    {
        print("開車中、時速：" + horizontal);
        print("：" );

    }

    private void salto()
    {
        print("：");
    }

    private void atacar()
    {
        print("：");
    }

    public void herir(float herida)
    {
        print("受傷：" + herida);
    }

    private void morir()
    {
        print("：");
    }

    private void comerProps(string propname)
    {
        print("受傷：" + propname);
    }

    //  private void Drive(int speed,   string sound= "咻咻咻",    string effect = "灰塵")


    #endregion

    #region 課堂練習 Lesson 08 Exercise 01:方法 KID // Lesson 11 接續

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">左右數值</param>
    private void Move(float horizontal)
    {
        //  區域變數：在方法欄為，有區域性，僅限於此方法內存取
        //  簡寫：transform 此物件的 Transform 變形元件
        //  posMOve = 角色當前座標 + 玩家輸入的水平值
        Vector2 posMove = transform.position + new Vector3(horizontal,-gravity, 0) * speed * Time.fixedDeltaTime;
        //  鋼體，移動座標(要前往的座標)
        //  Time.fixedDeltaTime 指 1/50 秒 #讓數值變小
        Rig.MovePosition(posMove);
    }

    /// <summary>
    /// 旋轉方向：處理角色面向問題，按右角度0、按左腳度180
    /// </summary>
    private void TurnDirection()
    {
        //print("玩家按下右：" + Input.GetKeyDown(KeyCode.D));

        //  如果 玩家按 D 就將角度設定為 0, 0, 0
        if(Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = Vector3.zero;
        }

        //  如果 玩家按 A 就將角度設定為 0, 180,0
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180,0);
        }
    }
    /// <summary>
    /// 跳耀
    /// </summary>
    private void Jump() 
    {
        //  如果 玩家 按下 空白建 角色就往上跳躍
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rig.AddForce(new Vector2(0, JumpHeight));
        }
    }
    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {

    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">造成的傷害</param>
    public void Hurt(float damage)
    {

    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Death()
    {

    }
    /// <summary>
    /// 吃道具
    /// </summary>
    /// <param name="propName">吃到的道具名稱</param>
    private void EatProp(string propName)
    {

    }

    #endregion



}
