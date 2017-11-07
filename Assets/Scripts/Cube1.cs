using UnityEngine;
using System.Collections;
using Roboland.Tools.UnityNetwork;
using System.Timers;

public class Cube1 : MonoBehaviour {

    Network<RVector3, RVector3> local1;
    Timer main_timer;
	// Use this for initialization
	void Start ()
    {
        local1 = new Network<RVector3, RVector3>("127.0.0.1", "7800", "7801", UnityNetworkType.PUBSUB);
        local1.eventDataUpdated += Local1_eventDataUpdated;
        local1.eventSetupStatus += Local1_eventSetupStatus;

        main_timer = new Timer();
        main_timer.Interval = 1000;
        main_timer.Elapsed += Main_timer_Elapsed;
        main_timer.Enabled = true;
	}

    private void Main_timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        RVector3 msg = new RVector3();
        msg.x = 10;
        msg.y = 20;
        msg.theta = 30;
        local1.sendMessage(msg);

        print("Cube 1 send done.");
    }

    private void Local1_eventSetupStatus()
    {
        print("Cube 1 connection : " + local1.is_connected);
    }

    private void Local1_eventDataUpdated()
    {
        RVector3 data = local1.get;
        print("Cube1 get data : " + data.x  + " " + data.y + " " + data.theta);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}

    void OnApplicationQuit()
    {
        main_timer.Stop();
        main_timer.Enabled = false;

        local1.eventDataUpdated -= Local1_eventDataUpdated;
        local1.eventSetupStatus -= Local1_eventSetupStatus;
        local1.killAll();
        local1 = null;
    }
}
