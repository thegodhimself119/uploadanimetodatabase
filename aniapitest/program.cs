using aniapitest;
using Newtonsoft;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Channels;
using System.IO;

namespace Program;


class Program
{   static  List<string> genre = new List<string>();
    public static void getlist()
    {
        foreach(string line in System.IO.File.ReadLines("read.txt"))
        {
            genre.Add(line);
        }
    }

    public static void Main(string[] args)

    {
        getlist();

        int pagecount = 0;
        bool flag = false;
        int count = 1;
        for (int i = 0; i < genre.Count; i++) {
            try
            {
                while (flag == false)
                {

                    var client = new RestClient($"https://gogoanime.consumet.org/genre/{genre[i]}");
                    var request = new RestRequest();
                    addtodatabase obj1 = new addtodatabase();
                    request.AddParameter("page", pagecount);
                    var response = client.Execute(request);
                    JArray obj = JArray.Parse(response.Content);

                    for (int j = 0; j < obj.Count; j++)
                    {
                        string nam = (string)obj[j]["animeTitle"];
                        string img = (string)obj[j]["animeImg"];
                        string date = (string)obj[j]["releasedDate"];
                        string link = (string)obj[j]["animeUrl"];
                        string gen = genre[i];

                     
                        obj1.adddata(count, nam, date, link, img, gen);
                        count++;
                    }
                    pagecount++;
                    Console.WriteLine(pagecount);

                }
            }
            catch (Exception ex)
            {
                pagecount = 0;
            }
            Console.WriteLine($"{genre[i]}done");
        }









        Console.ReadLine();

       
        
        
        

    }
}