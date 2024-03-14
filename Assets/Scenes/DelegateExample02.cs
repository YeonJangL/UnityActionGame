using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateExample02 : MonoBehaviour
{
    static int coin = 0;
    static int point = 0;
    static int exp = 0;

    public delegate void PlusDelegate(int _coin, int _point, int _exp);

    static void PlusCoin(int _coin, int _point, int _exp)
    {
        coin += _coin;
        Debug.Log($"{_coin}�� ȹ��");
    }

    static void PlusPoint(int _coin, int _point, int _exp)
    {
        point += _point;
        Debug.Log($"{_point}�� ȹ��");
    }

    static void PlusExp(int _coin, int _point, int _exp)
    {
        exp += _exp;
        Debug.Log($"{_exp}�� ȹ��");
    }

    private void Start()
    {
        // ���� 100, ����Ʈ 50, ����ġ 500ȹ��
        /*PlusCoin(100);
        PlusPoint(50);
        PlusExp(500);*/

        // ��������Ʈ ü��
        // ��������Ʈ���� �Լ��� + �Ǵ� - �� ���� �߰�, ���� ����
        // �߰��� ��� �߰� ������� �Լ� ȣ�� �� �����(�Լ� ���� ����)

        PlusDelegate kill_Unit = PlusCoin;

        kill_Unit += PlusPoint;
        kill_Unit += PlusExp;

        kill_Unit(100, 50, 500);
    }
}
