using System.Collections.Generic;

namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Models;

public class CatBreedsResponse
{
    public int current_page { get; set; }
    public List<CatsBreed> data { get; set; }
    public string first_page_url { get; set; }
    public int from { get; set; }
    public int last_page { get; set; }
    public string last_page_url { get; set; }
    public List<Link> links { get; set; }
    public string next_page_url { get; set; }
    public string path { get; set; }
    public int per_page { get; set; }
    public object prev_page_url { get; set; }
    public int to { get; set; }
    public int total { get; set; }
}

