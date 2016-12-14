using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Scripts.Epic1
{
    public class ScoreController : MonoBehaviour
    {

        private int MaxAmountOfFailures = 3;
        private int _AmountOfFailures;
        public int AmountOfFailures {
            get
            {
                return _AmountOfFailures;
            }
            set
            {
                _AmountOfFailures = value;
                ScreenText.text = preset + (MaxAmountOfFailures - AmountOfFailures);
                if(MaxAmountOfFailures - AmountOfFailures <= 0)
                {
                    EndGame();
                }

            }
        }

        public Text ScreenText;
        private string preset = "Remaining attempts ";

        public GameObject EndGameScreen;

        // Use this for initialization
        void Start()
        {
            Global.scoreController = this;
            ScreenText.text = preset + (MaxAmountOfFailures - AmountOfFailures);
            EndGameScreen.SetActive(false);
        }

        void EndGame()
        {
            Debug.Log("Ending Game");
            Global.GameOver = true;
            EndGameScreen.SetActive(true);
        }
    }
}
