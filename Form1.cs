using System.Globalization;
using System.IO;
using System.Xml;

namespace SomadorCFe
{
    public partial class PrincipalForm : Form
    {
        public string caminho = "";
        List<double> valoresVCfe = new List<double>();
        public double soma = 0;

        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void btnEscolhePasta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdBrowserPasta = new FolderBrowserDialog();
            if (fbdBrowserPasta.ShowDialog() == DialogResult.OK)
            {
                caminho = fbdBrowserPasta.SelectedPath;
                MessageBox.Show("Caminho selecionado!" + "\n" + caminho, "Opa!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void percorreSoma()
        {
            string[] arquivosXML = Directory.GetFiles(caminho, "*.xml");

            foreach (string file in arquivosXML)
            {
                //Lê o arquivo XML
                XmlDocument doc = new XmlDocument();
                doc.Load(file);

                //Obtém elemtnos com a tag <vCfe>
                XmlNodeList elementos = doc.GetElementsByTagName("vCFe");

                // Itera sobre os elementos encontrados
                foreach (XmlNode elemento in elementos)
                {
                    // Obtém o valor da tag "<vCfe>"
                    string valorString = elemento.InnerText;

                    // Converte o valor para double
                    if (double.TryParse(valorString, out double valorDouble)) { valoresVCfe.Add(valorDouble); }
                }
                //Percorre lista e soma os valores
                soma = 0;
                foreach (double valor in valoresVCfe) { soma += valor; }
            }
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            soma = 0;
            percorreSoma();

            // Divide o valor por 100 antes de formatá-lo
            double valorFormatado = soma / 100;

            // Define as opções de formatação
            NumberFormatInfo formatoValor = new NumberFormatInfo();
            formatoValor.CurrencySymbol = "R$";
            formatoValor.NumberGroupSeparator = ".";
            formatoValor.NumberDecimalSeparator = ",";

            // Formata o valor para exibição
            string valorFormatadoString = valorFormatado.ToString("N2", formatoValor);

            lblResultado.Text = ("Total: R$ " + valorFormatadoString);
        }
    }
}