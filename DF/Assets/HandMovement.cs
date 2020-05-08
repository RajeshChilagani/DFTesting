using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fps;
    public GameObject Left;
    public GameObject Right;
    public float Speed = 10;
    public  float YRotationSpeed;
    public float ZRotationSpeed;
    public enum Zone
    {
        Near,
        Middle,
        Far
    }
    public enum Emote
    {
        green,blue,yellow,red,black,NoValue
    }
    public List<Emote> NearEmote = new List<Emote>();
    List<Emote> MiddleEmote = new List<Emote>();
    List<Emote> FarEmote = new List<Emote>();
    public Dictionary<Zone, List<Emote>> Emotes = new Dictionary<Zone, List<Emote>>();
    void Start()
    {
        NearEmote.Add(Emote.green);
        NearEmote.Add(Emote.red);
        MiddleEmote.Add(Emote.green);
        MiddleEmote.Add(Emote.blue);
        MiddleEmote.Add(Emote.red);
        FarEmote.Add(Emote.green);
        FarEmote.Add(Emote.blue);
        FarEmote.Add(Emote.yellow);
        FarEmote.Add(Emote.red);
        FarEmote.Add(Emote.black);
        Emotes.Add(Zone.Near,NearEmote);
        Emotes.Add(Zone.Middle, MiddleEmote);
        Emotes.Add(Zone.Far, FarEmote);
    }
    public Zone GetCurrentZone()
    {
        if(Vector3.Distance(Fps.transform.localPosition,Left.transform.localPosition)>=2)
        {
            return Zone.Far;
        }
        else if(Vector3.Distance(Fps.transform.localPosition, Left.transform.localPosition) >= 1)
        {
            return Zone.Middle;
        }
        else
        {
            return Zone.Near;
        }
    }
    public Emote GetEmote()
    {
        List<Emote> Temp = Emotes[GetCurrentZone()];
        Debug.Log("Zone:" + GetCurrentZone());
        Debug.Log("Speed:" + YRotationSpeed);
        if (YRotationSpeed > 9)
        {
            //Debug.LogError(Temp.Find(x => x == Emote.red));
            if(transform.GetComponent<TestMic>().Volume>-45.0f && transform.GetComponent<TestMic>().Volume  < 0)
            {
                if (Temp.Find(x => x == Emote.black) == Emote.black)
                {
                    return Temp.Find(x => x == Emote.black);
                }
            }
            else
            {
                if (Temp.Find(x => x == Emote.red) == Emote.red)
                {
                    return Temp.Find(x => x == Emote.red);
                }
            }
            
        }
        else if(YRotationSpeed>5)
        {
            if (Temp.Find(x => x == Emote.yellow) == Emote.yellow)
            {
                return Temp.Find(x => x == Emote.yellow);
            }
        }
        else if(YRotationSpeed >1)
        {
            if (Temp.Find(x => x == Emote.blue) == Emote.blue)
            {
                return Temp.Find(x => x == Emote.blue);
            }
        }
        return Emote.NoValue;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            Left.transform.localPosition = new Vector3(-0.5f, -0.5f, 0f);
            Right.transform.localPosition = new Vector3(0.5f, -0.5f, 0f);
        }
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            Left.transform.localPosition = new Vector3(-1f, -0.5f, 0f);
            Right.transform.localPosition = new Vector3(1f, -0.5f, 0f);
        }
        else if(Input.GetKey(KeyCode.Alpha3))
        {
            Left.transform.localPosition = new Vector3(-2f, -0.5f, 0f);
            Right.transform.localPosition = new Vector3(2f, -0.5f, 0f);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            YRotationSpeed += Time.deltaTime;
            //Rotation = Mathf.Clamp(Rotation, -90f, 90f);
            Left.transform.RotateAround(transform.position,transform.up, YRotationSpeed);
            Right.transform.RotateAround(transform.position, transform.up, -YRotationSpeed);
        }
        //else
        //{
        //    if (YRotationSpeed > 0)
        //    {
        //        YRotationSpeed = 0;
        //    }
        //}
        else if (Input.GetKey(KeyCode.E))
        {
            YRotationSpeed += Time.deltaTime;
            //Rotation = Mathf.Clamp(Rotation, -90f, 90f);
            Left.transform.RotateAround(transform.position, transform.up, -YRotationSpeed);
            Right.transform.RotateAround(transform.position, transform.up, YRotationSpeed);
        }
        else
        {
            YRotationSpeed = 0;
        }

    }
}
