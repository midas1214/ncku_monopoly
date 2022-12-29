using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField] private float speed = 1f;
    [HideInInspector] public int waypointIndex = 0;
    public bool moveallow = false;
    public int nextLap = 0;
    public bool allowPassShop = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveallow)
        {
            Move();
        }
    }

    private void Move()
    {
        if (waypointIndex > waypoints.Length - 1)
        {
            waypointIndex -= waypoints.Length;
            nextLap = 1;
            allowPassShop = true;
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, speed * Time.deltaTime);

        if (transform.position.x == waypoints[waypointIndex].transform.position.x && transform.position.y == waypoints[waypointIndex].transform.position.y)
        {
            waypointIndex++;
        }

    }
}
