using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovment : MonoBehaviour
{
    [SerializeField] float speed;
     private float padding = 1.05f;
     private float minX;
    private float maxX;
    private float minY;
    private float maxY;
    void Start()
    {
        FindBoundaries();
    }
    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Y = Input.GetAxisRaw("Vertical");
        float newposofX = Mathf.Clamp(transform.position.x + X * speed * Time.deltaTime, minX, maxX);

        float newposofY = Mathf.Clamp(transform.position.y + Y * speed * Time.deltaTime, minY, maxY);

        transform.position = new Vector2(newposofX, newposofY);
    }
    // with help of this codes we can control our player to not leave the game view.
    void FindBoundaries()
    {
        //to change viewport to world point which helps the game in different tyoes of aspect ratio of devices
        Camera gamecamera = Camera.main;
        minX = gamecamera.ViewportToWorldPoint(new Vector2(0, 0)).x + padding;
        maxX = gamecamera.ViewportToWorldPoint(new Vector2(1, 0)).x - padding;
        minY = gamecamera.ViewportToWorldPoint(new Vector2(0, 0)).y + 0.9f;
        maxY = gamecamera.ViewportToWorldPoint(new Vector2(0, 1)).y - 0.8f;
    }
}
