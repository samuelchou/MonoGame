using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(Constants.LevelScene.Level1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
