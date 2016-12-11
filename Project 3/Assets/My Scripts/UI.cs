using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    private float time = 1.0f;
    public Text text;
	
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

        text.text = "Speed of Time: " + time.ToString("F2");
        
    }
}
