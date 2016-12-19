using UnityEngine;
using System.Collections;

namespace Scripts.Epic3
{
    public class ContainerBehaviour : MonoBehaviour
    {

        public bool badcontainer;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 7.5f);
        }

        void OnMouseDown()
        {
            //points

            Destroy(this.gameObject);
        }
    }
}