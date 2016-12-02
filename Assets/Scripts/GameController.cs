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
        private float lineOfNoReturn;
        [SerializeField]
        private float lineOfOpenSea;

        private void Start()
        {
            Global.TimeToUnloadShip = timeToUnloadShip;
            Global.ShipSpeed = shipSpeed;
            Global.ShipSpeedWithDestionation = shipSpeedWithDestination;
            Global.LineOfNoReturn = lineOfNoReturn;
            Global.LineOfOpenSea = lineOfOpenSea;
        }

        private void Update()
        {
            Global.GameTime += Time.deltaTime;
        }
    }
}
