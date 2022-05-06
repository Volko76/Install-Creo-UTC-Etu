import os
import shutil
from os.path import exists
import requests
from zipfile import ZipFile

print("Installation de Créo v4.0 étudiant UTC Attention, ce programme automatise une partie de l\'installation de Creo : (Le téléchargement, l\'extraction, la suppression des anciennes clées et versions de Créo, le lancement du programme d\'installation et la création des variables d\'environnement)")
link = 'https://download.utc.fr/index.php/download/creo-v4-0/?wpdmdl=11&refresh=6274336db21461651782509'
#link = "https://www.learningcontainer.com/wp-content/uploads/2020/05/sample-large-zip-file.zip"
folder_to_delete = "C:\ProgramData\PTC\Licensing"
zip_folder = "MED-100WIN-CD-410_M040_Win64.zip"
unzipped_folder = "UnzippedFolder"

#Suppression des parties indésirables
if exists(folder_to_delete):
   shutil.rmtree(folder_to_delete, ignore_errors=False, onerror=None)
# if exists(zip_folder):
#    os.remove(zip_folder)
if exists(unzipped_folder):
   os.remove(unzipped_folder)

# r = requests.get(link, allow_redirects=True)
#
# open(zip_folder, 'wb').write(r.content)

with ZipFile(zip_folder, 'r') as zipObj:
   # Extract all the contents of zip file in current directory
   zipObj.extractall(unzipped_folder)
os.startfile(unzipped_folder + "\setup.exe")
print("Veuillez cliquer sur : Installer un nouveau logiciel puis Suivant")
print("Acceptez le contract de license et appuyez sur suivant")
print("Entrez la licence Entrer la licence BK410705EDSTUDENTUNICL dans le champ Product code")
print("Cliquer ensuite sur Install licensing.")
print("Connectez vous à votre compte PTC (si vous n'en avez pas crée, vous pouvez le créer ici : https://support.ptc.com/appserver/common/account/createAccount.jsp?tab=student) puis appuyez sur Login")
print("Lorsque vous voyez le message Success! cliquez sur Next")
print("Cliquez sur Install")
print("L'installation va se lancer. Quand elle sera terminée appuyez sur Finish")

os.environ["PTC_PMA_HC_URL_4"] =  "https://documentations.utc.fr/creodoc/Creo4.0/help/creo_help_pma/"
shutil.copyfile("Installation creo 4.0_M040[4]\config.pro", "C:\Program Files\PTC\Creo 4.0\M040\Common Files\\text\config.pro")
shutil.copyfile("Installation creo 4.0_M040[4]\\formats", "r C:\Program Files\PTC\Creo 4.0\M040\Common Files\\formats")
