using Rocket.API;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUyarı
{
    public class Config : IRocketPluginConfiguration
    {
        public string ChatMesaj { get; set; }
        public string Can { get; set; }
        public int MinimumCan { get; set; }
        public string ÖlümMEsajı { get; set; }
        public void LoadDefaults()
        {
            ChatMesaj = "Lütfen Chatte Saygılı Olunuz Ve Spamla Küfür ETMEYİNİZ!";
            Can = "Canın Kaldı! , Sağlık Ekipmanı bulun";
            MinimumCan = 30;
            ÖlümMEsajı = "Ahiretten Bize Yazarsın Artık";
        }
    }
}
