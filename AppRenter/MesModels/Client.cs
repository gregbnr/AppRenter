using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace AppRenter.MesModels
{
  public class Client
  {
    [JsonProperty("idCl")]
    public string idCl { get; set; }
    [JsonProperty("civiliteCl")]
    public string civiliteCl { get; set; }
    [JsonProperty("nomCl")]
    public string nomCl { get; set; }
    [JsonProperty("prenomCl")]
    public string prenomCl { get; set; }
    [JsonProperty("dateNaissCl")]
    public string dateNaissCl { get; set; }
    [JsonProperty("adresseCl")]
    public string adresseCl { get; set; }
    [JsonProperty("CPCl")]
    public string CPCl { get; set; }
    [JsonProperty("villeCl")]
    public string villeCl { get; set; }
    [JsonProperty("nationaliteCl")]
    public string nationaliteCl { get; set; }
    [JsonProperty("mailCl")]
    public string mailCl { get; set; }
    [JsonProperty("telCl")]
    public string telCl { get; set; }
    [JsonProperty("loginCl")]
    public string loginCl { get; set; }
    [JsonProperty("pwdCl")]
    public string pwdCl { get; set; }
  }
}
