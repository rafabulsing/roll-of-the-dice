using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDown : MonoBehaviour
{
    public Player leader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = leader.gameObject.transform.position + new Vector3(0f, -1f, 0f);
    }

    void OnTriggerExit(Collider other)
    {
        leader.isOnGround--;

        if (other.name == "Goal") {
            leader.won--;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        leader.isOnGround++;
        if (other.name == "Goal") {
            leader.won++;
        }
    }
}
