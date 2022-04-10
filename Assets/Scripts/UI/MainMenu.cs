using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadNormal()
    {
        SceneManager.LoadScene(1);
    }

    public void loadBenchmark()
    {
        SceneManager.LoadScene(2);
    }
}
