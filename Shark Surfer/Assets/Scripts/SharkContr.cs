using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SharkContr : MonoBehaviour
{
    Rigidbody rb;
    public SwerveInput SI;
    public float swerveSpeed;
    public float maxSwerveAmount;
    public float speedForward;

    public float jumpForce;

    public bool isJump;

    public bool isDead = false;

    public SceneMang SM;

    public int coinScore=0;

    public TMP_Text scoreText;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        SI = GetComponent<SwerveInput>();

        isJump = true;

    }
    void Update()
    {
        if(SM.isStart){
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

        scoreText.SetText(""+coinScore);

        if(isDead){
            //SM.SharkDead();
        }
    }
    public void jumpShark(){
        
        if(isJump==true){
            //Debug.Log("jumping");
            rb.AddForce(0,jumpForce,0, ForceMode.Impulse);
        }
    }

    
    private void OnTriggerStay(Collider other) {

        if(other.gameObject.CompareTag("Surface")){

            isJump = true;
        }  
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Surface")){
            isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")){
            coinScore += 10;
        }
        if(other.gameObject.CompareTag("Life")){
            coinScore +=20;
        }
        if(other.gameObject.CompareTag("Hitable")){
            
            isDead = true;
            Time.timeScale = 0;
            SM.endPanel.SetActive(true);
            SM.gameplayPanel.SetActive(false);
        }
        if(other.gameObject.CompareTag("Win")){

            SM.gameplayPanel.SetActive(false);
            SM.winPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    


}
