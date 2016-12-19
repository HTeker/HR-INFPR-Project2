using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Scripts.Epic2
{
    public class Ship : MonoBehaviour
    {
        // level:x:y
        public List<List<List<Transform>>> containers;

        // Use this for initialization
        void Start()
        {
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

            CalculateBalance();
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
                rot.z = balanceRight - balanceLeft;
                transform.localEulerAngles = rot;
            }
        }
    }
}