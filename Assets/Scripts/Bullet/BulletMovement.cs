using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float m_movementSpeed;
    Rigidbody2D m_rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.AddForce(transform.up * Time.deltaTime * m_movementSpeed, ForceMode2D.Impulse);
        Destroy(transform.gameObject, 3f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") && !collision.CompareTag("Barrel") && !collision.CompareTag("Bullet"))
            Destroy(transform.gameObject);
    }


}
