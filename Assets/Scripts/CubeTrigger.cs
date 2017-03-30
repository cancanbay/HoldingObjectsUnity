using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class CubeTrigger : MonoBehaviour {

    public Text helpText;
    public PickupObjects newpickup;
    bool inPlace = false;
    // Use this for initialization
    void Start () {
        newpickup = new PickupObjects();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag.ToString() == "Player")
        {
            Debug.Log("Trigger with cube");
            helpText.text = "Objeyi kaldırmak veya bırakmak için 'F' tuşuna basınız";
        }

        if(col.gameObject.tag.ToString() == "Lever")
        {
            Debug.Log("Trigger with lever");
        }
       
        if (col.gameObject.tag.ToString() == "LeverTrigger")
        {
            
            GameObject küp = GameObject.FindGameObjectWithTag("Küp");
            if (küp.GetComponent<Rigidbody>().isKinematic == false)
            {
                if (!inPlace)
                {
                    küp.transform.position = new Vector3(col.gameObject.transform.position.x, küp.transform.position.y, col.gameObject.transform.position.z);
                    inPlace = true;
                }
            }
           
           
        }

    }
    

   

    void OnTriggerExit(Collider col)
    {
        Debug.Log("Exit");
        helpText.text = "";
        inPlace = false;
    }

}
