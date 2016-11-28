using System;
using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class Ship : MonoBehaviour
    {
        [SerializeField]
        private ShipType type;
        private bool isLoaded;
        private DockingStation destionation;

        public float TimeOfArrival { get; set; }

        public void SetDestionation(DockingStation target)
        {
            throw new NotImplementedException();
        }

        public ShipType GetShipType()
        {
            return type;
        }

        public void Click()
        {
            throw new NotImplementedException();
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

        }
    }
}