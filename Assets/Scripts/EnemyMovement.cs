using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveDistance = 10f;
    private float startPosition;
    

void Start()
{
    startPosition = transform.position.x;
}

void Update()
{
    float movement = Mathf.PingPong(Time.time * moveSpeed, moveDistance);
    transform.position = new Vector3(startPosition + movement, transform.position.y, transform.position.z);
}
}
