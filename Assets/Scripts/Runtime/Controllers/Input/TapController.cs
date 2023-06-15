using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TapController : MonoBehaviour
{
    public UnityEvent OnTapStarted = new(), OnTapEnded = new();

    [SerializeField] Camera _camera;

    private Control _control = null;
    private Transform _startTarget, _preLastTarget;

    private void Awake()
    {
        _control = new();

        _control.Map.PrimaryTouchContact.started += (context) => TouchStarted();
        _control.Map.PrimaryTouchContact.canceled += (context) => TouchEnded();
    }

    private void TouchEnded()
    {
        throw new NotImplementedException();
    }

    private void TouchStarted()
    {
        throw new NotImplementedException();
    }
}
