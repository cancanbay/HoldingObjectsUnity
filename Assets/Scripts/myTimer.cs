using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class myTimer : MonoBehaviour {

    [SerializeField]
    private float timer1 = 10;
    private Text textTimer;
    private float timer2 = 2;

	// Use this for initialization
	void Start () {
        textTimer = GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {
       
            
        if (!timer1.ToString("f0").Equals("0"))
        {
            timer1 -= Time.deltaTime;
            textTimer.text = "Kalan Süre: " + timer1.ToString("f0");
        }
        else
        {

            textTimer.text = "Zaman doldu.";

            if (!timer2.ToString("f0").Equals("0"))
            {
                // 0 olmadı
                timer2 -= Time.deltaTime;
            }
            else
                SceneManager.LoadScene("scene2");

        }     
	
	}
}
