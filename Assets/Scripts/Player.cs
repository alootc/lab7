using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{

    

    public AudioClip clip_room1;
    public AudioClip clip_room2;
    public AudioClip clip_room3;
    public AudioClip clip_room4;

    public AudioClip succes;

    private bool isCollisionNPC;
    private NPCController npc;

    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    
    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        if (Input.GetKeyDown(KeyCode.E) && isCollisionNPC)
        {
            npc.isPlayer = true;
            Debug.Log("Alto");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Room"))
        {
            if(other.TryGetComponent(out Room room))
            {
                SoundManager.instance.ChangeMusic(clip_room1);
            }
            
            SoundManager.instance.ChangeSFX(succes);

        }
        

        if (other.CompareTag("NPC"))
        {
            isCollisionNPC = true;
            npc = other.GetComponent<NPCController>();
        }

    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            isCollisionNPC = false;
            if(npc != null)
            {
                npc.isPlayer = false;
                npc = null;
            }
        }

    }
    
}
