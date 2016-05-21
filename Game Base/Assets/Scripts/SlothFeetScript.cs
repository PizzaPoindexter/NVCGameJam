using UnityEngine;
using System.Collections;

public class SlothFeetScript : Monobehaviour
{
    public SlothScript sloth; //Represents the sloth
    void fall(Collider other) //Causes sloth to fall when hit by either rat or cat
    {
         if(other.tag == "Cat" || other.tag == "Rat")
             sloth.Climb(false);
    }
}
