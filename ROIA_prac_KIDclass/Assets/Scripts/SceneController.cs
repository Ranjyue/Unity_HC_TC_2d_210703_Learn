using UnityEngine;
using UnityEngine.SceneManagement;  // �ޥ� �����޲z API

public class SceneController : MonoBehaviour
{
    //  C# script �R�W�ɤ���O scene or sceneManager 
    //  �H�W�|�P�X�ʨt�ά۽�

    //  Unity ���s�p��P�}�����q
    //  1. ���}����k
    //  2. �ݭn���骫�󱾦��}��

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        // �����޲z�A���J����(�����W��) - ���J���w������
        SceneManager.LoadScene("�C������");

    }

    /// <summary>
    /// ���}�C������
    /// </summary>  
    public void QuitGameScene()
    {
        Application.Quit();         //  ���ε{��.���}() - �����C��
        print("���}�C��");           //  QUIT �b�s�边�����|����
    }


}
