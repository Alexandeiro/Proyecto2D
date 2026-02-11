using UnityEngine;

public class MobilePlatform : MonoBehaviour
{

    [SerializeField] private float xVelocity = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + xVelocity * Time.deltaTime , transform.position.y);


        if (transform.position.x >= 6.5 || transform.position.x <= -7.5) xVelocity = -1*xVelocity;
    }
}
