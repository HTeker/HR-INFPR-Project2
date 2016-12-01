using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

// Deze class zorgt ervoor dat schepen in willekeurige kleuren en posities worden gecreeërd in het speelveld 
public class SpawnController : MonoBehaviour
{
    private Dictionary<Colors, int> colorOccurrences = new Dictionary<Colors, int>();

    public Vector3 spawnValues;
    public float spawnWait;
    public float startWait;
    public uint diffShips;

    private enum Colors
    {
        Red,
        Green,
        Blue
    };

    // Ingebouwde Unity functie die eenmalig wordt aangeroepen bij de eerste frame van een scène
    private void Start()
    {
        diffShips = diffShips - 1;

        colorOccurrences.Add(Colors.Red, 0);
        colorOccurrences.Add(Colors.Green, 0);
        colorOccurrences.Add(Colors.Blue, 0);

        InvokeRepeating("UpdatePerFiveSeconds", 2.0f, 5f);
        StartCoroutine(SpawnWaves());
    }

    // Om de vijf seconden wordt de productiesnelheid van de schepen met 0,1 seconde verhoogt met een minimumsnelheid van 0,3 seconde
    private void UpdatePerFiveSeconds()
    {
        if(spawnWait > 0.3f)
        {
            spawnWait -= 0.1f;
        }
    }

    // Produceert de schepen op het speelveld en houdt rekening met de differentie in aantal tussen de schepen
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        // TODO: Deze conditie dient te zijn: zolang het spel doorgaat.
        while (true)
        {
            var color = chooseColor();
            var rightColor = false;

            while (!rightColor)
            {
                var currentCount = 0;
                switch (color)
                {
                    case "Red":
                        if (colorOccurrences[Colors.Red] - colorOccurrences[Colors.Green] < diffShips &&
                            colorOccurrences[Colors.Red] - colorOccurrences[Colors.Blue] < diffShips)
                        {
                            colorOccurrences.TryGetValue(Colors.Red, out currentCount);
                            colorOccurrences[Colors.Red] = currentCount + 1;
                            rightColor = true;
                        }
                        break;
                    case "Green":
                        if (colorOccurrences[Colors.Green] - colorOccurrences[Colors.Red] < diffShips &&
                            colorOccurrences[Colors.Green] - colorOccurrences[Colors.Blue] < diffShips)
                        {
                            colorOccurrences.TryGetValue(Colors.Green, out currentCount);
                            colorOccurrences[Colors.Green] = currentCount + 1;
                            rightColor = true;
                        }
                        break;
                    case "Blue":
                        if (colorOccurrences[Colors.Blue] - colorOccurrences[Colors.Red] < diffShips &&
                            colorOccurrences[Colors.Blue] - colorOccurrences[Colors.Green] < diffShips)
                        {
                            colorOccurrences.TryGetValue(Colors.Blue, out currentCount);
                            colorOccurrences[Colors.Blue] = currentCount + 1;
                            rightColor = true;
                        }
                        break;
                }

                if (!rightColor)
                {
                    color = chooseColor();
                }
            }

            // TODO: Momenteel wordt de prefab Box ingeladen omdat Ship nog niet klaar is, dit dient veranderd te worden
            GameObject ship = Resources.Load(color + "Box") as GameObject;
            Vector3 spawnPosition = new Vector3(spawnValues.x, spawnValues.y, Random.Range(-7, -390));
            Quaternion spawnRotation = Quaternion.Euler(0, -90, 0);
            Instantiate(ship, spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    // Geeft een willekeurige kleur uit de Colors enum
    private string chooseColor()
    {
        Array colors = Enum.GetValues(typeof(Colors));
        Colors randomColor = (Colors)colors.GetValue(Random.Range(0, colors.Length));
        return randomColor.ToString();
    }
}
