using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public static class SceneController
{

    private static string[] scenes = { "level_1", "SampleScene"};
    private static int currentSceneIndex = 0;


    public static bool nextScene()
    {
        bool successful;

        currentSceneIndex++;

        if(currentSceneIndex >= scenes.Length)
        {
            Debug.Log("Can't move to this scene, there is no screen.");
            successful = false;
            return successful;
        }
        Debug.Log("next scene");
        SceneManager.LoadScene(scenes[currentSceneIndex]);
        successful = true;
        
        return successful;
        
    }
}
