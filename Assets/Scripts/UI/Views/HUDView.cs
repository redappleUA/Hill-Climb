using UnityEngine;
using UnityEngine.UIElements;

public class HUDView : MonoBehaviour
{
    [SerializeField] UIDocument _UIDocument;
    public Button BrakeButton { get; private set; }
    public Button GasButton { get; private set; }

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void Initialize()
    {
        var root = _UIDocument.rootVisualElement;

        BrakeButton = root.Q<Button>(nameof(BrakeButton));
        GasButton = root.Q<Button>(nameof(GasButton));
    }
}
