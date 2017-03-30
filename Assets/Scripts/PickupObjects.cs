using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PickupObjects : MonoBehaviour {
    GameObject mainCamera;
    bool carrying;
    public GameObject carriedObject;
    public float distance;
    public float smooth;
    public Text helpText;

	// Use this for initialization
	void Start () {
          mainCamera = GameObject.FindWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update () { 
       // carrying true ise objeyi taşıyıp, f tuşuna basılmış mı diye kontrol et
        if (carrying)
         {
            carry(carriedObject);
            checkDrop();
         }
        // basılmamışsa ise taşınmıyor olduğu için yerden kaldır
        else
         {
            pickup();
         }
	}
    void carry(GameObject o)
    {
        o.transform.position =Vector3.Lerp(o.transform.position,mainCamera.transform.position + mainCamera.transform.forward * distance,Time.deltaTime*smooth);
    }
    // f tuşuna basılınca taşıyor
    void pickup() {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p != null)
                {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    void checkDrop() {
       // f tuşuna basıldığında taşınan obje terrain'den aşağıda bırakılırsa terrain'in altına düşmemesi için y-ekseninde kuvvet uygula
        if (Input.GetKeyDown(KeyCode.F)) {
           if (carriedObject.transform.position.y < 0)
            {
                Vector3 temp = new Vector3(0, 1.5f, 0);
                carriedObject.transform.position += temp;
            }
            dropObject();
        }
    }   
    void dropObject()  { 
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().useGravity = true;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}
