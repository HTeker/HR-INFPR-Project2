using System;
using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private ShipType type;
        [SerializeField]
        private GameObject containers;

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
            if (Global.CurrentSelectedShip && Global.CurrentSelectedShip != this)
                Global.CurrentSelectedShip.Deselect();

            if (!isLoaded)
                return;

            if (transform.position.x > Global.LineOfNoReturn)
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
            containers.SetActive(false);
        }

        public void Undock()
        {
            isUndocked = true;
            // TODO increase score
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

                    if (transform.position.x > Global.LineOfNoReturn)
                        if (Global.CurrentSelectedShip == this)
                            Deselect();

                    if (Vector3.Distance(transform.position, destination.DockPosition.transform.position) < Global.ShipSpeedWithDestionation * Time.deltaTime)
                        destination.Enter(this);
                }
                else
                {
                    if (transform.position.x > Global.LineOfNoReturn)
                    {
                        this.LogMessage("Ship has no destionation given in time");
                        Destroy(gameObject);
                        // TODO decrease score
                    }
                    transform.position += Global.ShipSpeed * Time.deltaTime * transform.forward;
                }
            }
            else
            {
                if (isUndocked)
                {
                    if (transform.position.x < Global.LineOfOpenSea)
                    {
                        Destroy(gameObject);
                    }

                    transform.position += Global.ShipSpeedWithDestionation * Time.deltaTime * transform.forward;
                }
            }
        }
    }
}