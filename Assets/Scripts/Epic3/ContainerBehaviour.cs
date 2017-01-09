using UnityEngine;
using System.Collections;

namespace Scripts.Epic3
{
    public class ContainerBehaviour : MonoBehaviour
    {

        public bool badcontainer;
		public float speed;

        // Use this for initialization
        void Start()
        {
			
        }

        // Update is called once per frame
        void Update()
        {
			if (transform.position.z >= 100) 
			{
				badcontainer = true;

				Destroy (gameObject);
			}
			transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        void OnMouseDown()
        {
            //points

            Destroy(this.gameObject);
        }
    }
}