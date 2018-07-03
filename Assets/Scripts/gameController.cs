using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour {
    public int targets = 0;
    public GameObject exit;
    public GameObject player;
    private bool exitTriggered = false;
   

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        if (targets == 0 && exitTriggered == false)
        {
            Instantiate(exit, transform.position, Quaternion.identity);
            exitTriggered = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
