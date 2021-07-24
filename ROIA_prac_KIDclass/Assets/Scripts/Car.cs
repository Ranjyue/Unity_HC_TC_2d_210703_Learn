using UnityEngine;
// 引用 Unity 引擎 提供 API (Unity Engine 命名空間)

// class=類別
// 語法：類別關鍵字 腳本命名


public class Car : MonoBehaviour
{

    #region 註解
    // 單行註解：填加說明、翻譯、紀錄等等…會被程式忽略
    //  KID 2021.07.17 (SAT.) 開發汽車腳本

    /*多行註解
     *  Method = 功能
     *  Field = 欄位
     */

    #endregion

    #region 認識欄位與常用四大類型
    //  欄位：儲存簡單的資料
    //  語法
    //  修飾詞    資料類型    欄位名稱    指定符號   預設值    結尾
    //  指定符號    =   (前後等號的空格可有可無)
    /*  修飾詞：
     *  私人 private 預設 - 不顯示
     *  公開 public             - 顯示
     */

    //  可以使用中文，不建議  -   編碼問題與轉換效能問題
    //  獨立開發    or   團隊許可

    //  Unity 內常用的四大類型
    //  整數          int          ex ：    1,  99, 0,  -123
    //  浮點數     float      ex ：     2.3,    3.1415,      -1.123
    //  字串          string   ex ：    BMW, BENZ, 對話內容@#…
    //  布林值     bool     ex ：    true,      false

    //  定義欄位
    public float weight = 3.5f;
    public int cc = 4000;
    public string brand = "Ferrari";
    public bool dormer = true;

    //  欄位屬性：輔助欄位填加額外功能
    //  語法：[屬性名稱(屬性值)]
    //  標題：[Header(字串)]
    [Header("輪胎數量")]
    public int wheelCount;

    //  提示：[ToolTip(字串)]
    [Tooltip("這個欄位的作用是設定汽車的高度…")]
    public float height = 1.5f;
    //  範圍 ：[Range(最小值、最大值)]    -   僅限數值類型  float   與   int 
    [Range(2, 10)]
    public int doorCount;
    //  錯誤示範：不是用於   float   與   int     以萬的類型
    [Range(2, 10)]
    public bool canOpenMusic;

    #endregion

    #region 其他類型
    //  顏色 color                                                                                        //不指定為黑色透明
    public Color color1;                                                                           //   使用預設顏色
    public Color color = Color.red;
    public Color yellow = Color.yellow;
    public Color colorCustom1 = new Color(0.5f, 0.5f, 0);    //  自訂顏色(R，G，B)
    public Color colorCustom2 = new Color(0.5f, 0.05f, 0, 5f);   //  自訂顏色 (R，G，B，A)


    //  座標 2    -   4   維   Vector2    -   4
    //  保存數值資訊、浮點數
    public Vector2 v2;
    public Vector2 Vector2 = Vector2.zero;
    public Vector2 v2One = Vector2.one;
    public Vector2 v2Up = Vector2.up;
    public Vector2 v2Right;
    public Vector2 v2Custom = new Vector2(-99.5f, 100.5f);

    public Vector3 v3;
    public Vector4 v4;

    //  按鍵類型
    public KeyCode kc;
    public KeyCode forward = KeyCode.D;
    public KeyCode attack = KeyCode.Mouse0;     //  左鍵  0，右鍵    1，滾輪    2

    //遊戲物件與元件
    public GameObject goCamera;     //  遊戲物件包含場頸上的以及專案內的預制物
    //  元件僅限於存放屬性面板有此元件的物件
    public Transform traCar;
    public SpriteRenderer sprPicture;

    #endregion

    #region 事件
    // 開始事件：撥放遊戲時執行一次，處理初始化
    private void Start()
    {
        #region 練習欄位
        // 輸出(任何類型資料);
        print("Hello Bro~");    // 只有編輯端看得到，玩家看不到，為了測試執行情況用途
                                // 輸出(任何類型資料);
                                //  unity>inspector>cube>將勾勾取消 = 取消物件執行

        //  練習曲德欄位 Get
        print(brand);
        //  練習曲德欄位 Get

        dormer = true;
        cc = 5000;
        weight = 9.9f;

        #endregion

        // Lesson 9
        // 呼叫方法語法：方法名稱();
        Drive50();
        Drive100();
        Drive150();
        Drive200();
    }

    //  更新事件：大約一秒 60次，60FPS，處理物件移動或者監聽玩家輸入
    private void Update()
    {
        print("我在   Update  內 @3@");
    }



    //
    private void FixedUpdate()
    {

    }



    #endregion

    #region 方法
    //  方法：實作比較複雜的行為，例如：汽車在前開、開啟汽車的音響並播放音樂…
    //  標準語法：修飾詞 類型  名稱  指定  預設值 ;
    //  方法語法：修飾詞 類型  名稱(餐數){   程式區塊    }
    //  類型：void -   無傳回
    //  定義方法：不會執行的必須呼叫，呼叫方式：在事件內呼叫此方法
    //  Lesson09：維護姓、擴充性

    private void Drive50()
    {
        print("開車中、時速：50");
    }

    private void Drive100()
    {
        print("開車中、時速：100");
    }
    private void Drive200()
    {
        print("開車中、時速：100");
    }
    private void Drive150()
    {
        print("開車中、時速：150");
    }

    #endregion

    #region 
    #endregion
}
