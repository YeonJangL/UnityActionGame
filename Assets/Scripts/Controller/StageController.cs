using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// ���������� �����ϴ� ��Ʈ�ѷ�
// �������� ���۰� ���� ������ ���������� ���۰� ������ ó���ϴ� ���
// �������� ������ ȹ���ϴ� ����Ʈ�� �����ϴ� �ý���

public class StageController : MonoBehaviour
{
    // ������������ ���� ����Ʈ�� ������ ����
    public int StagePoint = 0;
    // ����Ʈ ǥ�ÿ� �ؽ�Ʈ
    public Text PointText;

    // �������� ��Ʈ�ѷ��� �ν��Ͻ��� �����ϴ� static ����
    public static StageController Instance;

    // �ٸ� �ڵ� ������ StageController.instance.AddPoint(10)�� ���� ���·� ��� ����
    // ���� �����ؼ� �� �ʿ䰡 ���� ������ ����

    // 2024 - 03 - 15 Awake -> Start
    private void Start()
    {
        Instance = this;
        DialogDataAlert alert = new DialogDataAlert("START", "Game Start!",
            delegate ()
            {
                Debug.Log("OK Pressed!");

            });
        DialogManager.Instance.Push(alert);
    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        // Application.LoadLevel(Application.loadedLevel); �� ���� �ڵ�(����� ��� ����)
        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if you want to restart the game.",
           delegate (bool yn)
           {
               if (yn)
                   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
               else
                   Application.Quit();
           });

        DialogManager.Instance.Push(confirm);
    }
}
