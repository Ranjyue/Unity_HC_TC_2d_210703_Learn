using UnityEngine;

/// <sumary>
/// 認識  API     以及第一種用法：靜態  static
/// </sumary>

public class APIStatic : MonoBehaviour
{
    //  API 文件，分為兩大類
    //  1.  靜  態： 有關鍵字   static
    //  2.  非靜態： 無關鍵字   static

    //  屬性： Properties 可以理解為等同於欄位  
    //  方法： Methods
    //  struct(可以當成屬性) in UnityEngine

    private int count;                              // @ranjyue

    public float radius = 5;                        // @ranjyue
    public float number = 9.99f;                    // @KID
    public Vector3 a = new Vector3(1, 1, 1);        // @KID
    public Vector3 b = new Vector3(22, 22, 22);     // @KID


    private void Start()
    {
        #region 認識靜態屬性與方法
        //  靜態屬性
        //  1.  取得
        //  ※ 語法：類別，靜態屬性
        print("隨機值" + Random.value);        // 0 - 1
        print("無限大" + Mathf.Infinity);

        //  2. 設定
        /*  class in UnityEngine
         *  API 絕對是公開的=Public
         */
        //  ※ 語法：類別，靜態屬性 指定  值 ;
        Cursor.visible = false;
        //  Random.value = 7.7f;// - 唯獨屬性不能設定 = Read only
        Application.OpenURL("https://docs.unity3d.com/ScriptReference/Random.html");
        //  不見得不提示 Read only 就代表可以設定，用測試最快(指標會顯示 set;=可以設定 or get;=可以取得

        Screen.fullScreen = true;

        //  靜態方法
        //  3. 呼叫
        //  ※ 語法：類別，靜態屬性(對應引數);
        float r = Random.Range(7.5f, 9.8f);
        print("隨機範圍 7.5 ~ 9.8" +r);
        #endregion

        #region 課堂練習：練習靜態屬性與方法 ranjyue
        //  C# 靜態屬性與方法練習 
        //  靜態屬性 Static Properties

        //  所有攝影機數量 tag：Camera
        count = Camera.allCamerasCount;
        print("We've got" + count + "cameras");

        //  2D 的重力大小 tag：Physics2D
        Physics2D.gravity = new Vector2(0, -20);
        print("Gravedad al 20%" );

        //  圓周率 tag：Mathf
        float perimeter = 2.0f * Mathf.PI * radius;
        Debug.Log("The perimeter of the circle is: " + perimeter);
        // Debug 是專用在 API 不用 :MonoBehaviour except 將 unityEngenine 去掉
        // Print 比需在 public class APIStatic : MonoBehaviour 環境下才能測試


        #endregion

        #region 練習靜態屬性與方法 // KID
        //  1. 取得靜態屬性
        print("所有攝影機數量：" + Camera.allCamerasCount);
        print("2D 重力：" + Physics2D.gravity);
        print("圓周率：" + Mathf.PI);
        //  2. 設定靜態屬性
        Physics2D.gravity = new Vector2(0, -20);
        print("2D 重力：" + Physics2D.gravity);
        Time.timeScale = 0.5f;                 // 慢動作、快動作 2、暫停 0 
        print("時間大小：" + Time.timeScale);
        /// 獨立遊戲 movie = videogame

        //  3. 呼叫靜態方法
        /// unity api 
        number = Mathf.Floor(number);
        print("9.99 去小數點：" + number);

        float d = Vector3.Distance(a, b);
        print("A 與 B 的距離：" + d);

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
        hp = Mathf.Clamp(hp, 0, 100);        // 數學，夾住(值、最小值、最大值) - 將輸入的值夾在最小最大範圍內
        print("血量：" + hp);

        #region 課堂練習：練習靜態屬性與方法 ranjyue
        //  是否輸入任意鍵 tag：Input
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);

            //  遊戲經過時間 tag：Time //時間大小設定為 0.5 (慢動作)
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
        }
        #endregion

        #region 練習靜態屬性與方法
        print("是否輸入任意鍵：" + Input.anyKey);
        //print("遊戲經過時間：" + Time.time);

        //  3. 呼叫靜態方法
        bool space = Input.GetKeyDown("Space");
        print("是否按下空白鍵：" + space);


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
