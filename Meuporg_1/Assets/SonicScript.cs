using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SonicScript : MonoBehaviour
{
    private Rigidbody2D sonicRigidbody;
    private Animator anime;
    public int speedCoeff = 10;
    public int scale = 5;

    private void Awake()
    {
        sonicRigidbody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");


        // sonic direction
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one * scale;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1 * scale, scale, scale);

        // sonic movement
        sonicRigidbody.velocity = new Vector2(horizontalInput * speedCoeff, sonicRigidbody.velocity.y);
        anime.SetBool("run", horizontalInput != 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "ground")
            sonicRigidbody.velocity = new Vector2(sonicRigidbody.velocity.x, speedCoeff);
    }

}