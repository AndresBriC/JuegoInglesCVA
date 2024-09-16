using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float movHor = 1f; // Horizontal movement of the enemy.
    public float speed = 3f; // // speed with which the user can move.

    public bool isGroundFloor = true; // Know if the user is touching the ground or not.
    public bool isGroundFront = false; // Know if the user is touching the ground or not.

    public LayerMask groundLayer; // We will put a layer on the ground, to know when the user touches the ground.
    public float frontGrndRayDist = 0.25f; // Know if the user is really touching the ground.
    public float floorCheckY = 0.52f; // Configuration on the object that has the enemy script so that it is detected by the ground.
    public float frontCheck = 0.51f; // Configuration on the object that has the enemy script so that it is detected by the ground.
    public float frontDist = 0.001f; // Configuration on the object that has the enemy script so that it is detected by the ground.

    public int scoreGive = 50; // How much score will the enemy give us once it is eliminated.

    private Rigidbody2D rb; // To access the components of the object.
    private RaycastHit2D hit; // Unity's own instruction.

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Avoid falling off a cliff.
        isGroundFloor = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z),
            new Vector3(movHor, 0, 0), frontGrndRayDist, groundLayer)); 

        // What this line of code does is report if the enemy is touching the ground, if not, it changes direction (Lines 35-36-38-39).
        if (isGroundFloor)
            movHor = movHor * -1;

        // Collision with wall.
        if (Physics2D.Raycast(transform.position, new Vector3(movHor, 0, 0), frontCheck, groundLayer))
            movHor = movHor * -1;

        // Clash with another enemy.
        hit = Physics2D.Raycast(new Vector3(transform.position.x + movHor * frontCheck, transform.position.y, transform.position.z),
            new Vector3(movHor, 0, 0), frontDist);
        
        if (hit != null) // Unity's own instruction.
            if (hit.transform != null)
                if (hit.transform.CompareTag("Enemy"))
                    movHor = movHor * -1;
    }

    void FixedUpdate() // To be able to manage the movement of our enemies.
    {
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y); // Vector2 = It is a set of values {x} and {y}.   
    }

    private void GetKilled() // Function for when the enemy is eliminated.
    {
        gameObject.SetActive(false); // The object is deactivated.
    }
}
