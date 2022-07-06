using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour {

	public Discord.Discord discord;

	// Use this for initialization
	void Start ()
	{
		discord = new Discord.Discord(CLIENT_ID, (System.UInt64)Discord.CreateFlags.Default);
		Debug.Log("Client ID Fetched Succesfully");
		var activityManager = discord.GetActivityManager();
		var activity = new Discord.Activity
		{
			State = "Beta Testing (Unity 2021.3.2f1)",
			Details = "Playing Alone",
			Assets =
            	{
                	LargeImage = "within-small-logo",
                	LargeText = "Within Beta 0.1.2",
            	},
		};
		activityManager.UpdateActivity(activity, (res) =>
		{
			if (res == Discord.Result.Ok)
			{
				Debug.Log("Discord RPC Connection Succesful");
			}
			else
			{
				Debug.LogError("Discord RPC Connection Unsuccesfull");
			}
		});
	}
	
	// Update is called once per frame
	void Update ()
	{
		discord.RunCallbacks();
	}

	void OnApplicationQuit()
	{
		Debug.LogWarning("Application Shutting Down");
		discord.Dispose();
		Debug.Log("Succesfully Cleared Discord RPC");

	}
}

// Error : Log only errors
// Warning : Log warnings and errors
// Info	Log : info, warnings, and errors
// Debug : Log all the things!
// Example : Debug.LogWarning("This is a warning");
