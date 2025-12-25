using UnityEngine;

public class Player_Movement1 : MonoBehaviour
{
    [Header("Hareket Ayarları")]
    [SerializeField] private float PlayerSpeed = 3.5f;
    // Rigibody içeri çektik
    private Rigidbody rb;

    [Header("Bakış Ayarları")]
    [SerializeField] private Transform playerCamera; // Hiyerarşideki kamera
    [SerializeField] private float mouseSensitivity = 100f;
    private float xRotation = 0f;

    
    


    void Start()
    {
        rb = GetComponent<Rigidbody>();// buraya çektik kodda ayarlama yapabilelim diye
        Cursor.lockState = CursorLockMode.Locked; // Fareyi oyunun ortasına kitliyor ve dışarı çıkmasını engelliyor

    }
    void Update()
    {
    // 1. FARE HAREKETLERİ (BAKIŞ)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Dikey Bakış (Sadece Kamerayı Eğiyoruz - Kapsül devrilmez!)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Yatay Bakış (Bütün Kapsülü Sağa-Sola Döndürüyoruz)
        transform.Rotate(Vector3.up * mouseX);
    }

    void PlayerMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // a d hareketleeri için
        float moveZ = Input.GetAxis("Vertical"); // w s hareketleri için
        // transform.forward -> Karakterin baktığı "ileri" yönü
        // transform.right -> Karakterin baktığı "sağ" yönü
        Vector3 movementDirection = transform.forward * moveZ + transform.right * moveX; // transform.forward -> Karakterin baktığı "ileri" yönü, transform.right -> Karakterin baktığı "sağ" yönü
        

        // Senin linearVelocity sisteminle, baktığı yöne göre hızı uyguluyoruz
        rb.linearVelocity = new Vector3(movementDirection.x * PlayerSpeed, rb.linearVelocity.y, movementDirection.z * PlayerSpeed);  // velocity hız özelliği , rb.velocity.y = YERÇEKİMİNDEN DOLAYI, linearvelocity doğrusal

    }
     void FixedUpdate() // sürekli ama dengeli şekildee kontrol etsin diye buraya yazdık 
    {
        PlayerMovement();
    }
        


}
