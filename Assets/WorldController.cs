using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject levelPrefab;
    public Grid theGrid;
    public Camera cam;
    public float cameraSpeed = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        // cam = gameObject.GetComponent<Camera>();


        GameObject newLevel = Instantiate(levelPrefab, new Vector3 (0,-15,0), Quaternion.identity);
        // newLevel.transform.parent = GameObject.Find("Stage Scroll").transform;
        newLevel.transform.parent = theGrid.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - cameraSpeed, cam.transform.position.z);
        Debug.Log(cam.transform.position);
    }
}
