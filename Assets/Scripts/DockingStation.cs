using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace Scripts {
    public class DockingStation : MonoBehaviour
    {
        [SerializeField]
        private ShipColor color;

        private Ship undockedShip;
        private Queue<Ship> dockedShips;

        private Canvas canvas;
        private Text timerText;

        // Use this for initialization
        void Start()
        {
            dockedShips = new Queue<Ship>();
            canvas = GetComponentInChildren<Canvas>();
            if (canvas)
            {
                timerText = canvas.GetComponentInChildren<Text>();
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            dockedShips = new Queue<Ship>();
            canvas = GetComponentInChildren<Canvas>();
            if (canvas)
            {
                timerText = canvas.GetComponentInChildren<Text>();
            }
        }
#endif

        public void Enter(Ship ship)
        {
            if (ship.GetColor() == color)
            {
                this.LogMessage("Ship entered dock");
                dockedShips.Enqueue(ship);
                ship.isInStation = true;
            }
            else
            {
                this.LogMessage("Ship reached wrong dock");
                // Verwijder huidig schip
                // Decrease score
            }
        }

        public void Click()
        {
            if (Global.CurrentSelectedShip != null)
            {
                if (Global.CurrentSelectedShip.isInStation)
                {
                    Global.CurrentSelectedShip.Deselect();
                    return;
                }
                this.LogMessage("Set ship destination");
                Global.CurrentSelectedShip.SetDestination(this);
            }
            else
            {
                if (undockedShip != null)
                {
                    undockedShip.Undock();
                    undockedShip.isInStation = false;

                    this.LogMessage("Undock ship");
                }
                else
                {
                    this.LogMessage("No ship to undock");
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            float? timeLeft = null;
            if (dockedShips.Count > 0)
            {
                timeLeft = (dockedShips.Peek().TimeOfArrival + Global.TimeToUnloadShip) - Global.GameTime;
                if (timeLeft <= 0)
                {
                    this.LogMessage("Ship ready to undock");
                    if (undockedShip != null)
                    {
                        this.LogMessage("Already exists another undocked ship");
                        // Verwijder current undocked ship
                        // Decrease score
                    }

                    undockedShip = dockedShips.Dequeue();
                }
            }

            // Turn canvas towards camera
            if (canvas && Camera.main)
            {
                var lookatPoint = 2 * canvas.transform.position - Camera.main.transform.position;
                lookatPoint.y = canvas.transform.position.y;

                canvas.transform.LookAt(lookatPoint);
            }

            if (timerText)
            {
                timerText.text = (timeLeft.HasValue ? timeLeft.ToString() : "∞");
            }
        }
    }
}
