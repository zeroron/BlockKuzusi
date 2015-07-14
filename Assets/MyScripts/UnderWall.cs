using UnityEngine;
using System.Collections;
using MyGame;
public class UnderWall : MonoBehaviour {
    public void OnCollisionEnter(Collision collision)
    {
        GameController.setEnd(false);
    }
}
