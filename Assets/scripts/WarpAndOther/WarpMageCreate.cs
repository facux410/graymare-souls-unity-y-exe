using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpMageCreate : MonoBehaviour,IUpdate
{
    amel Player;

    public Warp Warp;
    public Cross Cross;
    public Transform bezier;
  

    public List<Transform> SaveCrossPos = new List<Transform>();
    List<Warp> MyWarp = new List<Warp>();

    public int _portalCounter;
    public int AllPortals;
    public int counter;

    private void Start()
    {
        UpdateManager.Instance.AddElementUpdate(this);
        counter = 1;
    }

    private void Awake()
    {
        
        Player = GetComponent<amel>();
    }

    public void OnUpdate()
    {
        InstantiateCross();
        CretePortals();
        DestroyAllPortals();
        if (Input.GetKeyDown(KeyCode.Space) && Player.Change == 0)
            counter++;
    }

    void DestroyAllPortals()
    {
        if (Input.GetKeyDown(KeyCode.Space) && counter == 4 && Player.Change == 0)
        {
            counter = 0;
            _portalCounter = 0;

            for (int i = 0; i < MyWarp.Count; i++)
            {
                if(MyWarp[i] != null)
                {
                    Destroy(MyWarp[i].gameObject);
                    AllPortals-=2;
                }
            }
        }
            return;
    }



    void InstantiateCross()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Player.Change == 0 && _portalCounter < 2)
        {
            if (AllPortals < 4)
            {
                var PrefabCross = Instantiate(Cross);
                PrefabCross.transform.position = transform.position;
                PrefabCross.finalpos = bezier;
                SaveCrossPos.Insert(_portalCounter, PrefabCross.transform);
                _portalCounter++;
                AllPortals++;
            }

        }
    }

    void CretePortals()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Player.Change == 0  && _portalCounter == 2 && counter==3)
        {
            
            var PrefabPortal = Instantiate(Warp);
            PrefabPortal.transform.position = SaveCrossPos[0].position;
          
           

            var PrefabPortalTwo = Instantiate(Warp);
            PrefabPortalTwo.transform.position = SaveCrossPos[1].position;
           


            PrefabPortal.Target = PrefabPortalTwo.gameObject;
            PrefabPortalTwo.Target = PrefabPortal.gameObject;

            MyWarp.Add(PrefabPortal);
            MyWarp.Add(PrefabPortalTwo);

            Destroy(SaveCrossPos[0].gameObject);
            Destroy(SaveCrossPos[1].gameObject);
            SaveCrossPos.Clear();
            
            
        }
    }
}
