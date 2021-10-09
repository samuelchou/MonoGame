using UnityEngine;
using UnityEngine.Events;

/**
 * On Button pressed, trigger event.
 */
public class ButtonEvent : MonoBehaviour {
    public KeyCode inputKey = KeyCode.Tab;
    public UnityEvent triggerEvent;

    private void Update() {
        if (Input.GetKeyUp(inputKey)) triggerEvent.Invoke();
    }
}