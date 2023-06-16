using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] VehicleView _vehicle;
    [SerializeField] ButtonHeldController _gasButton;
    [SerializeField] ButtonHeldController _brakeButton;

    private bool _isGasButtonPressed;
    private bool _isBrakeButtonPressed;

    private void Start()
    {
        _gasButton.OnHeld.AddListener(OnGasButtonPressed);
        _gasButton.OnHeldEnded.AddListener(OnGasButtonReleased);
        _brakeButton.OnHeld.AddListener(OnBrakeButtonPressed);
        _brakeButton.OnHeldEnded.AddListener(OnBrakeButtonReleased);
    }

    private void Update()
    {
        if (_isGasButtonPressed)
        {
            MoveForward();
        }
        else if (_isBrakeButtonPressed)
        {
            MoveBackward();
        }
    }

    private void OnGasButtonPressed() => _isGasButtonPressed = true;
    private void OnGasButtonReleased() => _isGasButtonPressed = false;
    private void OnBrakeButtonPressed() => _isBrakeButtonPressed = true;
    private void OnBrakeButtonReleased() => _isBrakeButtonPressed = false;

    public void MoveForward()
    {
        _vehicle.FrontTireRB.AddTorque(-Vector2.right.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.BackTireRB.AddTorque(-Vector2.right.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.CarRB.AddTorque(-Vector2.right.x * _vehicle.RotationSpeed * Time.fixedDeltaTime);
    }
    public void MoveBackward()
    {
        _vehicle.FrontTireRB.AddTorque(-Vector2.left.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.BackTireRB.AddTorque(-Vector2.left.x * _vehicle.Speed * Time.fixedDeltaTime);
        _vehicle.CarRB.AddTorque(-Vector2.left.x * _vehicle.RotationSpeed * Time.fixedDeltaTime);
    }
}
