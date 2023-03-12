using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float timeBetween = 0.5f;

    public float speed = -5;

    private float nextShootTime;
    // Start is called before the first frame update
    void Start()
    {
        nextShootTime = Time.time + timeBetween;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextShootTime)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
            nextShootTime = Time.time + timeBetween;
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
        
        // GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);

    }

}
