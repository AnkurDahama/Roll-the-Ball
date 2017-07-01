using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private int count;
    private Rigidbody rb;
    public float speed;
    public Text countText;
    public Text winText;
    public Text timer;
    public Slider SpeedSlider;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        timer.text = "Time : 00:00";
        SpeedSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVerticle);
        rb.AddForce(movement * speed);
        if(count < 6)
        {
           timer.text = "Time : " + Time.realtimeSinceStartup.ToString();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }  
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 6)
        {
            winText.text = Time.realtimeSinceStartup.ToString();
        }
    }

    void ValueChangeCheck()
    {
        speed = SpeedSlider.value;
    }
}


