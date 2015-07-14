using UnityEngine;
using System.Collections;
using MyGame;
public class UnderWallDumy : MonoBehaviour {
    public void OnCollisionEnter(Collision collision)
    {
        GameControllerDumy.Instance.setEnd(false);
    }
}
