using System;
using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class Ship : MonoBehaviour
    {
        private bool isLoaded = true;
        private DockingStation destination = null;
        public bool isInStation = false;
        private ShipType type;

        public float TimeOfArrival { get; set; }

        public void SetDestination(DockingStation target)
        {
            destination = target;
        }

        public ShipType GetColor()
        {
            return type;
        }

        public void Click()
        {
            Debug.Log("Ship clicked");
            if (destination != null)
                if (isLoaded && Vector3.Distance(destination.DockPosition.transform.position, this.transform.position) > 10.0f)
                    if (Global.CurrentSelectedShip != null)
                        Global.CurrentSelectedShip.Deselect();

            if (Global.CurrentSelectedShip == this)
            {
                this.Deselect();
            }
            else
            {
                Global.CurrentSelectedShip = this;
            }
        }

        public void Deselect()
        {
            Global.CurrentSelectedShip = null;
        }

        public void Undock()
        {
            throw new NotImplementedException();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isInStation)
                return;

            if(destination == null && this.transform.position.x < 550.0f)
            {
                Vector3 shipPos = this.transform.position;
                shipPos.x = shipPos.x + Global.ShipSpeed * Time.deltaTime;
                this.transform.position = shipPos;
                Vector3 lookAtPos = shipPos;
                shipPos.x += 10;
                this.transform.LookAt(shipPos);
            }
            else if (isLoaded && Vector3.Distance(destination.DockPosition.transform.position, this.transform.position) > 10.0f)
            {
                Vector3 shipPos = this.transform.position;
                shipPos += this.transform.forward * Global.ShipSpeed * Time.deltaTime;
                this.transform.position = shipPos;
                this.transform.LookAt(destination.DockPosition.transform);
            }
            else if(isLoaded == false)
            {
                Vector3 shipPos = this.transform.position;
                shipPos.x = shipPos.x - Global.ShipSpeed * Time.deltaTime;
                this.transform.position = shipPos;
                Vector3 lookAtPos = shipPos;
                shipPos.x -= 10;
                this.transform.LookAt(shipPos);
            }
            else if(isLoaded && destination != null)
            {
                destination.Enter(this);
            }
        }
    }
}