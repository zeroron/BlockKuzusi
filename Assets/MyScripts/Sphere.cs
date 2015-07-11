using UnityEngine;
using System.Collections;

public class Sphere : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddForce((transform.forward+transform.right)*speed,ForceMode.VelocityChange);
	}
	
	
}
