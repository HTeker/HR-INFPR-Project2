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
        private ShipType type;

        [SerializeField]
        private GameObject dockPosition;
        public GameObject DockPosition { get { return dockPosition; } }

        [SerializeField]
        private GameObject undockPosition;
        public GameObject UndockPosition { get { return undockPosition; } }

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
                if (!timerText)
                {
                    this.LogMessage("Timer text not found", LogType.Error);
                }
            } 
            else
            {
                this.LogMessage("Canvas not found", LogType.Error);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Start();
        }
#endif

        public void Enter(Ship ship)
        {
            if (ship.GetShipType() == type)
            {
                this.LogMessage("Ship entered dock");
                dockedShips.Enqueue(ship);
                ship.enabled = false;
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
                this.LogMessage("Set ship desionation");
                Global.CurrentSelectedShip.SetDestionation(this);
            }
            else
            {
                if (undockedShip != null)
                {
                    undockedShip.Undock();
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

                    undockedShip.enabled = true;
                    undockedShip.transform.position = undockPosition.transform.position;
                    undockedShip.transform.rotation = UndockPosition.transform.rotation;
                }
            }

            // Turn canvas towards camera
            if (canvas && Camera.main)
            {
                var lookatPoint = 2 * canvas.transform.position - Camera.main.transform.position;
                lookatPoint.y = canvas.transform.position.y;

                canvas.transform.LookAt(lookatPoint);
            }
            else
            {
                this.LogMessage("Canvas not available", LogType.Error);
            }

            if (timerText)
            {
                timerText.text = (timeLeft.HasValue ? timeLeft.ToString() : "∞");
            }
            else
            {
                this.LogMessage("Timer text not available", LogType.Error);
            } 
        }
    }
}
