using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SonicScript : MonoBehaviour
{
    private Rigidbody2D sonicRigidbody;
    public int speedCoeff = 10;

    private void Awake()
    {
        sonicRigidbody = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        sonicRigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * speedCoeff, sonicRigidbody.velocity.y);

        if (Input.GetKey(KeyCode.Space))
        {
            sonicRigidbody.velocity = new Vector2(sonicRigidbody.velocity.x, speedCoeff);
        }
    }
}
