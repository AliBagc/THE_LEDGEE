using UnityEngine;

public class Player_Movement1 : MonoBehaviour
{
    [SerializeField] public float PlayerSpeed = 3.5f;
    private Rigidbody rb;
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();// buraya çektik kodda ayarlama yapabilelim diye

    }
    void Update()
    {
        
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // a d hareketleeri için
        float moveZ = Input.GetAxis("Vertical"); // w s hareketleri için
        Vector3 movement = new Vector3(moveX,0,moveZ); // x y z düzlemde hareketi
        rb.linearVelocity = new Vector3(movement.x * PlayerSpeed,  rb.linearVelocity.y , movement.z * PlayerSpeed);  // velocity hız özelliği , rb.velocity.y = YERÇEKİMİNDEN DOLAYI, linearvelocity doğrusal

    }
     void FixedUpdate() // sürekli ama dengeli şekildee kontrol etsin diye buraya yazdık 
    {
        PlayerMovement();
    }
        


}
