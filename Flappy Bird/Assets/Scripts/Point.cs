using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

    
	void OnTriggerExit2D(Collider2D others){
    
            if (others.tag =="Player")
            {
                
                PlayerController pc = others.gameObject.GetComponent<PlayerController>();
                pc.IncrementScore();
                
            
            }

    
	}
}
