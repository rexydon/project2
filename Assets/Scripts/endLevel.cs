using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel : MonoBehaviour {
    public GameObject playerCamera;
    public GameObject canvas;
    public float distanceFromPlayer = 5f;
    public string nextLevel = "";
    public AudioSource levelEnd;
    // Use this for initialization
    void Start () {
        Vector3 moveDirection = transform.forward;
        playerCamera.transform.position += moveDirection * distanceFromPlayer;
        playerCamera.transform.Rotate(Vector3.up, 180);
        canvas.GetComponent<Canvas>().enabled = false;
        levelEnd.Play();
        Invoke("NextLevel", 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NextLevel()
    {
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
    }
}
