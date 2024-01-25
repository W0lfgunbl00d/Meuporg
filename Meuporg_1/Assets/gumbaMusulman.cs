using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gumbaMusulman : MonoBehaviour
{
    public GameObject piou;
    public GameObject lfo9;
    private Rigidbody2D gumbaRigidbody;
    public int dir = 1;
    public int speed = 4;
    public GameObject player;
    private bool mvt = true;
    private bool cooldown = false;
    private GameObject go;
    private float t = 0;
    private Vector3 force;

    // Start is called before the first frame update
    void Start()
    {

        gumbaRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(piou.transform.position, dir*Vector2.right, 1);
        RaycastHit2D check = Physics2D.Raycast(piou.transform.position, dir * Vector2.right, 3);
        RaycastHit2D fo9 = Physics2D.Raycast(lfo9.transform.position, Vector2.up, 1);

        Debug.DrawRay(piou.transform.position, Vector3.right, Color.red, 0);

        // If it hits something...
        if (check.collider != null && check.collider.CompareTag("Player"))
        {
            speed = 10;
        }

        if (hit.collider != null && !check.collider.CompareTag("Player"))
        {

            dir *= -1;
     
        }
        if (fo9.collider != null && fo9.collider.tag == "Player")
        {
            Vector2 direction = - gameObject.transform.position + fo9.collider.gameObject.transform.position;
            fo9.collider.GetComponent<Rigidbody2D>().velocity = direction*10;
            Destroy(gameObject);
        }

        transform.localScale = new Vector3(dir, 1, 1);
        if (mvt == true)
        {
            gumbaRigidbody.velocity = new Vector2(dir * speed, gumbaRigidbody.velocity.y);
        }
        if (cooldown == true)
        {

            t += Time.fixedDeltaTime;

        }

        if (t > 2)
        {
            t = 0;
            cooldown = false;
            mvt = true;
            speed = 4;
        }
        



        

        

    }
 


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //force = gameObject.transform.position - collision.gameObject.transform.position;
            gumbaRigidbody.AddForce(new Vector2(-dir * 10, 15), ForceMode2D.Impulse);
            cooldown = true;
            mvt = false;
        }
        
    }




}
