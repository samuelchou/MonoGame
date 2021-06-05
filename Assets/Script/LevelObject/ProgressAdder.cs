using Script.System;
using UnityEngine;

namespace Script.LevelObject
{
    public class ProgressAdder : MonoBehaviour
    {
        public float addProgress = 1.0f;

        private void OnMouseDown()
        {
            Debug.Log("clicked and add progress " + addProgress);
            GameObject.FindWithTag("System").GetComponent<LevelManager>().AddProgress(addProgress);
            Destroy(gameObject);
        }
    }
}