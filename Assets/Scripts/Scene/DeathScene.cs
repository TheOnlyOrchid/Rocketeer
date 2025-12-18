using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DeathScene : MonoBehaviour
{
    void Start()
    {
        int levelOneIndex = 0;
        SceneController.SetSceneAfter(levelOneIndex, 5);
    }
}
