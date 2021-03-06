using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject block; // default block

    public GameObject square;
    public GameObject rectangle;

    public int i = 0;

    Vector3 currentPos = new Vector3();

    void Update()
	{
        drop();
		selector();
        Debug.Log(block.transform.rotation);
    }

    void selector()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // cycle through objects
        {
            block = square;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            block = rectangle;
        }
    }

    void drop() // The shape dropper 
    {
        if (Input.GetKeyDown("space") && KinCollider.hasStopped == true)
        {
            currentPos = new Vector3(CraneMove.playerPos.x, CraneMove.playerPos.y - 1, CraneMove.playerPos.z);
            Instantiate(block, currentPos, Quaternion.identity);
            block.name = "block00" + i;
            ScoreBoard.gameScore += 100;
            KinCollider.hasRolling = true;
            KinCollider.hasStopped = false;
            i++;
        }
       
    }

}