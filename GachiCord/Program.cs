using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DiscordRPC; //Library for working with RPC discord
using DiscordRPC.Logging; //Logging library for working with RPC discord
namespace GachiCord
{
    class Program
    {
        /// <summary>
        /// Discord Client instance
        /// </summary>
        static DiscordRpcClient DiscordClient { get; set; }
        /// <summary>
        /// List of statuses 
        /// </summary>
        static List<string> Statuses { get; set; }
        /// <summary>
        /// Photo title list (from app settings)
        /// </summary>
        static List<string> Photos { get; set; }
        /// <summary>
        /// Randomizer object
        /// </summary>
        static Random Rand { get; set; }
        /// <summary>
        /// The current time to display in the status
        /// </summary>
        static Timestamps StartTime { get; set; }
        /// <summary>
        /// An object containing information for displaying a party
        /// </summary>
        static Party DisplayParty { get; set; }
        /// <summary>
        /// Party Display Name
        /// </summary>
        static string DisplayPartyName { get; set; }
        /// <summary>
        /// Delay in update Discord status
        /// </summary>
        static int UpdateDelay { get; set; }
        /// <summary>
        /// Application initialization
        /// </summary>
        static Program()
        {

            DiscordClient = new DiscordRpcClient("777579821399801867") { Logger = new ConsoleLogger() { Level = LogLevel.Info } }; //Initialization of the client Discord with the previously received application ID
            DiscordClient.OnReady += (sender, e) => Console.WriteLine($"Gachi for {e.User.Username}"); //Adding information output to the console
            DiscordClient.OnPresenceUpdate += (sender, e) => Console.WriteLine($"Update {e.Presence}"); //Adding information output to the console
            Rand = new Random(); //Initializing the randomizer
            Statuses = new List<string>(); //List initialization
            Photos = new List<string>(); //List initialization
            Statuses.Add("Without further interruption, let's celebrate and suck some dick"); //Adding statuses to the list
            Statuses.Add("I want ♂THREE HUNDRED BUCKS♂");
            Statuses.Add("The course I took on ♂SUCK SOME DICK♂");
            Statuses.Add("I ♂SWALLOW♂ now ♂MY CUM♂");
            Statuses.Add("♂Ass we can!♂");
            Statuses.Add("♂Cum♂ good for health");
            Statuses.Add("♂Two fat cocks♂ is better ♂little dicks");
            Statuses.Add("♂Suck some dick♂ everyday");
            Statuses.Add("Do not be angry ♂billy♂, otherwise you will have to endure hard fisting♂");
            Photos.Add("1"); //Adding photos to the list
            Photos.Add("2");
            Photos.Add("3");
            Photos.Add("4");
            Photos.Add("5");
        }
        static async Task Main(string[] args)
        {
            DiscordClient.Initialize(); //Launching a discord client
            StartTime = new Timestamps(DateTime.UtcNow); //Setting the current time to display in the status
            DisplayParty = new Party()
            {
                ID = "123456789", //ID required for the discord to display
                Max = 3, //Number displayed as maximum party size
                Size = 1 //The number displayed is how many people are in the party now
            };
            UpdateDelay = 5000; //Setting the delay for changing the discord status, it is recommended not less than 4000
            DisplayPartyName = "IN MY ANAL"; //Setting the name of the party
            while (true) //Infinite loop
            {
                var StatusNow = Statuses[Rand.Next(0, Statuses.Count)]; //Choosing a random status from the list
                var ImageNow = Photos[Rand.Next(0, Photos.Count)]; //Selecting a random image from the list
                DiscordClient.SetPresence(new RichPresence() //Calling the status set function with parameters
                {
                    Party = DisplayParty,
                    Details = StatusNow,
                    State = DisplayPartyName,
                    Timestamps = StartTime,
                    Assets = new Assets() { LargeImageKey = ImageNow, }
                });
                await Task.Delay(UpdateDelay); //Calling a preset delay
            }
        }
    }
}
