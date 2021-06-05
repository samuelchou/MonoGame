using System;
using UnityEngine;
using UnityEngine.Events;

namespace Script.LevelObject
{
    public class ProgressAdder : MonoBehaviour
    {
        public UnityEvent invokeOnDestroy;

        private void OnMouseDown()
        {
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            Debug.Log("Ball " + gameObject.name + " exploded into pieces.");
            invokeOnDestroy.Invoke();
        }
    }
}