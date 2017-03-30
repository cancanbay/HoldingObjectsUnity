using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Shooter : MonoBehaviour {

    public GameObject bullet = null;
    public float bulletSpeed = 500f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButtonDown(0)){
            
            GameObject shot = (GameObject)GameObject.Instantiate(bullet, transform.position + Camera.main.transform.forward * 20, transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        }
	}
}
