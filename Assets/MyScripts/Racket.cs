using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {

    public float Accel;
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(transform.right * 
            Input.GetAxisRaw("Horizontal") * Accel, ForceMode.Impulse);
	}
}
