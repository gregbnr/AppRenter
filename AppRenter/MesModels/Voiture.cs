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
  public class Voiture
  {
    [JsonProperty("idVoit")]
    public string idVoit { get; set; }
    [JsonProperty("nomVoit")]
    public string nomVoit { get; set; }
    [JsonProperty("marqueVoit")]
    public string marqueVoit { get; set; }
    [JsonProperty("matriculeVoit")]
    public string matriculeVoit { get; set; }
  }
}
