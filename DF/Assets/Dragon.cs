using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    // Start is called before the first frame update
    Material MyMaterial;
    int emote = 0;
    Color[] Emotes = {Color.green,Color.blue,Color.yellow,Color.red,Color.black};
    void Start()
    {
        MyMaterial = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
       
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
            case 3:
                MyMaterial.color = Color.Lerp(MyMaterial.color, Emotes[emote], 1 * Time.deltaTime);
                break;

        }
        
    }    
    private void OnTriggerEnter(Collider other)
    {
      
        if(other.tag.Equals("Hand"))
        {
            HandMovement PlayerHand = other.transform.parent.GetComponentInParent<HandMovement>();
            HandMovement.Emote emoteValue = PlayerHand.GetEmote();
            if (emoteValue != HandMovement.Emote.NoValue)
            {
                emote = (int)(emoteValue);
            }
            Debug.Log("Emote:"+emote);
        }
    }
}
