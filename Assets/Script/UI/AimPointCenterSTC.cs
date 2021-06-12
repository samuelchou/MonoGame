using UnityEngine;

namespace Script.UI
{
    //just a little aim-point-center-GUI made by STC, 2017/06/16
    //contact: stc.ntu@gmail.com
    //usage: apply onto camera(suggested main), and get it a texture. Then the texture will show on screen center, regarded as an aim.
    //suggest: draw a cross / circle / ... anything like an aim. Or you can just simply use the "knob" image in Unity, I guess that's not bad.
    public class AimPointCenterSTC : MonoBehaviour
    {
        public Texture2D texture;

        private void OnGUI()
        {
            var rect = new Rect(Screen.width / 2 - texture.width / 2,
                Screen.height / 2 - texture.height / 2,
                texture.width, texture.height);

            GUI.DrawTexture(rect, texture);
        }
    }
}