using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Scripts
{
    public class GameController : MonoBehaviour
    {
        [Header("Globals")]
        [SerializeField]
        private float timeToUnloadShip;
        [SerializeField]
        private float shipSpeed;
        [SerializeField]
        private float shipSpeedWithDestination;
        [SerializeField]
        private float minimalDistanceToChangeShipDestination;

        private void Start()
        {
            Global.TimeToUnloadShip = timeToUnloadShip;
            Global.ShipSpeed = shipSpeed;
            Global.ShipSpeedWithDestionation = shipSpeedWithDestination;
            Global.MinimalDistanceToChangeShipDestination = minimalDistanceToChangeShipDestination;
        }

        private void Update()
        {
            Global.GameTime += Time.deltaTime;
        }
    }
}
