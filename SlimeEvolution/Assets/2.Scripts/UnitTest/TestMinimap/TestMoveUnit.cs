using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveUnit : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public float MoveSpeed;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        MoveSpeed = 5.0f;
    }
    private void Update()
    {
        float h = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        float v = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;

        rigidbody.transform.Translate(new Vector3(h, 0, v));
    }

}
