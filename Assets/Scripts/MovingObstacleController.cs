using UnityEngine;

public class MovingObstacleController : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = new Vector3(2f,0f,0f);
    [SerializeField] private float moveTime = 2f;
    [SerializeField] private float speed = 3f;

    private Vector3 startingPosition;
    private Vector3 endingPosition;
    private float timer;

    void Start()
    {
        startingPosition = transform.position;
        endingPosition = transform.position + moveDirection;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * speed;
        float t = Mathf.PingPong(timer, moveTime) / moveTime;
        transform.position = Vector3.Lerp(startingPosition, endingPosition, t);
    }
}
