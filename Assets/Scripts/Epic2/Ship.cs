using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Scripts.Epic2
{
    public class Ship : MonoBehaviour
    {
        public float Balance { get; set; }
        // level:x:y
        public List<List<List<Transform>>> containers;

        public GameObject ContainerRed;
        public GameObject ContainerGreen;
        public GameObject ContainerBlue;

        private Dictionary<ShipType, GameObject> containerPrefabs;
        public Dictionary<ShipType, int> containerCount;
        public float MaxBalance;

        // Use this for initialization
        void Start()
        {
            containerPrefabs = new Dictionary<ShipType, GameObject>()
            {
                { ShipType.Red, ContainerRed },
                { ShipType.Green, ContainerGreen },
                { ShipType.Blue, ContainerBlue }
            };

            containers = new List<List<List<Transform>>>();
            foreach(Transform level in transform)
            {
                var levelList = new List<List<Transform>>();
                foreach(Transform x in level)
                {
                    var xList = new List<Transform>();
                    foreach(Transform y in x)
                    {
                        xList.Add(y);
                    }
                    levelList.Add(xList);
                }
                containers.Add(levelList);
            }

            Generate();

            CalculateBalance();
        }

        private void Generate()
        {
            containerCount = new Dictionary<ShipType, int>()
            {
                { ShipType.Red, 0 },
                { ShipType.Green, 0 },
                { ShipType.Blue, 0 }
            };

            var placed = 0;
            while (placed < 30)
                for (int y = 0; y < containers[0][0].Count; y++) { 
                    var type = (ShipType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ShipType)).Length);
                    if (PlaceContainer(new Vector2(UnityEngine.Random.Range(0, containers[0].Count), y), type)) {
                        containerCount[type]++;
                        placed++;
                    }
                }
        }

        public bool IsShipEmpty()
        {
            return containerCount.Sum(x => x.Value) == 0;
        }

        public ShipType GetTargetType()
        {
            var left = containerCount.Where(x => x.Value > 0).Select(x => x.Key).ToArray();
            return left[UnityEngine.Random.Range(0, left.Length - 1)];
        }

        private bool PlaceContainer(Vector2 pos, ShipType type)
        {
            if (pos.x >= 0 && pos.x < containers[0].Count && pos.y >= 0 && pos.y < containers[0][0].Count)
            {
                for (var i = containers.Count - 1; i >= 0; -- i)
                {
                    if (containers[i][(int)pos.x][(int)pos.y].childCount == 0)
                    {
                        var container = GameObject.Instantiate(containerPrefabs[type]);
                        container.transform.SetParent(containers[i][(int)pos.x][(int)pos.y], false);
                        return true;
                    }
                }

                return false;
            }

            return false;
        }

        public void CalculateBalance()
        {
            var balanceLeft = 0;
            var balanceRight = 0;

            foreach (var layer in containers)
            {
                foreach(var column in layer)
                {
                    var middle = (column.Count - 1) / 2.0f;

                    for (var cell = 0; cell < column.Count; ++ cell)
                    {
                        if (cell < middle)
                        {
                            // Right
                            balanceRight += column[cell].childCount;
                        }
                        else if (cell > middle)
                        {
                            // Left
                            balanceLeft += column[cell].childCount;
                        }
                    }
                }

                var rot = transform.localEulerAngles;
                rot.z = Balance = balanceRight - balanceLeft;
                transform.localEulerAngles = rot;
            }
        }
    }
}