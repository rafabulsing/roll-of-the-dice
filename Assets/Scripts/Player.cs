using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            gameObject.transform.position += Vector3.right;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90) * gameObject.transform.rotation;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            gameObject.transform.position += Vector3.forward;
            gameObject.transform.rotation = Quaternion.Euler(90, 0, 0) * gameObject.transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            gameObject.transform.position += Vector3.left;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 90) * gameObject.transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            gameObject.transform.position += Vector3.back;
            gameObject.transform.rotation = Quaternion.Euler(-90, 0, 0) * gameObject.transform.rotation;
        }
    }
}
