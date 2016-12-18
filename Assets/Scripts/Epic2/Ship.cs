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
        }

        internal static void GetTarget(Vector3 postion, Vector2 direction, bool attetched)
        {
            throw new NotImplementedException();
        }
    }
}