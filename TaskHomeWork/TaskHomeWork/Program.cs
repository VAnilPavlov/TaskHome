using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetData();

            Console.Read();
        }

        static Task GetData()
        {
            return Task.Run(() =>
            {
                WebRequest request = WebRequest.Create(" https://omgvamp-hearthstone-v1.p.rapidapi.com/cards");
                request.Headers.Add("X-RapidAPI-Host", "omgvamp-hearthstone-v1.p.rapidapi.com");
                request.Headers.Add("X-RapidAPI-Key", "eb5d1de496msh0618c46e96abd90p1fa17cjsncad11ebba8f3");


                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);

                    string responseFromServer = reader.ReadToEnd();
                                        
                    ListCard card = JsonConvert.DeserializeObject<ListCard>(responseFromServer);

                    Console.WriteLine("Все карты");

                    foreach (var i in card.Basic)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Classic)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Credits)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Debug)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Missions)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Naxxramas)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.Promo)
                    {
                        Console.WriteLine(i.name);
                    }

                    foreach (var i in card.System)
                    {
                        Console.WriteLine(i.name);
                    }
                                
                }

                
                return Task.CompletedTask;

              
            });
        }
    }
}
