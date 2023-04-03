using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Set by other scrits when loot is spawned
    [SerializeField] private int _value;

    private float _rotationSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * (_rotationSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController pc))
        {
            Destroy(gameObject);
            pc.loot += _value;
        }
    }
}
