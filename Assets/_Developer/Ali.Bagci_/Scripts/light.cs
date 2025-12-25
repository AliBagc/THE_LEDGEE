using UnityEngine;

public class light : MonoBehaviour
{
    [SerializeField] private Light flickerLight; // Titreyecek olan lamba
    [SerializeField] private float minIntensity = 50f; // En düşük ışık şiddeti 
    [SerializeField] private float maxIntensity = 300f; // En yüksek ışık şiddeti
    [SerializeField] private float flickerSpeed = 0.20f; // Titreme hızı (Saniye)

    private float timer;

    void Start()
    {
        
        if (flickerLight == null) flickerLight = GetComponent<Light>(); //// Eğer lamba atanmadıysa otomatik bulsun diye yazdım
    }

    void Update()
    {
        
        timer -= Time.deltaTime; // Zamanlayıcıyı her karede azaltıyoruz çünkü doğal görünmesini isityorum

        if (timer <= 0)
        {
            
            flickerLight.intensity = Random.Range(minIntensity, maxIntensity); // Işığın şiddetini rastgele bir değerle değiştiriyoruz
            
            
            timer = flickerSpeed; // Zamanlayıcıyı tekrar kuruyoruz
        }
    }
}
