using UnityEngine;

/**
 * Object revealer, used to reveal objects when they entered trigger.
 */
[RequireComponent(typeof(Collider))]
public class ObjectRevealer : MonoBehaviour {
    public string revealTag = "";

    private void OnTriggerEnter(Collider other) {
        var targetObj = other.gameObject;
        Debug.Log("detected obj entered: " + targetObj.name);
        if (targetObj.CompareTag(revealTag)) targetObj.SetActive(true);
    }
}