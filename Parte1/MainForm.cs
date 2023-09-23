using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Part1.Shared.Request;
using Part1.Shared.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parte1
{
    public partial class MainForm : Form
    {
        private List<int> _divisores = new List<int>();

        private List<int> _divisoresPrimos = new List<int>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void decomporButton_Click(object sender, EventArgs e)
        {
            if (valorTextBox.Text == string.Empty)
            {
                MessageBox.Show(Mensagens.Warning_InsiraUmValor, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(valorTextBox.Text, out _) || valorTextBox.Text == int.MaxValue.ToString())
            {
                MessageBox.Show(string.Format(Mensagens.Warning_ValorMaximo, (int.MaxValue - 1)), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!executarBackgroundWorker.IsBusy)
            {
                decomporButton.Enabled = false;
                valorTextBox.Enabled = false;
                executarBackgroundWorker.RunWorkerAsync(valorTextBox.Text);
            }
        }

        private void valorTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar != '\b' && e.KeyChar != '\r');
        }

        private void executarBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);
                var result = httpClient.GetAsync($"/Api/Calculo/Decompor?numero={e.Argument}").GetAwaiter().GetResult();
                var json = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(string.Format(Mensagens.Erro_Requisicao, result.ReasonPhrase), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var responseDivisores = JsonConvert.DeserializeObject<Response<List<int>>>(json);

                if (!responseDivisores.Sucess)
                {
                    MessageBox.Show(responseDivisores.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                RemoverNumerosNaoPrimosRequest removerNumerosNaoPrimosRequest = new RemoverNumerosNaoPrimosRequest();
                removerNumerosNaoPrimosRequest.Numeros = responseDivisores.Data;
                result = httpClient.PostAsJsonAsync("/Api/Calculo/RemoverNumerosNaoPrimos", removerNumerosNaoPrimosRequest).GetAwaiter().GetResult();
                json = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show(string.Format(Mensagens.Erro_Requisicao, result.ReasonPhrase), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var responseDivisoresPrimos = JsonConvert.DeserializeObject<Response<List<int>>>(json);

                if (!responseDivisoresPrimos.Sucess)
                {
                    MessageBox.Show(responseDivisoresPrimos.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _divisores = responseDivisores.Data;
                _divisoresPrimos = responseDivisoresPrimos.Data;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void executarBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            decomporButton.Enabled = true;
            valorTextBox.Enabled = true;
            divisoresRichTextBox.Text = ConcatenarVirgula(_divisores);
            divisoresPrimosRichTextBox.Text = ConcatenarVirgula(_divisoresPrimos);
        }

        private string ConcatenarVirgula(List<int> numeros)
        {
            var result = string.Empty;
            for (int x = 0; x < numeros.Count; x++)
            {
                if (x == numeros.Count - 1)
                    result += numeros[x];
                else
                    result += $"{numeros[x]}, ";
            }
            return result;
        }
    }
}
