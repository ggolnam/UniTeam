using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour {
    
    [Header ("Text")]
    [SerializeField]
    Text loadingText;
    [SerializeField]
    Text snoringText;
  
    [Header("Transform")]
    [SerializeField]
    Vector2[] positionList;
    
    WaitForSeconds waitForSeconds = new WaitForSeconds(0.6f);
    // Use this for initialization
    void Start ()
    {
        StartCoroutine(Display());

	}

    IEnumerator Display()
    {
        int wordIndex = loadingText.text.IndexOf('.');
        for (int i = 0; ; i ++)
        {
            if (i > 3)
                i = 0;
            if (loadingText.text.Split('.').Length -1 < 3)
            {
                loadingText.text += '.';
                Debug.Log("te");
            }
            else
            {
                loadingText.text = loadingText.text.Substring(0, wordIndex);
                Debug.Log("test");
            }

            snoringText.transform.position = positionList[i];
            yield return waitForSeconds;
        }
    }
}
