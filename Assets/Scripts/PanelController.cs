using UnityEngine;
using System.Collections;

public class PanelController : MonoBehaviour {

    public GameObject[] panels;

    public void SwitchToPanelByName(string panelName)
    {
        foreach(GameObject panel in panels)
        {
            if (panel.name == panelName)
                panel.SetActive(true);
            else
                panel.SetActive(false);
        }
    }
}
