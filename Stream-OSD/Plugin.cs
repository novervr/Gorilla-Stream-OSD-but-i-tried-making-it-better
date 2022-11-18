using BepInEx;
using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.XR;
using Utilla;
using GorillaLocomotion;
using GorillaNetworking;

namespace Stream_OSD
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
   
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GUIStyle guiStyle = new GUIStyle();
        private readonly XRNode lNode = XRNode.LeftHand;
        bool sec;
        bool show;
        private void OnGUI()
        {
            guiStyle.fontSize = 20;
            guiStyle.normal.textColor = Color.white;
            bool inRoom = PhotonNetwork.InRoom;
            GUI.Label(new Rect(15f, 25f, 120f, 60f), PhotonNetwork.LocalPlayer.NickName, guiStyle);
            if (inRoom)
            {
                GUI.Label(new Rect(900f, 10f, 200f, 20f), "Current Code:" + PhotonNetwork.CurrentRoom.Name, guiStyle);
               
               GUI.Label(new Rect(900f, 35f, 200f, 40f), "There are " + PhotonNetwork.CurrentRoom.PlayerCount.ToString() + " People", guiStyle);
                GUI.Label(new Rect(1800f, 10f, 200f, 40f), "GameMode:", guiStyle);
                GUI.Label(new Rect(1800f, 35f, 200f, 40f), GorillaGameManager.instance.GameMode(), guiStyle);
            }
            if (!inRoom)
            {
                GUI.Label(new Rect(900f, 10f, 200f, 20f), "Not In a Code", guiStyle);
                GUI.Label(new Rect(1800f, 10f, 200f, 40f), "GameMode:", guiStyle);
            }
        }
    }

}
