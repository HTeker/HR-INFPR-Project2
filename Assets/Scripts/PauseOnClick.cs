using UnityEngine;
using System.Collections;

public class PauseOnClick : MonoBehaviour {

    bool paused = false;

    void OnGUI()
    {
        if(paused)
        {
            GUILayout.Label("Game is paused!");
            if (GUILayout.Button("Click me to unpaue"))
                //paused = togglePause();
                togglePause();
        }
    }

    public void togglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            //return (false);
        }
        else
        {
            Time.timeScale = 0f;
           // return (true);
        }
    }
}
