using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveController : MonoBehaviour
{
    [SerializeField] VehicleView _vehicle;
    private HUDView _hud;

    private bool _isGasButtonPressed;
    private bool _isBrakeButtonPressed;

    private void Awake()
    {
        _hud = FindObjectOfType<HUDView>();
    }
    private void Start()
    {
        _hud.GasButton.RegisterCallback<PointerDownEvent>(OnGasButtonPressed);
        _hud.GasButton.RegisterCallback<PointerUpEvent>(OnGasButtonReleased);

        _hud.BrakeButton.RegisterCallback<PointerDownEvent>(OnBrakeButtonPressed);
        _hud.BrakeButton.RegisterCallback<PointerUpEvent>(OnBrakeButtonReleased);
    }

    private void FixedUpdate()
    {
        if (_isGasButtonPressed) MoveForward();
        else if(_isBrakeButtonPressed) MoveBackward();
    }

    private void OnGasButtonPressed(PointerDownEvent evt) => _isGasButtonPressed = true;
    private void OnGasButtonReleased(PointerUpEvent evt) => _isGasButtonPressed = false;
    private void OnBrakeButtonPressed(PointerDownEvent evt) => _isBrakeButtonPressed = true;
    private void OnBrakeButtonReleased(PointerUpEvent evt) => _isBrakeButtonPressed = false;

    private void MoveForward()
    {
        _vehicle.FrontTireRB.AddTorque(-Vector2.right.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.BackTireRB.AddTorque(-Vector2.right.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.CarRB.AddTorque(-Vector2.right.x * _vehicle.RotationSpeed * Time.fixedDeltaTime);
    }
    private void MoveBackward()
    {
        _vehicle.FrontTireRB.AddTorque(-Vector2.left.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.BackTireRB.AddTorque(-Vector2.left.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.CarRB.AddTorque(-Vector2.left.x * _vehicle.RotationSpeed * Time.fixedDeltaTime);
    }
}
