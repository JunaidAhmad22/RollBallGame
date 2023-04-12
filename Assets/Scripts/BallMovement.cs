using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jump = 5.0f;
    public float health = 100.0f;
    private bool isGrounded = true;
    public TMP_Text healthText;
    public GameObject GameOverPanel;
    void Update()
    {
        float horizantal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizantal, 0, vertical);
        transform.position += direction * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jump);
            isGrounded = false;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health -= 50;
            healthText.text = health.ToString();
            Debug.Log(health);
            if (health <= 0)
            {
                Destroy(gameObject);
                GameOverPanel.SetActive(true);
            }
        }
    }
}
