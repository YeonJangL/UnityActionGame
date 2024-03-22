using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// 유니티에서 사용할 수 있는 대리자 유형
// 1. Action : 유니티에서 반환 값이 따로 없는 void 형태의 대리자
// 2. Func : 유니티에서 반환 값이 있는 형태의 대리자
// 3. UnityEvent : 인스펙터에서 이벤트를 노출 시켜, 할당 할 수 있게 해주는 도구
// 4. event
// 5. delegate

public class UnityDelegate : MonoBehaviour
{
    public UnityEvent onDead;

    public void Awake()
    {
        onDead.AddListener(Dead); // 스크립트를 통해 onDead에 이벤트 함수 등록
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
        Debug.Log("나 죽음");
    }

    Action testAction01;

    void Method01() { }
    void Method02() { }
    void Method03() { }

    int Method04() { return 1; }

    Action<int> testAction02; // 액션 <> 안에 넣는 값은 delegate로 호출할 함수의 매개 변수

    void Method05(int a) { }
    void Method06(int b) { }
    void Method07(int c) { }

    Func<bool> testFunc01;

    bool Method08() { return true; }
    bool Method09() { return false; }

    Func<int, int, int> testFunc02; // 맨 마지막에 적어놓은 타입 int는 return 타입
    // 나머지 값들은 전부 매개변수 처리

    int Method10(int a, int b) {  return a + b; }
    int Method11(int a, int b) {  return a - b; }

    // Start is called before the first frame update
    void Start()
    {
        testAction01 += Method01;
        testAction01 += Method02;
        testAction01 += Method03;
        // testAction01 += Method04; 오류
        testAction01();

        testAction02 += Method05;
        testAction02 += Method06;
        testAction02 += Method07;
        testAction02(10); // 대리자 호출
        testAction02?.Invoke(10); // 대리자 Invoke 기능 실행
        // ? -> 를 통해 NULL 체크를 진행 할 수 있어 NullReferenceException에 대한 상황 회피 가능

        testFunc01 += Method08;
        testFunc01 += Method09;

        if (testFunc01?.Invoke()  == true)
        {
            Debug.Log("작업 성공");
        }

        if (testFunc01())
        {
            Debug.Log("작업 성공");
        }

        testFunc02 += Method10;
        testFunc02 += Method11;

        Debug.Log(testFunc02?.Invoke(10, 5));
    }
}
