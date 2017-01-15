using UnityEngine;
using System.Collections;

public class PauseOnClick : MonoBehaviour {
    
    public GameObject PauseScreen;

    private void Start()
    {
        PauseScreen.SetActive(false);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PauseScreen.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        PauseScreen.SetActive(false);
    }
}
