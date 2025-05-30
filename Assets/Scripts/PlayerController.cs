using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;

    private Rigidbody body;
    private XRRig xrRig;
    private CapsuleCollider playerCollider;

    private bool IsGrounded => Physics.Raycast(
        new Vector2(transform.position.x, transform.position.y + 2.0f), Vector3.down, 2.0f);

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        xrRig = GetComponent<XRRig>();
        playerCollider = GetComponent<CapsuleCollider>();
        jumpActionReference.action.performed += OnJump;

    }

    // Update is called once per frame
    void Update()
    {
        var center = xrRig.cameraInRigSpacePos;
        playerCollider.center = new Vector3(center.x, playerCollider.center.y, center.z);
        playerCollider.height = xrRig.cameraInRigSpaceHeight;
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded) return;
        body.AddForce(Vector3.up * jumpForce);
    }
}
