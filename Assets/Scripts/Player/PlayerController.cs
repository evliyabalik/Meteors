using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float m_movementSpeed;
    [SerializeField] int m_healt = 100;

    Rigidbody2D m_Rigidbody;
    Vector2 move;
    float time;


    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        move.y = -Input.GetAxisRaw("Vertical");
        Move(move);
        Rotate();
        PlayerDead();
        time += Time.deltaTime;
    }

    private void Move(Vector2 movement)
    {
        var pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -8.5f, 8.5f);
        if (movement != Vector2.zero)
            m_Rigidbody.AddForce(transform.up * Time.deltaTime * m_movementSpeed, ForceMode2D.Force);
        //m_Rigidbody.velocity = movement.normalized * Time.deltaTime * m_movementSpeed;
        else
            m_Rigidbody.AddForce(Vector3.zero);

        transform.position = pos;
    }

    private void Rotate()
    {
        var mouseTransform = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(transform.position.x - mouseTransform.x, transform.position.y - mouseTransform.y);
        transform.up = -(Vector3)direction;
    }

    void PlayerDead()
    {
        if (m_healt <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("You are Dead!");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Meteor"))
        {
            if (time >= 1)
            {
                var damage = Random.Range(5, 15);
                m_healt -= damage;
                time = 0;
            }

        }
    }


}
