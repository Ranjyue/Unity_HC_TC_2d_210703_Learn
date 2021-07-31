using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APINonStatic : MonoBehaviour
{
    // API 文件：分為兩大類
    //  1.  靜  態： 有關鍵字   static
    //  2.  非靜態： 無關鍵字   static  → Public Methods

    //  NOTE：GameObject 的連體嬰在屬性面板一定會有 Transform 物件 以及名稱欄位
    //  https://docs.unity3d.com/ScriptReference/Transform.html
    //  屬性面板 元件都是非靜態

    //  ------ 使用非靜態屬性
    //  使用非靜態屬性 1. 先定義此非靜態屬性的類別欄位
    //  使用非靜態屬性 3. 欄位必須放入要取的資訊的物件，※ 不能為空值
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
        #region 認識非靜態屬性
        //  1. 取得非靜態屬性

        //print("取得座標：" + Transform.position);  // 錯誤：需要有物件參考

        //  ------ 使用非靜態屬性
        //  使用非靜態屬性 2.
        //  ※ 使用語法：欄位名稱.非靜態屬性
        print("取得立方體座標：" + traA.position);  // 座標會四捨五入到小數點1 EX：6.95 → 7.0
        print("取得攝影機的背景顏色：" + cam.backgroundColor);

        //  2. 設定非靜態屬性
        //  ※ 語法：欄位.非靜態屬性 指定 值;
        cam.backgroundColor = new Color(0.8f, 0.5f, 0.6f);

        //  3. 呼叫非靜態屬性
        //  ※ 語法：欄位.非靜態方法(對應的引數);
        traB.Translate(1, 0, 0);
        lightA.Reset();
        #endregion

        #region 課堂練習：非靜態屬性與方法練習 ranjyue KID 修正

        // 練習不順利

        // DOC：https://paper.dropbox.com/doc/C-EsPpCQXko0Vt7P1tmH9so

        //  1. 取得非靜態屬性
        //  ※ 使用語法：欄位名稱.非靜態屬性
        print("取得攝影機深度：" + camA.depth);
        print("取得圖片crate的顏色：" + srA);


        //  2. 設定非靜態屬性
        //  ※ 語法：欄位.非靜態屬性 指定 值;
        //  cam.depth = new float(); ranjyue
        //  ※ random = 靜態
        camA.backgroundColor = Random.ColorHSV();
        srA.flipY = true;



        //  3. 呼叫非靜態屬性
        //  ※ 語法：欄位.非靜態方法(對應的引數);
        // traC.rotation(); ranjyue 
        


        #endregion


    }


   public void Update()
    {
        traC.Rotate(0, 0, 1);
        rigiA.AddForce(new Vector2(0,10));
    }
}
