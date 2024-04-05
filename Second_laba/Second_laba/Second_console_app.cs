using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Second_laba
{
    internal class Second_console_app
    {
        private List<string> _urls;

        private void AddURL()
        {
            int index;
            string newUrl;

            Console.WriteLine("Your current urls:");
            foreach (string i in _urls)
            {
                Console.WriteLine($"\t{i}");
            }
            Console.Write("Please, enter the index of url that you wanna change: ");
            index = Convert.ToInt32(Console.ReadLine());
            if (index < 0 || index > 2)
            {
                Console.WriteLine("The wrong index");
                return;
            }

            Console.Write("Now, enter the new url: ");
            newUrl = Console.ReadLine();

            string pattern = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(newUrl))
            {
                Console.WriteLine("The wrong URL. Please try again");
                return;
            }

            _urls[index] = newUrl;

            Console.WriteLine("Success!");
        }

        private void CheckURLs()
        {
            Console.WriteLine("Your current urls:");
            foreach (string i in _urls)
            {
                Console.WriteLine($"\t{i}");
            }
            Console.WriteLine("\n");
        }

        private async Task doRequest(string url)
        {
            Stopwatch sw = new Stopwatch();
            HttpClient client = new HttpClient();
            HttpResponseMessage response;
            HttpStatusCode responseStatus;

            sw.Start();

            using (client)
            {
                try
                {
                    response = await client.GetAsync(url);
                    responseStatus = response.StatusCode;

                    response.EnsureSuccessStatusCode();

                    Console.WriteLine($"Success! Response to {url} has finished with status {responseStatus}");
                    Console.WriteLine($"Body: {response.Content.ReadAsStringAsync().Result}");
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error! Response to {url} has finished with status: {ex.StatusCode}");
                }
            }

            sw.Stop();
            TimeSpan sinceTime = sw.Elapsed;
            Console.WriteLine($"Program finished in {sinceTime.Seconds}:{sinceTime.Milliseconds} seconds\n\n");
        }

        private void Console_app()
        {
            int command = -1;

            Console.WriteLine("Hello, I'll help you to do three request to any servers");
            Console.WriteLine("You can add new urls or use default values\n");

            while (command != 0)
            {
                Console.WriteLine("\t1. Add new url");
                Console.WriteLine("\t2. Check all urls");
                Console.WriteLine("\t3. Do requests");
                Console.WriteLine("\t0. Exit");
                Console.Write("Please, enter the number of command: ");
                command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1: AddURL(); break;
                    case 2: CheckURLs(); break;
                    case 3:
                        {
                            Stopwatch sw = Stopwatch.StartNew();

                            Task firstTask = doRequest(_urls[0]);
                            Task secondTask = doRequest(_urls[1]);
                            Task thirdTask = doRequest(_urls[2]);

                            Task.WaitAll(firstTask, secondTask, thirdTask);

                            sw.Stop();
                            TimeSpan sinceTime = sw.Elapsed;
                            Console.WriteLine($"Total time: {sinceTime.Seconds}:{sinceTime.Milliseconds} seconds");
                            break;
                        }
                    case 0: Console.WriteLine("Exit..."); break;
                    default: Console.WriteLine("The wrong command. Please try again"); break;
                }
            }
        }
        public Second_console_app()
        {
            _urls = new List<string> { "http://localhost:8080/first_serve", "https://api.thecatapi.com/v1/images/search", "http://localhost:8080/first_serve" };

            Console_app();
        }
    }
}
