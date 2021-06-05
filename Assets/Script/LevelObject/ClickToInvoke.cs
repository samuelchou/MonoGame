using System;
using UnityEngine;
using UnityEngine.Events;

namespace Script.LevelObject
{
    public class ClickToInvoke : MonoBehaviour
    {
        public UnityEvent invokeOnClick;

        private void OnMouseDown()
        {
            invokeOnClick.Invoke();
        }
    }
}