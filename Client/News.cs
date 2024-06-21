using Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class News : Form
    {
        private ClientRepository _clentRepo;

        public News()
        {
            InitializeComponent();
            _clentRepo = new ClientRepository();
        }

        private void News_Load(object sender, EventArgs e)
        {
            if (_clentRepo.newsId == 1)
            {
                TitleL.Text = "Hamburg police shoot man with axe ahead of Euros match";
                ContentTB.Text = "A major operation has taken place in central Hamburg after a man with an axe threatened police officers, officials in the German city say.\r\nPolice say they shot and seriously injured the man, who is receiving medical attention.\r\nMedia reports say the incident took place near a fanzone for supporters of the Dutch football team.\r\nThe Netherlands faced Poland in the city in the Euro 2024 tournament on Sunday.\r\nAn initial police statement said that a man threatened police officers with a pickaxe and an \"incendiary device\".\r\nLater, a Hamburg police spokesperson told the BBC the suspect was armed with a pickaxe and had tried to ignite a petrol bomb – but that officers responded with pepper spray and then shot him.\r\nThe incident is understood to have taken place at around 12:30 local time (10:30 GMT).\r\nVideo footage posted online, shows a man wielding an axe in front of police officers before a series of suspected gunshot sounds can be heard.\r\nThe man has not been identified by the police and the authorities have not commented on what motivations they believe were behind the incident.";
            }
            else if (_clentRepo.newsId == 2)
            {
                TitleL.Text = "Ashes pain forgiven? England rescued by old foe";
                ContentTB.Text = "Alex Carey, David Warner, Steve Smith and all of that Ashes pain - England fans forgive you.\r\nFor Scotland, this was T20 World Cup heartache - with Chris Sole's dropped catch in the final over only adding to 36 hours of cruel sporting misery.\r\nFor England, Australia’s gripping victory against Scotland - which knocked out the Scots and sent Jos Buttler’s side through to the Super 8s - offered pure relief, served up by their oldest cricketing rivals.\r\nLast summer Travis Head was pounding England bowlers in an attempt to win back the Ashes urn.\r\nHe was in the middle on that final day at The Oval with Smith, the pair threatening to take Australia home before Stuart Broad’s grand finale.\r\nEighteen months earlier, during England’s most recent venture down under, Head flogged Ben Stokes et al around Brisbane in a blistering century.\r\nIt was only the second day of the series, but England would never recover from it."; 
            }
            else
            {
                TitleL.Text = "Hamburg police shoot man with axe ahead of Euros match";
                ContentTB.Text = "A major operation has taken place in central Hamburg after a man with an axe threatened police officers, officials in the German city say.\r\nPolice say they shot and seriously injured the man, who is receiving medical attention.\r\nMedia reports say the incident took place near a fanzone for supporters of the Dutch football team.\r\nThe Netherlands faced Poland in the city in the Euro 2024 tournament on Sunday.\r\nAn initial police statement said that a man threatened police officers with a pickaxe and an \"incendiary device\".\r\nLater, a Hamburg police spokesperson told the BBC the suspect was armed with a pickaxe and had tried to ignite a petrol bomb – but that officers responded with pepper spray and then shot him.\r\nThe incident is understood to have taken place at around 12:30 local time (10:30 GMT).\r\nVideo footage posted online, shows a man wielding an axe in front of police officers before a series of suspected gunshot sounds can be heard.\r\nThe man has not been identified by the police and the authorities have not commented on what motivations they believe were behind the incident.";
            }
        }
    }
}
