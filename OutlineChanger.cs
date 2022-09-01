using UnityEngine;

public class OutlineChanger : MonoBehaviour {
    private SpriteRenderer _spriteR;
    public float distance;
    private bool isActive;

    [SerializeField] private Material _m1;
    [SerializeField] private Material _m2;

    private Transform _player;
    
    void Start() 
    {
        _player = GameObject.Find("Player").transform;
        _spriteR = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        if (Vector2.Distance(transform.position, _player.position) < distance && !isActive) {
            spriteR.material = _m2;
            isActive = !isActive;
        } else if (Vector2.Distance(transform.position, _player.position) > distance && isActive) {
            isActive = !isActive;
            _spriteR.material = _m1;
        }
    }
}
