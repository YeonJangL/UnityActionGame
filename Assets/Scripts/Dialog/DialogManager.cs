using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DialogManager
{
   // 2024-03-26 순서 수정
    public enum DialogType { Alert, Confirm, Ranking }

    #region Fields
    List<DialogData> _dialogQueue;
    Dictionary<DialogType, DialogController> _dialogMap;
    DialogController _currentDialog;
    #endregion

    #region Singleton
    private static DialogManager instance = new DialogManager();

    public static DialogManager Instance { get { return instance; } }

    private DialogManager()
    {
        _dialogQueue = new List<DialogData>();
        _dialogMap = new Dictionary<DialogType, DialogController>();

        KeyValuePrepare();
    }
    #endregion

    public void KeyValuePrepare()
    {
        foreach (var pairs in _dialogMap)
        {
            var controller = pairs.Value.GetComponent<DialogController>();
            controller.Close(null);
        }
    }




    public void Regist(DialogType type, DialogController controller)
    {
        _dialogMap[type] = controller;
    }

    public void Push(DialogData data)
    {
        _dialogQueue.Add(data);

        if (_currentDialog == null)
        {
            ShowNext(); 
        }
    }

    public void Pop()
    {
        if (_currentDialog != null)
        {
            _currentDialog.Close(
                delegate
                {
                    _currentDialog = null;

                    if (_dialogQueue.Count > 0)
                    {
                        ShowNext();
                    }
                });
        }
    }

    public bool IsShowing() => _currentDialog != null; //현재 팝업 창이 표시되어있는지를 확인하는 기능

    private void ShowNext()
    {
        DialogData next = _dialogQueue[0];
        DialogController dialogController = _dialogMap[next.Type].GetComponent<DialogController>();

        _currentDialog = dialogController;

        _currentDialog.Build(next);
        _currentDialog.Show(delegate { }); //다이얼로그 보여주기
        _dialogQueue.RemoveAt(0);
    }
}