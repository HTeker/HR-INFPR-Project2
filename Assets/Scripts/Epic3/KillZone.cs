using UnityEngine;
using System.Collections;

namespace Scripts.Epic3
{
    public class KillZone : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update() 
        {
			

        }

        void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Container")
            {
                ContainerBehaviour containerBehaviour = col.GetComponent<ContainerBehaviour>();
                if (containerBehaviour.badcontainer)


                {
                    //It's BAD!
                    //Kill points..
                }
                Destroy(col.gameObject);
            }
        }
    }
}