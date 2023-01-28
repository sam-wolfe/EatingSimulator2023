using UnityEngine;

public class Tongue : MonoBehaviour
{
    [SerializeField] private InputManager _input;
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody2D;
    
    void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rigidbody2D.AddForce(_input.tongue * speed * Time.deltaTime, ForceMode2D.Force);
    }
}
