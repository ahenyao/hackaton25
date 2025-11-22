using UnityEngine;
using System;

public class ruchKamery : MonoBehaviour
{
	public GameObject bohater;
	public GameObject bohater1;
	public GameObject bohater2;
	private bool aktywna=true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    void Update()
    {
        // Swap target on Tab
        if (Input.GetKeyDown(KeyCode.Tab)) {
			aktywna=!aktywna;
            if(aktywna) {
				bohater=bohater1;
			} else {
				bohater=bohater2;
			}
			
        }

		// Update is called once per frame
		float x = bohater.transform.position.x;
		x = Math.Min(Math.Max(x, 1.25f), 23.7f);
        Vector3 nowaPozycjaKamery = new Vector3(x,
   			 (aktywna?-0.4f:4.6f),
  			 transform.position.z);
   
		transform.position = nowaPozycjaKamery;
		
    }
}
