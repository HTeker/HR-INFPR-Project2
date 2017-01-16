using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Scripts.Epic1
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
        [Header("Materials")]
        [SerializeField]
        private Material materialNormal;
        [SerializeField]
        private Material materialHighlight;
        [SerializeField]
        private AudioSource selectSound;

        private void Start()
        {
            Global.TimeToUnloadShip = timeToUnloadShip;
            Global.ShipSpeed = shipSpeed;
            Global.ShipSpeedWithDestionation = shipSpeedWithDestination;
            Global.LineOfNoReturn = lineOfNoReturn;
            Global.LineOfOpenSea = lineOfOpenSea;

            Global.MaterialNormal = materialNormal;
            Global.MaterialHighlight = materialHighlight;

            Global.selectSound = selectSound;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            Start();
        }
#endif

        private void Update()
        {
            Global.GameTime += Time.deltaTime;
        }
    }
}
