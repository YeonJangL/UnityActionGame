using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ����Ƽ���� ����� �� �ִ� �븮�� ����
// 1. Action : ����Ƽ���� ��ȯ ���� ���� ���� void ������ �븮��
// 2. Func : ����Ƽ���� ��ȯ ���� �ִ� ������ �븮��
// 3. UnityEvent : �ν����Ϳ��� �̺�Ʈ�� ���� ����, �Ҵ� �� �� �ְ� ���ִ� ����
// 4. event
// 5. delegate

public class UnityDelegate : MonoBehaviour
{
    public UnityEvent onDead;

    public void Awake()
    {
        onDead.AddListener(Dead); // ��ũ��Ʈ�� ���� onDead�� �̺�Ʈ �Լ� ���
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            onDead?.Invoke();
        }
    }

    void Dead()
    {
        Debug.Log("�� ����");
    }

    Action testAction01;

    void Method01() { }
    void Method02() { }
    void Method03() { }

    int Method04() { return 1; }

    Action<int> testAction02; // �׼� <> �ȿ� �ִ� ���� delegate�� ȣ���� �Լ��� �Ű� ����

    void Method05(int a) { }
    void Method06(int b) { }
    void Method07(int c) { }

    Func<bool> testFunc01;

    bool Method08() { return true; }
    bool Method09() { return false; }

    Func<int, int, int> testFunc02; // �� �������� ������� Ÿ�� int�� return Ÿ��
    // ������ ������ ���� �Ű����� ó��

    int Method10(int a, int b) {  return a + b; }
    int Method11(int a, int b) {  return a - b; }

    // Start is called before the first frame update
    void Start()
    {
        testAction01 += Method01;
        testAction01 += Method02;
        testAction01 += Method03;
        // testAction01 += Method04; ����
        testAction01();

        testAction02 += Method05;
        testAction02 += Method06;
        testAction02 += Method07;
        testAction02(10); // �븮�� ȣ��
        testAction02?.Invoke(10); // �븮�� Invoke ��� ����
        // ? -> �� ���� NULL üũ�� ���� �� �� �־� NullReferenceException�� ���� ��Ȳ ȸ�� ����

        testFunc01 += Method08;
        testFunc01 += Method09;

        if (testFunc01?.Invoke()  == true)
        {
            Debug.Log("�۾� ����");
        }

        if (testFunc01())
        {
            Debug.Log("�۾� ����");
        }

        testFunc02 += Method10;
        testFunc02 += Method11;

        Debug.Log(testFunc02?.Invoke(10, 5));
    }
}
