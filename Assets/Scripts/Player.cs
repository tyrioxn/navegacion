using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public LayerMask layerFloor;
    public Transform routerFather;
    int indexchildren;
    Vector3 destination;
    public Vector3 min, max;
    // Start is called before the first frame update
    void Start()
    {
        destination = routerFather.GetChild(indexchildren).position;
        GetComponent<NavMeshAgent>().SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        #region //movimiento por clic
       /* if (Input.GetButtonDown("Fire1")){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, 1000)){
            GetComponent<NavMeshAgent>().SetDestination(hit.point);
        }
        }*/
        #endregion
        #region //ruta sola
        /*if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            indexchildren++;
            if (indexchildren >= routerFather.childCount)
            
                indexchildren = 0;
                destination = routerFather.GetChild(indexchildren).position;
                GetComponent<NavMeshAgent>().SetDestination(destination);
            
        }*/
        #endregion
        #region // ruta aleatoria por puntos

        /*if (Vector3.Distance (transform.position, destination) < 2.5f){
            indexchildren = Random.Range(0,routerFather.childCount);
            destination = routerFather.GetChild(indexchildren).position;
            GetComponent<NavMeshAgent>().SetDestination (destination);
        }*/
        #endregion
        #region //ruta aleatoria delimitada

       /*  if (Vector3.Distance(transform.position, destination) < 2.5f)
        {
            destination = RandomDestination();
            GetComponent<NavMeshAgent>().SetDestination(destination);
        }*/
        #endregion
        if (Vector3.Distance(transform.position, destination) < 2.5f){
            
            Vector3 randomPoint = Random.insideUnitSphere * 50;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomPoint,out hit,50,1);
            destination = hit.position;
            GetComponent<NavMeshAgent>().SetDestination(destination);

        }
    }
      Vector3 RandomDestination()
        {
            return new Vector3(Random.Range(min.x, max.x), 0 , Random.Range(min.z, max.z));
        } 
        

}

