using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Patch _footstepPatch;
    [SerializeField] private AudioSource _footstepSource;
    [SerializeField] private float _footstepInterval;
    
    private CharacterController _characterController;
    private float _footstepTimer;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(_characterController.isGrounded && (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0))
        {
            if (_footstepTimer > _footstepInterval)
            {
                _footstepPatch.Play(_footstepSource);
                _footstepTimer = 0;
            }
            else
            {
                _footstepTimer += 0.1f;
            }
        }
    }
}
