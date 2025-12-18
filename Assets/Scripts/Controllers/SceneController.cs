using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class SceneController
{

    private static string[] scenes = { "level_1", "DeathScreen"};
    private static int currentSceneIndex = 0;


    public static bool nextScene()
    {
        bool successful;

        currentSceneIndex++;

        if(currentSceneIndex >= scenes.Length || currentSceneIndex < 0)
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

    public static bool prevScene()
    {
        bool successful;

        currentSceneIndex++;

        if (currentSceneIndex >= scenes.Length || currentSceneIndex < 0)
        {
            Debug.Log("Can't move to this scene, there is no screen.");
            successful = false;
            return successful;
        }
        Debug.Log("previous scene");
        SceneManager.LoadScene(scenes[currentSceneIndex]);
        successful = true;

        return successful;
    }

    public static bool setScene(int sceneIndex)
    {
        bool successful;

        currentSceneIndex = sceneIndex;

        if (currentSceneIndex >= scenes.Length || currentSceneIndex < 0)
        {
            Debug.Log("Can't move to this scene, there is no screen.");
            successful = false;
            return successful;
        }
        Debug.Log($"set scene to {scenes[currentSceneIndex]}");
        SceneManager.LoadScene(scenes[currentSceneIndex]);
        successful = true;

        return successful;
    }

    public static async void SetSceneAfter(int sceneIndex, float secondsToWait)
    {
        Debug.Log($"setting scene to index: {sceneIndex} after {secondsToWait}");
        int delay = (int)(secondsToWait * 1000);

        await Task.Delay(delay);

        Debug.Log($"setting scene back to level {sceneIndex}");
        setScene(sceneIndex);
    }
}
