using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    Material MyMaterial;
    int emote = 0;
    Color[] Emotes = {Color.green,Color.blue,Color.red};
    void Start()
    {
        MyMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(emote);
        switch (emote)
        {
            case 0: MyMaterial.color = Color.Lerp(MyMaterial.color, Emotes[emote], 1 * Time.deltaTime);
                break;
            case 1:
                MyMaterial.color = Color.Lerp(MyMaterial.color, Emotes[emote], 1 * Time.deltaTime);
                break;
            case 2:
                MyMaterial.color = Color.Lerp(MyMaterial.color, Emotes[emote], 1 * Time.deltaTime);
                break;

        }
        
    }    
    private void OnTriggerEnter(Collider other)
    {
      
        if(other.tag.Equals("Hand"))
        {
            Debug.Log(other.name);
            Debug.Log(other.GetComponentInParent<HandMovement>().YRotationSpeed);
            
            if (other.GetComponentInParent<HandMovement>().YRotationSpeed>5)
            {
                emote = 2;
            }
            else if(other.GetComponentInParent<HandMovement>().YRotationSpeed > 2)
            {
                emote = 1;
            }
            else
            {
                emote = 0;
            }
        }
    }
}
