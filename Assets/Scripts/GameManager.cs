using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Vector3 startPosition;
    public Quaternion startRotation;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        player.nextMoves = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            Destroy(player.gameObject.GetComponent<Rigidbody>());
            player.gameObject.transform.position = startPosition;
            player.gameObject.transform.rotation = startRotation;
            player.value = player.GetValue();
        }
    }
    
    public void Victory()
    {
        Debug.Log("you win!");
    }
}
