using Newtonsoft.Json;

namespace BlazorOrnek1.Data;
public class Kisi
{
    public Kisi() { }
    public Kisi
    (string adi, string soyadi, string cinsiyeti,
                        string dYeri, int dYili)
                => (Adi, Soyadi, Cinsiyeti, DogumYeri, DogumYili) =
                        (adi, soyadi, cinsiyeti, dYeri, dYili);

    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public string Cinsiyeti { get; set; }
    public string DogumYeri { get; set; }
    public int DogumYili { get; set; }

    public List<Kisi> KisilerListesi()
    {
        string path = @"D:\GitHub\CSharp11\Projelerim\AllConsoleProjects\BlazorOrnek1\Data\Kisi.json";
        var kisiler =
            JsonConvert.DeserializeObject<KisiJsonResponse>(File.ReadAllText(path));
        //List<Kisi> kisiler = new List<Kisi>
        //{
        //    new("Süleyman", "UZUNKÖPRÜ", "Erkek", "Tekirdağ",1976),
        //    new ("Ahmet", "UZUNKÖPRÜ", "Erkek","İstanbul", 2012),
        //    new ("Ayşe", "UZUNKÖPRÜ","Kız", "Sakarya", 2014)
        //};
        HttpClient httpClient = new HttpClient();
        //var response = httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").Result;
        //var result = response.Content.ReadAsStringAsync().Result;
        //var posts = JsonConvert.DeserializeObject<List<Post>>(result);

        //var response = httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts/1").Result;
        //var result = response.Content.ReadAsStringAsync().Result;
        //var posts = JsonConvert.DeserializeObject<Post>(result);
        return kisiler.Data;
    }
    public class KisiJsonResponse
    {
        public List<Kisi> Data { get; set; }
    }

    public class Post
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
