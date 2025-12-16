using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneController.nextScene();
    }
}