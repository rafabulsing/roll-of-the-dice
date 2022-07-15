using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGrid : MonoBehaviour
{
    private Grid grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = new Grid(4, 2, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            grid.SetValue(GetMouseWorldPosition(Input.mousePosition, Camera.main), 56);
        }

        if (Input.GetMouseButtonDown(1)) {
            Debug.Log(grid.GetValue(GetMouseWorldPosition(Input.mousePosition, Camera.main)));
        }
    }

    public static Vector3 GetMouseWorldPosition(Vector3 screenPosition, Camera worldCamera) {
        return worldCamera.ScreenToWorldPoint(screenPosition);
    }
}
