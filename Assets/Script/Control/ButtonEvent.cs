using UnityEngine;
using UnityEngine.Events;

/**
 * On Button pressed, trigger event.
 */
public class ButtonEvent : MonoBehaviour {
    public KeyCode inputKey = KeyCode.Tab;
    public UnityEvent triggerEvent;

    private void FixedUpdate() {
        if (Input.GetKeyDown(inputKey)) triggerEvent.Invoke();
    }
}