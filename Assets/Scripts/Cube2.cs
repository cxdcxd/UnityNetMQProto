using UnityEngine;
using System.Collections;
using Roboland.Tools.UnityNetwork;
using System.Timers;

public class Cube2 : MonoBehaviour {

    Network<RVector3, RVector3> local2;
    Timer main_timer;
    // Use this for initialization
    void Start () {
        local2 = new Network<RVector3, RVector3>("127.0.0.1", "7801", "7800", UnityNetworkType.PUBSUB);
        local2.eventDataUpdated += Local2_eventDataUpdated;
        local2.eventSetupStatus += Local2_eventSetupStatus;

        main_timer = new Timer();
        main_timer.Interval = 1000;
        main_timer.Elapsed += Main_timer_Elapsed;
        main_timer.Enabled = true;
    }

    private void Main_timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        RVector3 msg = new RVector3();
        msg.x = 100;
        msg.y = 200;
        msg.theta = 300;
        local2.sendMessage(msg);

        print("Cube 2 send done.");
    }

    private void Local2_eventSetupStatus()
    {
        print("Cube 2 connection : " + local2.is_connected);
    }

    private void Local2_eventDataUpdated()
    {
        RVector3 data = local2.get;
        print("Cube2 get data : " + data.x + " " + data.y + " " + data.theta);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnApplicationQuit()
    {
        main_timer.Stop();
        main_timer.Enabled = false;

        local2.eventDataUpdated -= Local2_eventDataUpdated;
        local2.eventSetupStatus -= Local2_eventSetupStatus;
        local2.killAll();
        local2 = null;
    }
}
