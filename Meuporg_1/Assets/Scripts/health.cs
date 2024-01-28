using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float helt = 100;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (helt < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "degat")
        {
            helt -= 20;
            Debug.Log(helt);
            Vector2 direction = gameObject.transform.position - collision.gameObject.transform.position;
            rb.velocity = direction;
        }



    }
}
