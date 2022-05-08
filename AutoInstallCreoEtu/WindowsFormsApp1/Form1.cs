using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private string link = "https://download.utc.fr/index.php/download/creo-v4-0/?wpdmdl=11";
        private string folder_to_delete = "C:\\ProgramData\\PTC\\Licensing";
        private string zip_folder = Path.GetFullPath(@"MED-100WIN-CD-410_M040_Win64.zip");
        private string unzipped_folder = Path.GetFullPath(@".\UnzippedFolder");
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(zip_folder))
            {
                Directory.Delete(folder_to_delete, true);
            }
            if (Directory.Exists(unzipped_folder))
            {
                Directory.Delete(unzipped_folder, true);
            }

            //MessageBox.Show(zip_folder);
            if (File.Exists(zip_folder))
            {
                ZipFile.ExtractToDirectory(zip_folder, unzipped_folder);
            }
            else
            {
                MessageBox.Show("Le zip ne se trouve pas dans le meme repertoire que le .exe ! Merci de le telecharger et de le mettre dans le meme repertoire avec le nom : MED-100WIN-CD-410_M040_Win64.zip");
            }
            Process.Start(unzipped_folder + "\\setup.exe", "readme.txt");
            MessageBox.Show("Veuillez cliquer sur : Installer un nouveau logiciel puis Suivant");
            MessageBox.Show("Acceptez le contract de license et l'accord d'exportation et appuyez sur suivant");
            MessageBox.Show("Entrez la licence Entrer la licence BK410705EDSTUDENTUNICL dans le champ Product code");
            MessageBox.Show("Cliquer ensuite sur Install licensing.");
            MessageBox.Show("Connectez vous à votre compte PTC(si vous n'en avez pas crée, vous pouvez le créer ici : https://support.ptc.com/appserver/common/account/createAccount.jsp?tab=student) puis appuyez sur Login");
            MessageBox.Show("Lorsque vous voyez le message Success! cliquez sur Next");
            MessageBox.Show("Cliquez sur Install");
            MessageBox.Show("L'installation va se lancer. Quand elle sera terminée appuyez sur Finish");
            Environment.SetEnvironmentVariable("PTC_PMA_HC_URL_4", "https://documentations.utc.fr/creodoc/Creo4.0/help/creo_help_pma/");
            if (Directory.Exists("C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\formats"))
            {
                Directory.Delete("C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\formats", true);
            }
            
            Directory.Move("Installation creo 4.0_M040[4]\\formats", "C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\formats");
            if (File.Exists("C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\text\\config.pro"))
            {
                File.Delete("C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\text\\config.pro");
            }
            File.Move("Installation creo 4.0_M040[4]\\config.pro", "C:\\Program Files\\PTC\\Creo 4.0\\M040\\Common Files\\text\\config.pro");
        
        }
    }
}
