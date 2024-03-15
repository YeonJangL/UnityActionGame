using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 스테이지를 관리하는 컨트롤러
// 스테이지 시작과 종료 시점에 스테이지의 시작과 마감을 처리하는 기능
// 스테이지 내에서 획득하는 포인트를 관리하는 시스템

public class StageController : MonoBehaviour
{
    // 스테이지에서 쌓은 포인트를 저장할 변수
    public int StagePoint = 0;
    // 포인트 표시용 텍스트
    public Text PointText;

    // 스테이지 컨트롤러의 인스턴스를 저장하는 static 변수
    public static StageController instance;

    // 다른 코드 내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용 가능
    // 따로 연결해서 쓸 필요가 없기 때문에 편리함

    // 2024 - 03 - 15 Awake -> Start
    private void Start()
    {
        instance = this;

        // 안내창 값 설정
        var alert = new DialogDataAlert("게임 시작", "슬라임이랑 지렁이를 사냥하세요", delegate () { Debug.Log("OK 누름"); });

        // 매니저에 등록
        DialogManager.Instance.Push(alert);
    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        // Application.LoadLevel(Application.loadedLevel); 구 버전 코드(현재는 사용 안함)
        SceneManager.LoadScene("Game");
    }
}
