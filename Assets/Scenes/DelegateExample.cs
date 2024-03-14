using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Delegate?
// C / C++ �� �Լ� �����Ϳ� ����� ����

// ��������Ʈ�� �Լ� Ÿ�Կ� ���� ���Ǹ� �����ϰ�
// �Ű������� ���� ���踦 ������ ���
// ���� Ÿ��, ���� �Ű������� ���� �޼ҵ带 �ҷ��� ����� �� �ִ� C# ����(�븮��)
public class Delegate : MonoBehaviour
{
    // 1. delegate ����
    delegate void DelegateTester();

    // 2. delegate �� ������ ���¿� ������ �Լ� ����
    void DelegateTest01()
    {
        Debug.Log("�븮�� �׽�Ʈ 1");
    }

    void DelegateTest02()
    {
        Debug.Log("�븮�� �׽�Ʈ 2");
    }

    // Start is called before the first frame update
    void Start()
    {
        // ��������Ʈ ����
        // ��������Ʈ�� ������ = new ��������Ʈ��(�Լ���);
        DelegateTester delegateTester = new DelegateTester(DelegateTest01);

        // ��������Ʈ ȣ��
        delegateTester();

        delegateTester = DelegateTest02; // ��������Ʈ�� ó���� �Լ� ����

        delegateTester();
    }

    // ��� ����?
    // 
}
