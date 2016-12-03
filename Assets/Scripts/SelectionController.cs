using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class SelectionController : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if (!hit.transform.CompareTag("Ship") && !hit.transform.CompareTag("DockingStation"))
                    {
                        if (Global.CurrentSelectedShip != null)
                        {
                            Global.CurrentSelectedShip.Deselect();
                        }
                    }
                }
                else
                {
                    if (Global.CurrentSelectedShip != null)
                    {
                        Global.CurrentSelectedShip.Deselect();
                    }
                }
            }
        }
    }
}
