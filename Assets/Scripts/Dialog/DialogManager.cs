using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 다이얼로그의 종류를 구분하는 enum 변수
/// </summary>
public enum DialogType
{
    Alert,
    Confirm,
    Ranking
}

// 상속 못받게 제한 거는 키위드 sealed -> 얘가 싱글톤이라
// 런 타임시 특정 함수 호출할 경우 부모, 자식 클래스를 전체 조사함
// 최종적으로 사용할 함수를 찾게 됨
// sealed 처리된 클래스는 이 과정을 생략할 수 있게 해줌
public sealed class DialogManager
{

    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog; // 현재 사용중인 다이얼로그(대화창)

    #region Singleton
    // 자기 자신에 대한 static 변수 생성
    private static DialogManager instance = new DialogManager();
    // C++ : Map
    // Python : dict
    // C# : Dictionary
    // Java : HashMap

    // 프로퍼티를 통해 접근 (프로퍼티 싱글톤)
    public static DialogManager Instance
    {
        get
        {
            return instance;
        }
    }

    // 생성 시 다이얼로그 큐와 다이얼로그 맵 초기화
    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();
    }
    #endregion

    public void Regist(DialogType tpye, DialogController controller)
    {
        // 딕셔너리명[키] = 값;
        // 해당 키를 가진 값이 만들어짐 (키 : 값)
        _dialogMap[tpye] = controller;
        //_dialogMap.Add(tpye, controller); //둘중하나 사용

    }

    // 데이터를 최상단에 저장
    // 다이얼로그 리스트를 저장하는 다이얼로그 큐에 새로운 다이얼로그 데이터를 추가하는 행위
    public void Push(DialogData data)
    {
        _dialogQueue.Add(data);

        if (_currentDialog == null)
        {
            ShowNext();
        }
    }

    // 데이터 최상단 값 제거
    // 리스트에서 마지막으로 열린 다이얼로그 닫는 기능
    public void Pop()
    {
        // 다이얼로그가 존재할 때
        if (_currentDialog != null )
        {
            // 익명 delegate
            // delegate(매개변수 목록) { 실행하고자 하는 코드 };
            // 함수 이름 없이 기능만 델리게이트에 할당하기 위한 수단
            _currentDialog.Close(
                delegate
                {
                    _currentDialog = null;
                    if (_dialogQueue.Count > 0 )
                    {
                        ShowNext();
                    }
                });
        }
    }

    private void ShowNext()
    {
        // 다이얼로그를 리스트에서 첫번째 값 가져오기
        var next = _dialogQueue[0];

        // 가져온 값의 형태를 확인해 어떤 컨트롤러 인지 확인
        var controller = _dialogMap[next.Type].GetComponent<DialogController>();

        // 조회한 다이얼로그 컨트롤러를 현재의 다이얼로그 컨트롤러로 지정
        _currentDialog = controller;

        // 현재의 다이얼로그 빌드
        _currentDialog.Build(next);

        // 다이얼로그를 화면에 보여줌
        _currentDialog.Show(delegate { });

        // 다이얼로그 리스트에서 꺼내온 데이터 제거
        _dialogQueue.Remove(next); // or _dialogQueue.RemoveAt(0);
    }

    // 현재 팝업 창이 표시되고 있는지 확인하는 변수
    // _current 가 비어있는 경우 없다고 판단
    public bool IsShowing() => _currentDialog != null;
}