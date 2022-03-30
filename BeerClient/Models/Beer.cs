using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BeerClient.Models
{
  public class Beer
  {
    public int BeerId { get; set; }
    public string Name { get; set; }
    public string Brewery { get; set; }
    public string Style { get; set; }
    public double Abv { get; set; }

    public static List<Beer> GetBeers()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Beer> beerList = JsonConvert.DeserializeObject<List<Beer>>(jsonResponse.ToString());

      return beerList;
    }
    public static Beer GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Beer beer = JsonConvert.DeserializeObject<Beer>(jsonResponse.ToString());

      return beer;
    }
    public static void Post(Beer beer)
    {
      string jsonBeer = JsonConvert.SerializeObject(beer);
      var apiCallTask = ApiHelper.Post(jsonBeer);
    }
    public static void Put(Beer beer)
    {
      string jsonBeer = JsonConvert.SerializeObject(beer);
      var apiCallTask = ApiHelper.Put(beer.BeerId, jsonBeer);
    }
    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
    public static Beer Random()
    {
      var apiCallTask = ApiHelper.Random();
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Beer beer = JsonConvert.DeserializeObject<Beer>(jsonResponse.ToString());

      return beer;
    }
  }
}