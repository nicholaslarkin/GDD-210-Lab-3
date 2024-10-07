using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerIntroduction : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene(2);
    }
}
