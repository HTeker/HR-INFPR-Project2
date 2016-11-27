using System;
using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class Ship : MonoBehaviour
    {
        private bool isLoaded;
        private DockingStation destionation;
        private ShipType type;

        public float TimeOfArrival { get; set; }

        public void SetDestionation(DockingStation target)
        {
            throw new NotImplementedException();
        }

        public ShipType GetColor()
        {
            throw new NotImplementedException();
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