using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CotacaoDolar
{
    public class Market
    {
        public Market() 
        {
            this.Currency = new Currency();
        }
        [JsonProperty(PropertyName = "currencies")]
        public Currency Currency { get; set; }
    }
}
