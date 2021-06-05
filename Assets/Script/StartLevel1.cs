using Script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel1 : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Pressed enter.");
            SceneManager.LoadSceneAsync(Constants.LevelScene.Level1);
        }
    }
}