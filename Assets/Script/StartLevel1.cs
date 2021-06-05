using Script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel1 : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("clicked this.");
        SceneManager.LoadSceneAsync(Constants.LevelScene.Level1);
    }
}