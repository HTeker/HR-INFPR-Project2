using UnityEngine;
using System.Collections;

public class Hook : MonoBehaviour {

    public float moveSpeed = 25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(0f, 0f, moveSpeed * horizontal * Time.deltaTime);
    }
}
