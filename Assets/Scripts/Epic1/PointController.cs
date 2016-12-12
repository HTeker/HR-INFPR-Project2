using Scripts;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Epic1
{
    public class PointController : MonoBehaviour
    {

        public Text pointText;
        public Text endPointText;
        private int score = 0;
        public int incBy = 10;
        public int decBy = 15;

        // Use this for initialization
        void Start()
        {
            Global.pointController = this;
            UpdateScore();
        }

        public void IncreaseScore()
        {
            score += incBy;
            UpdateScore();
        }

        public void DecreaseScore()
        {
            score -= decBy;
            UpdateScore();
        }

        private void UpdateScore()
        {
            pointText.text = "Score: " + score;
            endPointText.text = "Score: " + score;
        }
    }
}