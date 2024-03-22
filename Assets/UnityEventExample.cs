using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// event(�̺�Ʈ) : ��ü���� �۾� ������ �˸��� ���� ������ �޼���
// �̺�Ʈ�� �ܺ� ������(Subscriber)���� Ư�� ���� �˷��ִ� ����� ����

// Event Handler(�̺�Ʈ �ڵ鷯) : ������ �̺�Ʈ�� �߻��� ��� � ����� �������� ������ �ִ� ��
// +=�� ���� �̺�Ʈ�� �߰� ����, -=�� ���� �̺�Ʈ ���� ����
// �̺�Ʈ �߻��� �߰��� �ڵ鷯�� ���������� ȣ���

class ClickEvent
{
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if (Click != null)
        {
            Click(this, EventArgs.Empty);
            // EventArgs �̺�Ʈ ������ �Ķ���ͷ� �����͸� �ް� ���� ��� �ش� Ŭ������ ��ӹ޾� �����
            // EventArgs�� �̺�Ʈ �߻��� ���õ� ������ ������ ����
            // �̺�Ʈ �ڵ鷯�� ����ϴ� �Ķ���� ����
        }
    }
}

public class UnityEventExample : MonoBehaviour
{
    ClickEvent clickEvent;
    // Start is called before the first frame update
    void Start()
    {
        clickEvent = new ClickEvent();
        clickEvent.Click += new EventHandler(ButtonClick);
    }

    private void ButtonClick(object sender, EventArgs e)
    {
        Debug.Log("��ư Ŭ��");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            clickEvent.MouseButtonDown();
        }
    }
}
