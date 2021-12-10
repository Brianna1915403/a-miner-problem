using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    [SerializeField] private LightBox m_LightBox;
    [SerializeField] private float m_FearReducer;
    [SerializeField] private bool m_CanActivate = false;
    [SerializeField] private float m_Delay = 2f;
    [SerializeField] private float m_TargetTime = 0f;
    [SerializeField] private float m_CurrentTime = 0f;

    void Start() {
        m_CurrentTime = Time.deltaTime;
        m_TargetTime = m_CurrentTime + m_Delay;
    }

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_LightBox.Radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                if (m_LightBox.IsOn) {
                    m_CurrentTime += Time.deltaTime;
                    if (m_CurrentTime >= m_TargetTime) {
                        float distanceFromPlayer = Vector3.Distance(collider.transform.position, transform.position);
                        // The larger the number the less Fear is recovered
                        float distance = distanceFromPlayer - 1 < 1 ? 1 : distanceFromPlayer - 1;
                        float reduction = m_FearReducer / distance;
                        Player.Instance.Fear -= Player.Instance.Fear <= 0 ? 0 : reduction;
                        Debug.Log($"Reduction: {reduction}");
                    }
                } else {
                    m_CanActivate = true;
                }
                break;
            } else {
                m_CanActivate = false;       
            }                   
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger Collider w/ {other.name}");
        if (other.CompareTag("Pickable") && other.GetComponent<OreChunk>())
        {
            OreChunk attributes = other.GetComponent<OreChunk>();
            Debug.Log($"Can activate? {m_CanActivate}");
            if (m_CanActivate && attributes.OreType.Equals(ORE_TYPE.CRYSTAL))
            {
                m_LightBox.TurnOn();
                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log($"{attributes.OreType} {(attributes.OreType.Equals(ORE_TYPE.CRYSTAL) ? "is" : "is not")} a crystal");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, m_LightBox.Radius);
    }
}
