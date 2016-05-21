using UnityEngine;
using System.Collections;

public class SlothScript : MonoBehaviour
{
    public int currentWire;
    public float climbSpeed;
    public float moveSpeed;
	public Animator anim;

    public GameController cont;

    private float nextMove;

    void OnTriggerEnter(Collider other)
    {
		if (other.transform.position.y == this.transform.position.y-2) {
			cont.Hit (other);
		} else {
			if (other.tag == "Rat" || other.tag == "Cat") {
				
				Climb (false);
				if (transform.position.y < -4) {
					cont.Damage ();
					cont.Damage ();
					cont.Damage ();
				}
			}
			if (other.tag == "Poop") {
				cont.Hit (other);
			}
		}
    }

    void Start()
    {
		anim = GetComponent<Animator>();
        currentWire = 2; //Starts on middle wire
        nextMove = 0; //"Cooldown" on how fast you can move up and down
    }

    void Update()
    {
		
		if (nextMove > Time.time) {
		//play walk again
			anim.SetBool("up",false);
			anim.SetBool ("down", false);
		}
        if (Input.GetAxis("Vertical") > 0 && Time.time > nextMove)
        {
            switch (currentWire)
            {
                case 4:
                    break;
                case 3:
                    if (cont.line4)
                    {
                        Climb(true);
                    }
                    break;
                case 2:
                    if (cont.line3)
                    {
                        Climb(true);
                    }
                    break;
                case 1:
                    Climb(true);
                    break;
                case 0:
                    if (cont.line1)
                    {
                        Climb(true);
                    }
                    break;
            }
        }
        else if (Input.GetAxis("Vertical") < 0 && Time.time > nextMove)
        {
            switch (currentWire)
            {
                case 4:
                    if (cont.line3)
                    {
                        Climb(false);
                    }
                    break;
                case 3:
                    Climb(false);
                    break;
                case 2:
                    if (cont.line1)
                    {
                        Climb(false);
                    }
                    break;
                case 1:
                    if (cont.line0)
                    {
                        Climb(false);
                    }
                    break;
                case 0:
                    break;
            }
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Time.deltaTime * moveSpeed, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Time.deltaTime * -moveSpeed, 0, 0);
        }
    }

    public void Climb(bool up)
    {
        nextMove = Time.time + climbSpeed; //Sets climb cooldown
        if (up)
        {
            transform.Translate(0, 2, 0);
            currentWire++;
        }
        else {
            transform.Translate(0, -2, 0);
            currentWire--;
        }
    }

    void Fall(Collider other)
    {
         if(this.tag == "Feet" && other.tag == "Cat" || other.tag == "Rat")
            Climb(false);
    }
}
