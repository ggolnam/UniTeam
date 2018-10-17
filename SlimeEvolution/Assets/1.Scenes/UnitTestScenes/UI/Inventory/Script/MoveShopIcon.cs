using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShopIcon : MonoBehaviour {

    public int speed;

    private void Update()
    {
        if (transform.position.y >= 60)
        {
            transform.Translate(0, Time.deltaTime * speed, 0);
        }
        //else if()
    }
}
