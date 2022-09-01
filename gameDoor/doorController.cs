using UnityEngine;

namespace gameDoor {
    [RequireComponent(typeof(AudioSource), typeof(Animator), typeof(AudioClip))]
    public class doorController : MonoBehaviour {
        [SerializeField] private Animator _animator;
        
        private Transform _player;
        private bool isOpen;
        private bool _objectiveCompleted = true;
        [SerializeField] private int _distance;

        [SerializeField] private bool _inChild;
        [SerializeField] private Animator _animatorChild1;
        [SerializeField] private Animator _animatorChild2;

        private AudioSource _audioSrc;
        [SerializeField] private AudioClip _audioClip;
        
        private void Start() {
            isOpen = false;
            
            _player = GameObject.Find("Player").GetComponent<Transform>();

            _audioSrc = GetComponent<AudioSource>();
        }
        
        private void Update() {
            if (Vector2.Distance(transform.position, _player.position) < _distance && !isOpen && _objectiveCompleted) {
                if (_inChild) SetChildDoors(true);
                else SetDoor(true);

                isOpen = true;
            } else if ((Vector2.Distance(transform.position, _player.position) > _distance || !objectiveCompleted) && isOpen) {
                if (_inChild) SetChildDoors(false);
                else SetDoor(false);

                isOpen = false;
            }
        }

        private void SetDoor(bool state) {
            PlayDoorSound();
            _animator.SetBool("isOpen", state);
        }

        private void SetChildDoors(bool state) {
            PlayDoorSound();
            if (_animatorChild1.gameObject.activeSelf)
                _animatorChild1.SetBool("isOpen", state);
            if (_animatorChild2.gameObject.activeSelf)
                _animatorChild2.SetBool("isOpen", state);
            GetComponent<BoxCollider2D>().enabled = !state;
        }

        public bool ObjectiveCompleted {
            get { return _objectiveCompleted; }
            set { _objectiveCompleted = value; }
        }

        private void PlayDoorSound() {
            _audioSrc.PlayOneShot(_audioClip, 1f);
        }
    }
}