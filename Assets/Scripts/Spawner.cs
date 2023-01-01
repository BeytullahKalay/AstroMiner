using Unity.Mathematics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
   public GameObject enemy;
   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.A))
      {
         Instantiate(enemy, transform.position, quaternion.identity);
      }
   }
}
