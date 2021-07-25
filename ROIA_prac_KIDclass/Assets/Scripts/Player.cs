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



    private Rigidbody2D Rigidbody2D;
    private AudioSource AudioSource;
    private Animator animator;
    #endregion

    #region  事件
    #endregion

    #region 方法
    #endregion

    #region 課堂練習 Lesson 08 Exercise 01: 方法

    private void Start()
    {
        herir(8);
        comerProps("道具名稱");
    }

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

    #region 課堂練習 Lesson 08 Exercise 01:方法 KID

    /// <summary>
    /// 移動
    /// </summary>
    /// <param name="horizontal">左右數值</param>
    private void Move(float horizontal)
    {
        
    }
    /// <summary>
    /// 跳耀
    /// </summary>
    private void Jump() 
    {
    
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
