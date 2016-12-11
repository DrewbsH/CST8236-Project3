using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

    public int movementSpeed;
    public float time = 1.0f;
    public Camera[] cameras;
    private float camSpeed = 0.05f;
    private int currentCamIndex;

    // Use this for initialization
    void Start () {
        currentCamIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (time <= 0)
            time = 0.1f;
        if (Input.GetKey(KeyCode.R))
        {
            time += 0.1f;
        }
            
        else if (Input.GetKey(KeyCode.T))
        {
            time -= 0.1f;
            if (time < 0)
                time = 0.1f;
        }
           
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime * time);
            transform.Rotate(0, 5, 0);
        }
        //Rotate Left
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Vector3.back * movementSpeed * Time.deltaTime * time);
            transform.Rotate(0, -5, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            
            if(cameras[currentCamIndex].gameObject.name == "Third Person Camera")
            {
                camSpeed = 10.0f;
            }
            else
            {
                camSpeed = 0.1f;
            }
            
            Vector3 cam = cameras[currentCamIndex].gameObject.transform.localPosition;
            cameras[currentCamIndex].gameObject.transform.localPosition = new Vector3(cam.x, cam.y, cam.z + camSpeed);
        }
        if (Input.GetKey(KeyCode.E))
        {

            if (cameras[currentCamIndex].gameObject.name == "Third Person Camera")
            {
                camSpeed = 10.0f;
            }
            else
            {
                camSpeed = 0.1f;
            }

            Vector3 cam = cameras[currentCamIndex].gameObject.transform.localPosition;
            cameras[currentCamIndex].gameObject.transform.localPosition = new Vector3(cam.x, cam.y, cam.z - camSpeed);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            currentCamIndex++;
            
            if (currentCamIndex < cameras.Length)
            {
                cameras[currentCamIndex - 1].gameObject.SetActive(false);
                cameras[currentCamIndex].gameObject.SetActive(true);
                
            }
            else
            {
                cameras[currentCamIndex - 1].gameObject.SetActive(false);
                currentCamIndex = 0;
                cameras[currentCamIndex].gameObject.SetActive(true);
                
            }
        }

    }
}
