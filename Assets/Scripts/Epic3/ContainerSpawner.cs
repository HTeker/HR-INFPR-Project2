﻿using UnityEngine;
using System.Collections;

namespace Scripts.Epic3
{
    public class ContainerSpawner : MonoBehaviour
    {

        public GameObject redContainer, greenContainer, blueContainer;
        public Transform spawnPosition;
		public float currentContainerSpeed = 7.5f;
		public float containerSpeedModifier = 0.2f; 

        private float delaySpawn = 3;
        private float lastSpawnTime;
        private float lastMultiplierTime;
        private float delayMultiplier = 5;


        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > lastSpawnTime)
            {
                lastSpawnTime = (float)Time.time + delaySpawn;
                //Instantiate
                RandomSpawn();
            }
            if (Time.time > lastMultiplierTime)
            {
                lastMultiplierTime = (float)Time.time + delayMultiplier;
                if (delaySpawn > 1)
                {
                    delaySpawn -= 0.1f;

                }
				currentContainerSpeed += containerSpeedModifier;
            }
        }

        private void RandomSpawn()
        {
			GameObject container = (GameObject)Instantiate(SelectRandomContainer(), spawnPosition.position, spawnPosition.rotation);
			container.GetComponent<ContainerBehaviour> ().speed = currentContainerSpeed;
        }

        private GameObject SelectRandomContainer()
        {
            int rand = Random.Range(1, 4);
            switch (rand)
            {
                default:
                    return greenContainer;
                case 2:
                    return redContainer;
                case 3:
                    return blueContainer;
            }
        }
    }
}