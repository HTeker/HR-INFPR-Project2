using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Scripts
{
    public static class Global
    {
        public static float TimeToUnloadShip { get; set; }
        public static Ship CurrentSelectedShip { get; set; }
        public static float GameTime { get; set; }
        public static float ShipSpeed { get; set; }
        public static float ShipSpeedWithDestionation { get; set; }
        public static float LineOfNoReturn { get; set; }
        public static float LineOfOpenSea { get; set; }

        public static Material MaterialNormal { get; set; }
        public static Material MaterialHighlight { get; set; } 

        public static ScoreController scoreController { get; set; }
        public static PointController pointController { get; set; }
        public static bool GameOver { get; set; }
    }
}
