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

        private void Start()
        {
            Global.TimeToUnloadShip = timeToUnloadShip;
            Global.ShipSpeed = shipSpeed;
        }

        private void Update()
        {
            Global.GameTime += Time.deltaTime;
        }
    }
}
