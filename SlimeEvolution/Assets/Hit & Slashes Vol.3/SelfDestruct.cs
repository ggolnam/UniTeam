using UnityEngine;
using System.Collections;


public class SelfDestruct : MonoBehaviour {
	public float selfdestruct_in = 4; // Setting this to 0 means no selfdestruct.

	//void Start ()
 //   {
	//	if ( selfdestruct_in != 0){ 
	//		Destroy (gameObject, selfdestruct_in);
	//	}
	//}

    private void OnEnable()
    {
        if (selfdestruct_in != 0)
        {
            Invoke("SetActive", selfdestruct_in);
        }
    }

    private void SetActive()
    {
        gameObject.SetActive(false);
    }
}
