using System.Globalization;
using System.IO;
using System.Xml;

namespace SomadorCFe
{
    public partial class PrincipalForm : Form
    {
        public string caminho = "";
        List<double> valoresVCfe = new List<double>();
        List<string> cfesCancelados = new List<string>();
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
                lblCaminho.Text = caminho;
                //MessageBox.Show("Caminho selecionado!" + "\n" + caminho, "Opa!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

                //Procura cancelados e põe na lista
                if (doc.DocumentElement.Name == "CFeCanc")
                {
                    XmlNode infCFeNode = doc.SelectSingleNode("//infCFe");
                    string idCancelado = infCFeNode.Attributes["chCanc"].Value;

                    cfesCancelados.Add(idCancelado);
                }

                soma = 0;

                //Percorre novamente os arquivos ignorando os cancelados
                foreach (string arquivo in arquivosXML)
                {
                    XmlDocument docu = new XmlDocument();
                    docu.Load(arquivo);

                    if (docu.DocumentElement.Name == "CFe")
                    {
                        XmlNode infCFeNode = docu.SelectSingleNode(".//infCFe");
                        string idCFe = infCFeNode.Attributes["Id"].Value;

                        if (!cfesCancelados.Contains(idCFe))
                        {
                            XmlNodeList elementos = docu.GetElementsByTagName("vCFe");
                            foreach (XmlNode elemento in elementos)
                            {
                                string valorString = elemento.InnerText;
                                if (double.TryParse(valorString, out double valorDouble)) { soma += valorDouble; }
                            }
                        }
                    }
                }
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