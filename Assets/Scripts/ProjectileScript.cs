using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public float forcePower = 100f;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    private void OnCollisionEnter2D(Collision2D other) {


        Debug.Log("collision");



        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        Vector2 force = (gameObject.transform.position - other.transform.position).normalized * forcePower;
        Vector2 position = other.transform.position;
        rb.AddForceAtPosition(force, position);
    }
}
