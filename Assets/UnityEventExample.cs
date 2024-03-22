using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// event(이벤트) : 개체에게 작업 실행을 알리기 위해 보내는 메세지
// 이벤트는 외부 가입자(Subscriber)에게 특정 일을 알려주는 기능을 가짐

// Event Handler(이벤트 핸들러) : 구독자 이벤트가 발생할 경우 어떤 명령을 실행할지 지정해 주는 것
// +=을 통해 이벤트에 추가 가능, -=을 통해 이벤트 제거 가능
// 이벤트 발생시 추가된 핸들러는 순차적으로 호출됨

class ClickEvent
{
    public event EventHandler Click;

    public void MouseButtonDown()
    {
        if (Click != null)
        {
            Click(this, EventArgs.Empty);
            // EventArgs 이벤트 받을때 파라미터로 데이터를 받고 싶을 경우 해당 클래스를 상속받아 사용함
            // EventArgs는 이벤트 발생과 관련된 정보르 가지고 있음
            // 이벤트 핸들러가 사용하는 파라미터 값임
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
        Debug.Log("버튼 클릭");
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
