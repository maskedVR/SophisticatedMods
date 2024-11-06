using BepInEx;
using UnityEngine;
using Newtilla;
using Photon.Pun;

namespace SophisticatedAntiModded
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{
			inRoom = false;

			Newtilla.Newtilla.OnJoinModded += OnModdedJoin;
			Newtilla.Newtilla.OnLeaveModded += OnModdedLeave;
		}

		void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
		}
		void Update()
		{
			if (inRoom)
			{
				Application.Quit()
			}
		}
		public void OnModdedJoin(string gamemode)
		{
			inRoom = true;
		}

		public void OnModdedLeave(string gamemode)
		{
			inRoom = false;
		}
	}
}
