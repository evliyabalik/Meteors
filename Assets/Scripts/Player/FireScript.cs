using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefabs;
    [SerializeField] Transform m_barrel;
    [SerializeField] Transform m_bulletParent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.InstanceObject(m_barrel, m_bulletParent, m_bulletPrefabs, transform.rotation);
        }
    }
}
