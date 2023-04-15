using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public static Vector3 boundary;
    private float PlayerRad;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRad = transform.localScale.x / 2;  
        boundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CurrentPos = transform.position;
        CurrentPos.x = Mathf.Clamp(transform.position.x, boundary.x * -1 + PlayerRad, boundary.x - PlayerRad);
        transform.position = CurrentPos;
    }
}
