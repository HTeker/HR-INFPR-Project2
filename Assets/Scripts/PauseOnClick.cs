using UnityEngine;
using System.Collections;

public class PauseOnClick : MonoBehaviour {
    
    public GameObject PauseScreen;

    private void Start()
    {
        Debug.Log("Start");
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }

    public void Pause()
    {
        Debug.Log("Pause");
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Debug.Log("Resume");
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }
}
