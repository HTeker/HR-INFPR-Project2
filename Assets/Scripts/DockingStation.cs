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
        private Material materialNormal;

        [SerializeField]
        private Material materialHighlight;

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
                dockedShips.Enqueue(ship);
                ship.TimeOfArrival = Global.GameTime;
                ship.gameObject.SetActive(false);
                Global.pointController.IncreaseScore();
            }
            else
            {
                this.LogMessage("Ship reached wrong dock");
                Destroy(ship.gameObject);
                Global.scoreController.AmountOfFailures++;
                Global.pointController.DecreaseScore();
            }
        }

        public void Click()
        {
            if (Global.CurrentSelectedShip != null)
            {
                Global.CurrentSelectedShip.SetDestination(this);
                Global.CurrentSelectedShip.Deselect();
            }
            else
            {
                UndockCurrentShip();
            }
        }

        public void OnMouseEnter()
        {
            ChangeRenderers(materialHighlight);
        }

        public void OnMouseExit()
        {
            ChangeRenderers(materialNormal);
        }

        private void ChangeRenderers(Material mat)
        {
            foreach (var renderer in GetComponentsInChildren<Renderer>())
                renderer.material = mat;
        }

        public void UndockCurrentShip()
        {
            if (undockedShip != null)
            {
                undockedShip.Undock();
                undockedShip = null;
            }
        }

        void Update()
        {
            if (Global.GameOver)
                return;

            float? timeLeft = null;
            if (dockedShips.Count > 0)
            {
                timeLeft = (dockedShips.Peek().TimeOfArrival + Global.TimeToUnloadShip) - Global.GameTime;
                if (timeLeft <= 0)
                {
                    if (undockedShip != null)
                    {
                        Destroy(undockedShip.gameObject);
                        Global.pointController.DecreaseScore();
                    }

                    undockedShip = dockedShips.Dequeue();

                    undockedShip.gameObject.SetActive(true);
                    undockedShip.transform.position = undockPosition.transform.position;
                    undockedShip.transform.rotation = UndockPosition.transform.rotation;
                    undockedShip.ReadyToUndock();
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
                timerText.text = (timeLeft.HasValue ? timeLeft.Value.ToString("n2") : "∞");
            }
            else
            {
                this.LogMessage("Timer text not available", LogType.Error);
            } 
        }
    }
}
