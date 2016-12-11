using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

    public float orbitSpeed;
    public float rotationHours;
    //public Vector3 axialTilt;
    private float time = 1.0f;
    


    void Update()
    {
        if (time <= 0)
            time = 0.1f;
        if (Input.GetKey(KeyCode.R))
            time += 0.1f;
        else if (Input.GetKey(KeyCode.T))
            time -= 0.1f;
        if (time < 0)
            time = 0.1f;
        // point around which we rotate (world coordinates)
        // axis is the vector we rotate around.
        transform.RotateAround(transform.parent.position, Vector3.up, orbitSpeed * Time.deltaTime * time);

        // Rotate around an axis; specify the tilt of the axis, and the amount to rotate/frame.
        transform.Rotate(new Vector3(10, 20, 5), rotationHours * Time.deltaTime * time);
        
        

        /*foreach(Transform child in transform.parent) {
          Debug.Log("Where my child's at? " + child);
        }*/
    }
}
