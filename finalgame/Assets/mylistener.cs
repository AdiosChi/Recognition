using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class mylistener : MonoBehaviour
{
    [SerializeField] private Animator anim; 
    [SerializeField] private float meleeSpeed;
    [SerializeField] private float damage;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip attacksound;
    private List<int> ballValues = new List<int>();
    Thread thread;
    public int connectionPort = 25001;
    TcpListener server;
    TcpClient client;
    bool running;
    string dataReceived="";
    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();
    }

    float timeUntilMelee;
    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    void Connection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);
        dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

    }

    void Update()
    {
        
        if(timeUntilMelee <= 0f)
        {
            
            if (dataReceived == "basket")
            {
                Debug.Log("123");
                PlayAttackSound();
                anim.SetTrigger("2point");
                timeUntilMelee = meleeSpeed;
                dataReceived = "";
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
       if(timeUntilMelee <= 0f){

           if(Input.GetMouseButtonDown(2)){
                PlayAttackSound();
                anim.SetTrigger("2point");
                timeUntilMelee = meleeSpeed;
               
            }
           /* if(Input.GetMouseButtonDown(1)){
                PlayAttackSound();
                anim.SetTrigger("3point");
                timeUntilMelee = meleeSpeed;
                ScoreCode.Score = ScoreCode.Score + 1;
            }
            */
        }
         else{
            timeUntilMelee -= Time.deltaTime;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       
            if(other.tag== "Enemy")
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
            
            }
    }
    private void PlayAttackSound()
    {
        if (audioSource != null && attacksound != null)
        {
            audioSource.PlayOneShot(attacksound);
        }
    }
}
