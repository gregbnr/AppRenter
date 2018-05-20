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
  public class Commercial
  {
    [JsonProperty("idCom")]
    public string idCom { get; set; }
    [JsonProperty("nomCom")]
    public string nomCom { get; set; }
    [JsonProperty("prenomCom")]
    public string prenomCom { get; set; }
    [JsonProperty("loginCom")]
    public string loginCom { get; set; }
    [JsonProperty("pwdCom")]
    public string pwdCom { get; set; }
  }
}
