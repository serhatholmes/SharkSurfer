using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkContr : MonoBehaviour
{
    Rigidbody rb;
    public SwerveInput SI;
    public float swerveSpeed;
    public float maxSwerveAmount;
    public float speedForward;

    public float jumpForce;

    public bool isJump = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SI = GetComponent<SwerveInput>();

    }

    void Update()
    {
        //rb.velocity = transform.forward * speedForward;
        float swerveAmount = Time.deltaTime * swerveSpeed * SI.MoveFactorX;
        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(-speedForward, 0, swerveAmount);
        if (transform.position.x < -3.5){
            transform.position = new Vector3(-3.5f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 3.5){
            transform.position = new Vector3(3.5f, transform.position.y, transform.position.z);
        }
    }

    public void jumpShark(){
        
        Debug.Log("jumping");
        rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
        
        
    }

    private void OnTriggerEnter(Collider other) {

        /*if(other.gameObject.CompareTag("Deep")){
            isJump = true;

        }*/
    }
}
