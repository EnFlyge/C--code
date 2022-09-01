using System.Collections;
using UnityEngine;

namespace gamePlayer{
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] private Vector3 _movementSpeed;
        private float _speedX;
        private float _speedY;
        public GameObject dust;
        private bool _canDust;
        
        void Start() 
        {
            InvokeRepeating ("PlaySound", 0.0f, Random.Range(0.25f, 0.45f));
            _canDust = true;
        }

        void Update() 
        {
            Movement();
        }

        void PlaySound() 
        {
            if (Mathf.Abs(_speedX) > 0 || Mathf.Abs(_speedY) > 0)
                SoundManager.PlaySound("Steps");
        }

        void Movement() 
        {
            float _movementFactor = 10f;
            _speedX = Input.GetAxis("Horizontal") * _movementFactor;
            _speedY = Input.GetAxis("Vertical") * _movementFactor;
            _movementSpeed = new Vector3(_speedX, _speedY, 0f);

            if (_movementSpeed.magnitude > 0 && _canDust)
                StartCoroutine(WaitToDust());
            gameObject.GetComponent<Rigidbody2D>().velocity = _movementSpeed;
            if (_speedX != 0 || _speedY != 0)
                gameObject.GetComponent<Animator>().SetBool("isMoving", true);
            else
                gameObject.GetComponent<Animator>().SetBool("isMoving", false);
        }

        private IEnumerator WaitToDust() 
        {
            _canDust = !canDust;
            yield return new WaitForSeconds(Random.Range(0.15f, 0.25f));
            _canDust = !canDust;
            if (movementSpeed.magnitude > 0)
                Instantiate(dust, transform.Find("Shadow").transform.position, Quaternion.identity);
        }
    }
}