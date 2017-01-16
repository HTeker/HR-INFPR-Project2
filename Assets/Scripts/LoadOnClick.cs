using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {

    public PanelController canvasPanelController;
    public PanelController helpScreenPanelController;

    public void Start()
    {
        canvasPanelController.SwitchToPanelByName("Canvas_MainMenu");
    }

	public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadHelpScreen(string helpScreenName)
    {
        canvasPanelController.SwitchToPanelByName("Panel_HelpScreen");
        helpScreenPanelController.SwitchToPanelByName("Panel_" + helpScreenName);
    }
}
