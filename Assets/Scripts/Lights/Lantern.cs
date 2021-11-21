using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LightBox m_LightBox;
    [SerializeField] private float m_FearReducer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_LightBox.IsOn)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, m_LightBox.Radius);
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag("Player"))
                {
                    float distanceFromPlayer = Vector3.Distance(collider.transform.position, transform.position);
                    Debug.Log($"Distance: {distanceFromPlayer}");
                    // The larger the number the less Fear is recovered
                    float distance = distanceFromPlayer - 1 < 1 ? 1 : distanceFromPlayer - 1;
                    float reduction = m_FearReducer / distance;
                    Debug.Log($"Reduction: {reduction}");
                }                    
            }
        }
    }

    void OnMouseOver() {
        if (!m_LightBox.IsOn && Input.GetMouseButtonDown(0)) {
            m_LightBox.TurnOn();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, m_LightBox.Radius);
    }
}
