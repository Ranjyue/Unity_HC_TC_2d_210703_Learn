using UnityEngine;
using UnityEngine.SceneManagement;  // �ޥ� �����޲z API

public class SceneController : MonoBehaviour

{

    //  Unity �L�k���W�}������j��]
    //  1.  �}����������L�C�A����@��
    //  2.  ���O�P�ɦW�٤��P

    //  C# script �R�W�ɤ���O scene or sceneManager 
    //  �H�W�|�P�X�ʨt�ά۽�

    //  Unity ���s�p��P�}�����q
    //  1. ���}����k
    //  2. �ݭn���骫�󱾦��}��
    //  3. ���s On click �]�w�I���ƥ󬰦�����H�έn�I�s����k


    

    /// <summary>
    /// ���J�C������
    /// </summary>
    public void LoadGameScene()
    {
        // �����޲z�A���J����(�����W��) - ���J���w������
        // SceneManager.LoadScene("�C������");

        //  �������J����
        //  ����I�s(��k�W�١A����ɶ�)
        //  �@�ΡG���ݫ��w�ɶ���A�I�s���w��k
        Invoke("DelayLoadGameScene", 2);

    }

    //  ���ݤ@�q�ɶ��A�����k
    //  Invoke ����I�s
    /// <summary>
    /// ������J����
    /// </summary>
    public void DelayLoadGameScene()
    {
        // �����޲z�A���J����(�����W��)- ���J���w����
        SceneManager.LoadScene("�C������");

    }

    /// <summary>
    /// ���}�C��
    /// </summary>
    public void QuitGame()
    {
        Invoke("DelayQuitGame", 2);
    }

    /// <summary>
    /// ���}�C������
    /// </summary>  
    public void DelayQuitGame()
    {
        Application.Quit();         //  ���ε{��.���}() - �����C��
        print("���}�C��");           //  QUIT �b�s�边�����|����
    }





}
