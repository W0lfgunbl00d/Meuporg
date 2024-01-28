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
    public int jump = 1;
    private float t = 0;
    private bool mvt = true;
    private bool cooldown = false;
    public float helt = 100;

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

        if (cooldown == true)
        {

            t += Time.fixedDeltaTime;

        }

        if (t > 2)
        {
            t = 0;
            cooldown = false;
            mvt = true;

        }

        // sonic movement
        if (mvt == true)
        {
            sonicRigidbody.velocity = new Vector2(horizontalInput * speedCoeff, sonicRigidbody.velocity.y);
            anime.SetBool("run", horizontalInput != 0);
        }
        
        if (helt < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey(KeyCode.Space) && collision.gameObject.tag == "ground") { 
            sonicRigidbody.velocity = new Vector2(sonicRigidbody.velocity.x, jump);
            anime.SetBool("airborn", true); 
        }
        else {
            anime.SetBool("airborn", false); 
        }
        if (collision.gameObject.tag == "degat")
        {
            mvt = false;
            //force = gameObject.transform.position - collision.gameObject.transform.position;
            sonicRigidbody.AddForce(new Vector2(-10, 10), ForceMode2D.Impulse);
            cooldown = true;
            
        }
    }

}