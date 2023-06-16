using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.UI.Button;

public class ButtonHeldController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] ButtonClickedEvent _onHeld;
    [SerializeField] ButtonClickedEvent _onHeldEnded;
    public ButtonClickedEvent OnHeld => _onHeld;
    public ButtonClickedEvent OnHeldEnded => _onHeldEnded;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnHeld.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnHeldEnded.Invoke();
    }
}
