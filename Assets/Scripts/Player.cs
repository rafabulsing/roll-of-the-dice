using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<string> nextMoves = new List<string>();
    public float moveProgress = 0;
    public Vector3 moveStartPosition;
    public int value = 5;
    public Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Not moving
        if (nextMoves.Count == 0) {
            CheckIfPressingKey();
        } else {
            // Moving

            // Calculate how much to rotate in this frame
            var angle = 360 * Time.deltaTime;
            if (angle + moveProgress > 90) {
                angle = 90 - moveProgress;
            }

            // Rotate die
            switch (nextMoves[0]) {
                case "right": {
                    gameObject.transform.RotateAround(moveStartPosition, Vector3.forward, -angle);
                    break;
                }
                case "up": {
                    gameObject.transform.RotateAround(moveStartPosition, Vector3.right, angle);
                    break;
                }
                case "left": {
                    gameObject.transform.RotateAround(moveStartPosition, Vector3.forward, angle);
                    break;
                }
                case "down": {
                    gameObject.transform.RotateAround(moveStartPosition, Vector3.right, -angle);
                    break;
                }
            }

            // If rotated 90 degrees, stop moving
            moveProgress += angle;
            if (moveProgress >= 90) {
                nextMoves.RemoveAt(0);
                moveProgress = 0;
                value = GetValue();
                if (nextMoves.Count > 0) {
                    moveStartPosition = GetMoveStartPosition(nextMoves[0]);
                }
            }
        }
    }

    int GetValue() {
        rotation = gameObject.transform.rotation.eulerAngles;

        rotation.x = RoundToNearest90((int)rotation.x);
        rotation.y = RoundToNearest90((int)rotation.y);
        rotation.z = RoundToNearest90((int)rotation.z);

        if (
            rotation == new Vector3( 270,   0,   0) ||
            rotation == new Vector3( 270,  90,   0) ||
            rotation == new Vector3( 270, 180,   0) ||
            rotation == new Vector3( 270, 270,   0)
        ) {
            return 1;
        } else if (
            rotation == new Vector3(   0,   0, 180) ||
            rotation == new Vector3(   0,  90, 180) ||
            rotation == new Vector3(   0, 180, 180) ||
            rotation == new Vector3(   0, 270, 180)
        ) {
            return 2;
        } else if (
            rotation == new Vector3(   0,   0, 270) ||
            rotation == new Vector3(   0,  90, 270) ||
            rotation == new Vector3(   0, 180, 270) ||
            rotation == new Vector3(   0, 270, 270)
        ) {
            return 3;
        } else if (
            rotation == new Vector3(   0,   0,  90) ||
            rotation == new Vector3(   0,  90,  90) ||
            rotation == new Vector3(   0, 180,  90) ||
            rotation == new Vector3(   0, 270,  90)
        ) {
            return 4;
        } else if (
            rotation == new Vector3(   0,   0,   0) ||
            rotation == new Vector3(   0,  90,   0) ||
            rotation == new Vector3(   0, 180,   0) ||
            rotation == new Vector3(   0, 270,   0)
        ) {
            return 5;
        } else if (
            rotation == new Vector3(  90,   0,   0) ||
            rotation == new Vector3(  90,  90,   0) ||
            rotation == new Vector3(  90, 180,   0) ||
            rotation == new Vector3(  90, 270,   0)
        ) {
            return 6;
        } else {
            return 0;
        }
    }

    int RoundToNearest90(int n) {
        int factor = 90;
        return (int)Math.Round(
            (n / (double)factor),
            MidpointRounding.AwayFromZero
        ) * factor;
    }

    Vector3 GetMoveStartPosition(string direction) {
        switch (direction) {
            case "right":
                return gameObject.transform.position + new Vector3(0.5f, -0.5f, 0f);
            case "up":
                return  gameObject.transform.position + new Vector3(0f, -0.5f, 0.5f);
            case "left":
                return  gameObject.transform.position + new Vector3(-0.5f, -0.5f, 0f);
            case "down":
                return  gameObject.transform.position + new Vector3(0f, -0.5f, -0.5f);
            default:
                return gameObject.transform.position;
        }
    }

    void CheckIfPressingKey() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            for (int i=0; i<value; ++i) {
                nextMoves.Add("right");
            }
            moveProgress = 0;
            moveStartPosition = GetMoveStartPosition("right");
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            for (int i=0; i<value; ++i) {
                nextMoves.Add("up");
            }
            moveProgress = 0;
            moveStartPosition = GetMoveStartPosition("up");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            for (int i=0; i<value; ++i) {
                nextMoves.Add("left");
            }
            moveProgress = 0;
            moveStartPosition = GetMoveStartPosition("left");
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            for (int i=0; i<value; ++i) {
                nextMoves.Add("down");
            }
            moveProgress = 0;
            moveStartPosition = GetMoveStartPosition("down");
        }
    }
}
