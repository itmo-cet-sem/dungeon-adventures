using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;

    private float inputH;
    private float inputV;
    private bool run;
    private bool jump;

    public float speed = 2.0f;
    public float rotationSpeed = 75.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        run = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if (translation !=0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
            speed = 4.0f;
        }
        else
        {
            run = false;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
            anim.SetBool("jump", jump);
        }
        else
        {
            jump = false;
            anim.SetBool("jump", jump);
        }
        
        anim.SetBool("run", run);
        anim.SetBool("jump", jump);
                          
    }
}
