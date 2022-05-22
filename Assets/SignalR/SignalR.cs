using System.Text.Json;
using System.Threading.Tasks;
using UnityEngine;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;

public class SignalR : MonoBehaviour
{
    public string url;
    public string token;
    private HubConnection connection;

    private async void Awake()
    {
        url = "https://poker.rdo.belhard.com/poker/api/hubs/nlh-club-lobby";
        await GetConnection();
    }
    
    private async Task GetConnection()
    {
        connection = new HubConnectionBuilder()
            .WithUrl(url,options =>
            { 
                if(token!= null)
                    options.AccessTokenProvider = () => Task.FromResult(token);
            })
            .WithAutomaticReconnect()
            
            //IF YOU USE NEWTONSOFT JSON CUSTOM(https://github.com/jilleJr/Newtonsoft.Json-for-Unity)
            //HIM WORK ON MOBILE DEVICE(STANDART NEWTONSOFT DONT WORK)
            
                // .AddNewtonsoftJsonProtocol(o =>
                // {
                //     o.PayloadSerializerSettings = new JsonSerializerSettings
                //     {
                //         ContractResolver = new CamelCasePropertyNamesContractResolver(),
                //         Formatting = Formatting.None
                //     };
                // })
            
            //SYSTEM.TEXT.JSON(DONT DESERIALIZATION ENUM AND NULLABLE)
            .AddJsonProtocol(o =>
            {
                o.PayloadSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                o.PayloadSerializerOptions.WriteIndented = false;
            })
            .Build();
        await connection.StartAsync();
        Debug.Log("Connection SignalR is active!");
    }
}