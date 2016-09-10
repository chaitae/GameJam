using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    // Use this for initialization
    Rigidbody2D rb;
    public float speed = 10f;
    public float jump = 100f;
    public bool grounded = true;
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetAxis("Horizontal") > 0)
        {
            // transform.Translate(Vector3.right* speed*Time.deltaTime);
            rb.AddForce(Vector3.right * speed);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            //transform.Translate(Vector3.left * speed* Time.deltaTime);
            rb.AddForce(Vector3.left * speed);

        }


    }
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + -Vector3.up*.8f, -Vector2.up,.1f);
        Debug.DrawRay(transform.position + -Vector3.up*.8f, Vector2.down, Color.green);
        if (hit.collider != null)
        {
            if (hit.collider.name != "Character" && hit.collider.tag == "Platform")
            {
                grounded = true;
                //Debug.Log(hit.collider);
            }
        }

        if(grounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(Vector2.up*jump);
               // transform.Translate(Vector3.up * jump * Time.deltaTime);
                grounded = false;
            }
        }

        //if (hit.collider != null)
        //{
        //    Debug.Log("shit.");
        //}
    }
}
