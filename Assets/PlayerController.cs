using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 Movimiento;
    Rigidbody rb;
    [SerializeField] float speed;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(Movimiento.x* speed, rb.velocity.y, Movimiento.y* speed);
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Movimiento = value.ReadValue<Vector2>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC")) 
        {
            GameController.Interacction?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            GameController.Interacction?.Invoke(false);
        }
    }
}
