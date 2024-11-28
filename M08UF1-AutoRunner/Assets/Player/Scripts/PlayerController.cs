using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
public class PlayerController : MonoBehaviour
{
    [SerializeField] float forwardAcceleration = 1f;
    [SerializeField] float maxForwardVelocity = 10f;
    [SerializeField] float minForwardVelocity = 10f;
    [SerializeField] float verticalVelocityOnGrounded = -1f;
    [SerializeField] InputActionReference Punch;
    [SerializeField] HitCollider hitColliderPunch;

    float forwardVelocity = 0f;
    float verticalVelocity = 0f;
    float gravity = -9.8f;

    CharacterController characterController;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void OnEnable()
    {
        Punch.action.Enable();
        Punch.action.performed += OnPunch;
    }
    private void OnDisable()
    {
        Punch.action.Disable();
        Punch.action.performed -= OnPunch;

    }
    private void OnPunch(InputAction.CallbackContext context) 
    {
        hitColliderPunch.gameObject.SetActive(true);
        DOVirtual.DelayedCall(0.5f, () => hitColliderPunch.gameObject.SetActive(false));
    }
    // Update is called once per frame
    void Update()
    {
        if (forwardVelocity < minForwardVelocity)
        { 
            forwardVelocity += forwardAcceleration * Time.deltaTime;
        }
        if (forwardVelocity > maxForwardVelocity)
        {
            forwardVelocity = maxForwardVelocity;
        }

        characterController.Move((Vector3.forward * forwardVelocity + 
            Vector3.up * verticalVelocity) * Time.deltaTime);

        if (characterController.isGrounded)
        { 
            verticalVelocity = 0f;
        }
        verticalVelocity += gravity * Time.deltaTime;
    }
}
