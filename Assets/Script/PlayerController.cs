using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(_jumpPower * Vector3.up, ForceMode.Impulse);
            //transform.position += Vector3.up * _jumpPower;
        }
    }

    private void FixedUpdate()
    {
        //float hMove = Input.GetAxisRaw("Horizontal") * _moveSpeed * Time.deltaTime;
        //_rb.AddForce(hMove * Vector3.right, ForceMode.Impulse);
        float hMove = Input.GetAxisRaw("Horizontal") * _moveSpeed;
        transform.position += Vector3.right * hMove * Time.deltaTime;
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -6, 6);
        transform.position = pos;
    }

}
