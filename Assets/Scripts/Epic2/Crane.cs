using UnityEngine;
using System.Collections;

public class Crane : MonoBehaviour {

    public GameObject hook;
    public float moveSpeed = 25f;

    // Update is called once per frame
    void Update () {
        if(transform.position.z <= 115 && transform.position.z >= 0)
        {
            float vertical = Input.GetAxis("Vertical");
            transform.Translate(moveSpeed * -vertical * Time.deltaTime, 0f, 0f);
        }
        else
        {
            if(transform.position.z > 115)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 115);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
            
        }
        
	}
    
}
