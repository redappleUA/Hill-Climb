using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController instance { get; private set; }

    [SerializeField] Image _fuelImage;
    [SerializeField] Gradient _fuelGradient;
    [SerializeField, Range(.1f, 5f)] float _fuelDrainSpeed = 1f;
    [SerializeField] float _maxFuelAmount = 100f;
    [SerializeField] MoveController _vehicle;

    private float _currentFuelAmount;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        if(_vehicle.IsBrakeButtonPressed || _vehicle.IsGasButtonPressed)
            _currentFuelAmount -= _fuelDrainSpeed * Time.deltaTime;

        UpdateUI();

        if (_currentFuelAmount <= 0f)
            GameOverController.instance.GameOver();
    }

    private void UpdateUI()
    {
        _fuelImage.fillAmount = _currentFuelAmount / _maxFuelAmount;
        _fuelImage.color = _fuelGradient.Evaluate(_fuelImage.fillAmount);
    }

    public void FillFuel(float fillingFuelAmount)
    {
        _currentFuelAmount += fillingFuelAmount;

        if (_currentFuelAmount > 100f)
            _currentFuelAmount = 100f;

        UpdateUI();
    }
}
