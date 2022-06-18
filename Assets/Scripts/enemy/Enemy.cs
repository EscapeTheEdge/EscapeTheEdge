using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed;
    private Vector3 direction;
    private float maxDistance;
    private Vector3 initialPosition;

    public void Initialize(float speed, Vector3 direction, float maxDistance)
    {
        this.speed = speed;
        this.direction = direction;
        this.maxDistance = maxDistance;
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - initialPosition).magnitude > maxDistance)
        {
            Destroy(gameObject);
        }

        transform.Translate(direction * (Time.deltaTime * speed));
    }
}