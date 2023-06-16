using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    [SerializeField] VehicleView _vehicle;
    [SerializeField] ButtonHeldController _gasButton;
    [SerializeField] ButtonHeldController _brakeButton;

    public bool IsGasButtonPressed { get; private set; }
    public bool IsBrakeButtonPressed { get; private set; }

    private void Start()
    {
        _gasButton.OnHeld.AddListener(OnGasButtonPressed);
        _gasButton.OnHeldEnded.AddListener(OnGasButtonReleased);
        _brakeButton.OnHeld.AddListener(OnBrakeButtonPressed);
        _brakeButton.OnHeldEnded.AddListener(OnBrakeButtonReleased);
    }

    private void Update()
    {
        if (IsGasButtonPressed)
        {
            MoveForward();
        }
        else if (IsBrakeButtonPressed)
        {
            MoveBackward();
        }
    }

    private void OnGasButtonPressed() => IsGasButtonPressed = true;
    private void OnGasButtonReleased() => IsGasButtonPressed = false;
    private void OnBrakeButtonPressed() => IsBrakeButtonPressed = true;
    private void OnBrakeButtonReleased() => IsBrakeButtonPressed = false;

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
