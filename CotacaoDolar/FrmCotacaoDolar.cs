using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CotacaoDolar
{
    public partial class FrmCotacaoDolar : Form
    {
        public FrmCotacaoDolar()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string strURl = "https://api.hgbrasil.com/finance?array_limit=1&fields=only_results,USD&key=dbe9b4bb";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(strURl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;

                        Market market = JsonConvert.DeserializeObject<Market>(result);

                        lblBuy.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Buy);
                        lblSell.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", market.Currency.Sell);
                        lblVar.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:P}", market.Currency.Variation / 100);
                    }
                    else
                    {
                        lblBuy.Text = "-";
                        lblSell.Text = "-";
                        lblVar.Text = "-";
                    }
                }
                catch (Exception ex)
                {
                    lblBuy.Text = "-";
                    lblSell.Text = "-";
                    lblVar.Text = "-";

                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
