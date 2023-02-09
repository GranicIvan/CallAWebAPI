using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CallAWebAPI
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("POCEKAT PROGRAMA!");


            Console.WriteLine("Upisite vase ime");
            string ime = Console.ReadLine();

            poziv2Async(ime);



            Console.WriteLine(" --- KRAJ PROGRAMA! ---");
        }


        static void poziv1(string ime)
        {

            Console.WriteLine("Pocetak metode poziv");

            string adresa = "https://phonebookivan.azurewebsites.net/api/HttpTriggerTest1?code=uEZgqfXnyqPD-jC5P82E4UP-X6VGQAK_79XYPJnA459nAzFuZfVypA==";


            // Ako ime nije prazno dodajemo ime na string 
            if (!String.IsNullOrEmpty(ime))
            {
                adresa += ("&name=" + ime);

            }


            // Create a request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(adresa);
            request.Method = "GET";

            // Send the request
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Read the response
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();

            // Print the response
            Console.WriteLine("\n" + responseString + "\n");

            Console.WriteLine("Kraj metode poziv");
        }



        static async Task poziv2Async(string ime)
        {
            Console.WriteLine("Pocetak metode poziv2Async");

            HttpClient httpClient = new();

            string adresa = "https://phonebookivan.azurewebsites.net/api/HttpTriggerTest1?code=uEZgqfXnyqPD-jC5P82E4UP-X6VGQAK_79XYPJnA459nAzFuZfVypA==";

            // Ako ime nije prazno dodajemo ime na string 
            if (!String.IsNullOrEmpty(ime))
            {
                adresa += ("&name=" + ime);

            }


            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            httpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");


            Console.WriteLine("X");
            var json = await httpClient.GetStringAsync(adresa);

            Console.Write(json);




            Console.WriteLine("Kraj metode poziv2Async");


        }

    }


}


