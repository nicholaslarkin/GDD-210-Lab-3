using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerTitleScreen : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(1);
    }
}
