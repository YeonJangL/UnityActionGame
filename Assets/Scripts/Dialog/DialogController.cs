using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �Ϲ� �˾� â�� Ȯ�� �˾� â �����ϴ� DialogControllerAlert, DialogControllerConfirm�� �θ� Ŭ����
public class DialogController : MonoBehaviour
{
    // �˾� â�� Ʈ������
    public Transform window;

    // �˾�â�� ���̴��� ��ȸ�ϴ� ���, ������ �ʰ� �����ϱ� ���� �Ӽ�
    public bool Visible
    {
        get
        {
            // �ش� ������Ʈ��  Ȱ��ȭ�Ǿ��ִ��� �ƴ����� �Ǵ��ϴ� �б� ���� �� activeSelf
            return window.gameObject.activeSelf;
        }

        private set
        {
            window.gameObject.SetActive(value);
            // visible �� ����� ���� Ȱ��ȭ�� ó���ϴ� �ڵ�
            // �ܺο��� ���� �� �� ����.
        }
    }

    // ���� �Լ� : �ڽ� �ʿ��� �������̵� �� ���� ���� �� ��� �ۼ��Ǵ� Ű����
    public virtual void Awake() { }

    public virtual void Start() { }

    public virtual void Build(DialogData data) { }

    // �˾��� ȭ�鿡 ��Ÿ���� ȣ���� �Լ�
    public void Show(Action callback)
    {
        StartCoroutine(OnEnter(callback));
    }

    // �˾��� ȭ�鿡�� ����� �� ȣ���� �Լ�
    public void Close(Action callback)
    {
        StartCoroutine(OnExit(callback));
    }

    IEnumerator OnEnter(Action callback)
    {
        Visible = true;

        if (callback != null)
        {
            callback();
        }
        yield break; // �۾� ����
    }

    IEnumerator OnExit(Action callback)
    {
        Visible = false;

        if (callback != null)
        {
            callback();
        }
        yield break; // �۾� ����
    }
}
