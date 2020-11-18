using UnityEngine;
using UnityEngine.Networking;

public class CustomManager : NetworkManager
{
    // Set custom connection parameters early, so they are not too late to be enforced
    void Start()
    {
        customConfig = true;
        connectionConfig.MaxCombinedReliableMessageCount = 40;
        connectionConfig.MaxCombinedReliableMessageSize = 800;
        connectionConfig.MaxSentMessageQueueSize = 2048;
        connectionConfig.IsAcksLong = true;
        globalConfig.ThreadAwakeTimeout = 1;
    }
}