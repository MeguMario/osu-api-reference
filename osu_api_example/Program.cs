using System.IO;
using System.Net;
using System;
using Newtonsoft.Json.Linq;
using System.Text;

namespace osu_api_ref
{
    class jsonc
    {
        public static void Main()
        {
            // osuapi = "https://osu.ppy.sh/api/v1/"
            // Getting data from the api using WebClient
            string k = "INSERT KEY HERE";
            Console.Write("Enter username: ");
            string u = Console.ReadLine();
            string sauce = $"https://osu.ppy.sh/api/get_user?u={u}&k={k}";
            // OG: string source = $"https://osu.ppy.sh/api/get_user?u={u}&k={k}";
            WebClient wc = new WebClient();
            // Case 2: var json = wc.DownloadString(source);
            // Case 2: wc.DownloadFile(sauce, fn);
            string json = wc.DownloadString(sauce);
            // Select display mode (01 - Super raw json, 02 - Raw Json, 03 - Unoptimized, WIP and experimental friendlier displaying mode)
            Console.Write("Enter display mode (1-3): ");
            sbyte caseSw = Convert.ToSByte(Console.ReadLine());
            // Main program which the only purpose is to print out the response
            switch (caseSw)
            {
                // Print super raw json
                case 1:
                    {
                        Console.WriteLine("Super raw json: ");
                        Console.WriteLine(json);
                        Console.ReadKey();
                        break;
                    }
                // Print raw json
                case 2:
                    {
                        string[] jsonsArray = new string[] { "" };
                        jsonsArray = json.Split(',');
                        Console.WriteLine("Print raw json: ");
                        foreach (string jsons in jsonsArray)
                        {
                            Console.WriteLine(jsons);
                        }
                        // Case 2: foreach(string jsons in jsonsArray)
                        // Case 2: Console.WriteLine(jsons);
                        // Case 2: string json = System.IO.File.ReadAllText(fn);
                        // Case 2: Console.WriteLine(json);
                        // Case 2:  List<Class1> class1 = JsonConvert.DeserializeObject<List<Class1>>(json);
                        Console.ReadKey();
                        break;
                    }
                // Readable format
                case 3:
                    {
                        Console.WriteLine("Readable format: ");
                        // int[] countArray = new int[9];
                        var usrn = JArray.Parse(json)[0]["username"].ToString();
                        var join = JArray.Parse(json)[0]["join_date"].ToString();
                        var plcn = JArray.Parse(json)[0]["playcount"].ToString();
                        var rasc = JArray.Parse(json)[0]["ranked_score"].ToString();
                        var tosc = JArray.Parse(json)[0]["total_score"].ToString();
                        var rapp = JArray.Parse(json)[0]["pp_rank"].ToString();
                        var ppsr = JArray.Parse(json)[0]["pp_raw"].ToString();
                        var accu = JArray.Parse(json)[0]["accuracy"].ToString();
                        var nati = JArray.Parse(json)[0]["country"].ToString();
                        var plti = JArray.Parse(json)[0]["total_seconds_played"].ToString();
                        var rana = JArray.Parse(json)[0]["pp_country_rank"].ToString();
                        int plti32 = Convert.ToInt32(plti);
                        int pltim = plti32 / 60;
                        Console.WriteLine("Username: " + usrn);
                        Console.WriteLine("Join date: " + join);
                        Console.WriteLine("Playcount: " + plcn);
                        Console.WriteLine("Ranked score: " + rasc);
                        Console.WriteLine("Total score: " + tosc);
                        Console.WriteLine("Current rank: " + rapp);
                        Console.WriteLine("Current pp: " + ppsr);
                        Console.WriteLine("Accuracy: " + accu);
                        Console.WriteLine("Country: " + nati);
                        Console.WriteLine("Playtime (by minute): " + pltim);
                        Console.WriteLine("Current country rank: " + rana);
                        Console.ReadKey();
                        break;
                    }
                // Invaild entry
                default:
                    {
                        Console.WriteLine("Invaild value!");
                        goto case 3;
                    }
            }
        }
    }
}
