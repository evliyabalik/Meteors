using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] int m_healt = 100;
    [SerializeField] float m_movementSpeed = 0.5f;

    private void Start()
    {
        m_healt = Mathf.RoundToInt(m_healt * transform.localScale.x/2);
    }

    private void FixedUpdate()
    {
        MeteorMovement();
        MeteorDead();
        MeteorDisabled();
    }

    void MeteorMovement()
    {
        var position = transform.position;
        position.x += -1 * Time.deltaTime * m_movementSpeed;
        transform.position = position;
    }

    void MeteorDead()
    {
       if(m_healt<=0)
            transform.gameObject.SetActive(false);
    }

    void MeteorDisabled()
    {
        if (transform.position.x < -10)
            transform.gameObject.SetActive(false);
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            var damage = Random.Range(1, 7);
            m_healt -= damage;
        }

    }
}

