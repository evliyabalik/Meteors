using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    float m_randomScale;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        DontDestroyOnLoad(this.gameObject);
    }

    public void ObjectRandomScale(GameObject meteor)
    {
        m_randomScale = Random.Range(0.5f, 2f);
        var scale = meteor.transform.localScale;
        scale = new Vector3(m_randomScale, m_randomScale, m_randomScale);
        meteor.transform.localScale = scale;
    }

    

    public void InstanceObject(Transform target, Transform parent, GameObject prefabs, Quaternion rotation)
    {
        var meteor = Instantiate(prefabs, target.position, rotation);
        meteor.transform.SetParent(parent);
    }
}
