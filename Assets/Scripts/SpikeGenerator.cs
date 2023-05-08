using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject Spike;

    public float MinSpeed;
    public float MaxSpeed;

    [SerializeField]
    private float _currentSpeed;

    private void Awake()
    {
        _currentSpeed = MinSpeed;
        Generate();
    }

    private void Update()
    {
        var spike = Instantiate(Spike, transform.position, transform.rotation);
        //spike
    }

    private void Generate()
    {

    }
}
