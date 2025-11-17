using UnityEngine;

public class SpawnNPC : MonoBehaviour
{
    [SerializeField] private GameObject NPCPrefab;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float currentTime;
    [SerializeField] private Transform[] todasLasSillas;
    private int indicePunto = 0;

    public void Update()
    {
        SpawnNPCTimer();
    }
     void Start()
    {
       
    }
    public void SpawnNPCTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToSpawn)
        {
            SpawnNPCInstance();
            currentTime = 0;
        }
    }
    public void SpawnNPCInstance()
    {
        print("NPC Invocado");
        GameObject npc = Instantiate(NPCPrefab, transform.position, Quaternion.identity); 

        NPC npcScript = npc.GetComponent<NPC>();
        if (npcScript != null && todasLasSillas.Length > 0) // Verifica que el script NPC esté presente y que haya puntos B disponibles
        {
            npcScript.PUNTOB = todasLasSillas[indicePunto % todasLasSillas.Length]; // Asigna el punto B correspondiente
            indicePunto++; // Incrementa el índice para el próximo NPC
        }
    }
}
