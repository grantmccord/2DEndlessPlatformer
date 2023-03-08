using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldController : MonoBehaviour
{
    public GameObject levelPrefab;
    public Grid theGrid;
    public Camera cam;
    public float cameraSpeed = 0.06f;

    public GameObject player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI youDiedText;
    private int score = 0;
    private bool dead = false;

    private float terrainGenerateOffsetFromCamera = -10f;
    private float cameraPositionToCreateNextTerrain = 0f;

    void Start()
    {
        // cam = gameObject.GetComponent<Camera>();


        // GameObject newLevel = Instantiate(levelPrefab, new Vector3 (0,-10,0), Quaternion.identity);
        // newLevel.transform.parent = theGrid.transform;
    }

    void Update() {


        // if camera moves down enough, then create new terrain 10 units down from camera
        if (cam.transform.position.y < cameraPositionToCreateNextTerrain) {

            float cameraY = cam.transform.position.y;

            GameObject newLevel = Instantiate(levelPrefab, new Vector3 (0, cameraY - 10,0), Quaternion.identity);
            // newLevel.transform.parent = GameObject.Find("Stage Scroll").transform;
            newLevel.transform.parent = theGrid.transform;

            Destroy(newLevel, 10);

            // update the next place where camera moved down enough
            cameraPositionToCreateNextTerrain -= 10f;
        }



        // if the player goes off the screen, then say you died
        // Debug.Log(player.transform.position.x);
        float cameraPlayerDifference = cam.transform.position.y - player.transform.position.y;
        Debug.Log(cameraPlayerDifference);
        if (-5 > cameraPlayerDifference || cameraPlayerDifference > 5) {
            dead = true;
            Debug.Log("Player died!");
            youDiedText.gameObject.SetActive(true);
        }

        // update score text
        scoreText.text = "score: " + score.ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Debug.Log(cam.transform.position);

        if (!dead) {
            score += 1;

            // move the camera
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - cameraSpeed, cam.transform.position.z);
        }
    }
}
