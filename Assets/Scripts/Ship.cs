using System;
using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private ShipType type;
        private bool isLoaded = true;
        private DockingStation destination;
        private bool isUndocked;

        public float TimeOfArrival { get; set; }

        public void SetDestination(DockingStation target)
        {
            destination = target;
        }

        public ShipType GetShipType()
        {
            return type;
        }

        public void Click()
        {
            Debug.Log("Ship clicked");

            if (Global.CurrentSelectedShip && Global.CurrentSelectedShip != this)
                Global.CurrentSelectedShip.Deselect();

            if (!isLoaded)
                return;

            if (destination && Vector3.Distance(transform.position, destination.DockPosition.transform.position) < Global.MinimalDistanceToChangeShipDestination)
                return;

            if (!destination && /* To close to wall */ false)
                return;

            if (Global.CurrentSelectedShip != this)
                Select();
        }

        public void Deselect()
        {
            Global.CurrentSelectedShip = null;
        }

        public void Select()
        {
            if (Global.CurrentSelectedShip)
                Global.CurrentSelectedShip.Deselect();

            Global.CurrentSelectedShip = this;
        }

        public void ReadyToUndock()
        {
            isLoaded = false;
            // Remove containers from ship
        }

        public void Undock()
        {
            isUndocked = true;
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isLoaded)
            {
                if (destination)
                {
                    transform.LookAt(destination.DockPosition.transform.position);
                    transform.position += Global.ShipSpeedWithDestionation * Time.deltaTime * transform.forward;

                    if (Vector3.Distance(transform.position, destination.DockPosition.transform.position) < Global.MinimalDistanceToChangeShipDestination)
                        if (Global.CurrentSelectedShip == this)
                            Deselect();

                    if (Vector3.Distance(transform.position, destination.DockPosition.transform.position) < Global.ShipSpeedWithDestionation * Time.deltaTime)
                        destination.Enter(this);
                }
                else
                {
                    transform.position += Global.ShipSpeed * Time.deltaTime * transform.forward;
                }
            }
            else
            {
                if (isUndocked)
                {
                    transform.position += Global.ShipSpeedWithDestionation * Time.deltaTime * transform.forward;

                    if (/* ouside view*/ false)
                    {
                        // Remove
                    }
                }
            }
        }
    }
}