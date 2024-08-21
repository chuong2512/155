using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class KeyCodeEvent : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public EventTrigger eventTrigger;

    public KeyCode KeyCode = KeyCode.A;

    private EventTrigger.TriggerEvent OnKeyEnter;
    private EventTrigger.TriggerEvent OnKeyDown;
    private EventTrigger.TriggerEvent OnKeyExit;
    private EventTrigger.TriggerEvent OnKeyUp;

    private void Start()
    {
        OnKeyEnter = eventTrigger.triggers.Find(entry => entry.eventID == EventTriggerType.PointerEnter).callback;
        OnKeyDown = eventTrigger.triggers.Find(entry => entry.eventID == EventTriggerType.PointerDown).callback;
        OnKeyExit = eventTrigger.triggers.Find(entry => entry.eventID == EventTriggerType.PointerExit).callback;
        OnKeyUp = eventTrigger.triggers.Find(entry => entry.eventID == EventTriggerType.PointerUp).callback;
    }

    private void OnValidate()
    {
        _text ??= GetComponentInChildren<TextMeshProUGUI>();

        if (_text != null)
        {
            _text.text = KeyCode.ToString();
        }

        eventTrigger = GetComponent<EventTrigger>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode))
        {
            OnKeyEnter?.Invoke(null);
        }
        else if (Input.GetKey(KeyCode))
        {
            OnKeyDown?.Invoke(null);
        }
        else if (Input.GetKeyUp(KeyCode))
        {
            OnKeyUp?.Invoke(null);
        }
    }
}