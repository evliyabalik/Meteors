using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCreate : MonoBehaviour
{
    Vector2 position;
    Vector2 currentPosition;
    [SerializeField]Transform m_targetobj;
    [SerializeField]Transform m_parentobj;

    [SerializeField] GameObject meteor;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        currentPosition = position;
        GameManager.instance.InstanceObject(m_targetobj, m_parentobj, meteor, Quaternion.identity);
        StartCoroutine(MovementCoruntine());
    }

    void Movement()
    {
        position.y = Random.Range(-4, 4);
        position.y = Mathf.RoundToInt(position.y);
        transform.position = position;
        
    }

    IEnumerator MovementCoruntine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (position != currentPosition)
            {
                Movement();
                GameManager.instance.InstanceObject(m_targetobj, m_parentobj, meteor,Quaternion.identity);
                GameManager.instance.ObjectRandomScale(meteor);
                currentPosition = position;
            }
            else
            {
                position.y = Random.Range(-4, 4);
                position.y = Mathf.RoundToInt(position.y);
            }

            
        }
    }
}
