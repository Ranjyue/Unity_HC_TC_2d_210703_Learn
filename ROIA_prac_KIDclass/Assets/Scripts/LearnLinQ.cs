using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//  �ޥ� LinQ �d�߻y�� API - �d��}�C���

public class LearnLinQ : MonoBehaviour
{
    public int[] scores = { 10, 80, 60, 30, 70, 99, 77, 1, 0 };

    public int[] result;
    public int[] resultEqualThan60;

    private void Start()
    {
        //  �ˬd���S�� 0 ��
        //  �H�ڹF Lambda ²�g c# 3.0 �O�᪺²�g�覡

        //  �ˬd scores �� ���S�� ���Ƭ� 0 ����
        //  x �N�W��
        //  => �]�w����
        result = scores.Where(x => x == 0). ToArray();

        //  �ˬd���S���j�󵥩� 60 ��
        resultEqualThan60 = scores.Where(x => x >= 60).ToArray();
    }
}