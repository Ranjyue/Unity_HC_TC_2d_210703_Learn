using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class SceneController : MonoBehaviour
{
    //  C# script 命名時不能是 scene or sceneManager 
    //  以上會與驅動系統相衝

    //  Unity 按鈕如何與腳本溝通
    //  1. 公開的方法
    //  2. 需要實體物件掛此腳本

    /// <summary>
    /// 載入遊戲場景
    /// </summary>
    public void LoadGameScene()
    {
        // 場景管理，載入場景(場景名稱) - 載入指定的場景
        SceneManager.LoadScene("遊戲場景");

    }

    /// <summary>
    /// 離開遊戲場景
    /// </summary>  
    public void QuitGameScene()
    {
        Application.Quit();         //  應用程式.離開() - 關閉遊戲
        print("離開遊戲");           //  QUIT 在編輯器內不會執行
    }


}
