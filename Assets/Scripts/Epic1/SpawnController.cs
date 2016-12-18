using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Random = UnityEngine.Random;

namespace Scripts.Epic1
{
    // Deze class zorgt ervoor dat schepen in willekeurige kleuren en posities worden gecreeërd in het speelveld 
    public class SpawnController : MonoBehaviour
    {
        private Dictionary<ShipType, int> colorOccurrences = new Dictionary<ShipType, int>()
        {
            { ShipType.Red, 0 },
            { ShipType.Green, 0 },
            { ShipType.Blue, 0 },
        };

        private Dictionary<ShipType, GameObject> shipPrefabs = new Dictionary<ShipType, GameObject>();

        public GameObject RedShip;
        public GameObject GreenShip;
        public GameObject BlueShip;

        public Vector3 spawnValues;
        public float spawnWait;
        public float startWait;

        // Ingebouwde Unity functie die eenmalig wordt aangeroepen bij de eerste frame van een scène
        private void Start()
        {
            shipPrefabs.Add(ShipType.Red, RedShip);
            shipPrefabs.Add(ShipType.Green, GreenShip);
            shipPrefabs.Add(ShipType.Blue, BlueShip);

            InvokeRepeating("UpdatePerFiveSeconds", 2.0f, 5f);
            StartCoroutine(SpawnWaves());
        }

        // Om de vijf seconden wordt de productiesnelheid van de schepen met 0,1 seconde verhoogt met een minimumsnelheid van 0,3 seconde
        private void UpdatePerFiveSeconds()
        {
            if (spawnWait > 3)
            {
                spawnWait -= 0.1f / 3;
            }
        }

        // Produceert de schepen op het speelveld en houdt rekening met de differentie in aantal tussen de schepen
        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            
            while (!Global.GameOver)
            {
                var type = chooseType();

                colorOccurrences[type] += 1;
                Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-7, -390));
                Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);
                Instantiate(shipPrefabs[type], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }
        }

        // Geeft een willekeurige type
        private ShipType chooseType()
        {
            var max = colorOccurrences.Max(v => v.Value) + 1;
            var oddDistribution = colorOccurrences.Select(v => max - v.Value).ToList();

            var val = Random.value * oddDistribution.Sum();

            for (var i = 0; i < oddDistribution.Count; ++ i)
            {
                val -= oddDistribution[i];
                if (val <= 0)
                    return (ShipType)i;
            }

            return (ShipType)oddDistribution.IndexOf(oddDistribution.Max());
        }
    }
}