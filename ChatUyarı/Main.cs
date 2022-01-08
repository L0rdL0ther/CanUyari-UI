using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatUyarı
{
    public class Main : RocketPlugin <Config>
    {
        public static Main Instance { get; private set; }
        protected override void Load()
        {
            UnturnedPlayerEvents.OnPlayerUpdateHealth += can;
            UnturnedPlayerEvents.OnPlayerDeath += öldün;
            UnturnedPlayerEvents.OnPlayerRevive += dirildi;
            U.Events.OnPlayerConnected += Bağlandı;
            Instance = this;
            Logger.Log("***************************************|");
            Logger.Log("                                       |");
            Logger.Log("     Babanenizin en sevdiği plugin     |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log($"{name}{Assembly.GetName().Version} Chat Uyarı |Anancılık plugin|");
            Logger.Log("                                       |");
            Logger.Log("               Vidanjör                |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log(" Dikkat Babennize Bağımlılık yapabilir |");
            Logger.Log("                                       |");
            Logger.Log("***************************************|");
        }

        

        private void can(UnturnedPlayer player, byte health)
        {
            var c = Configuration.Instance;                      
             if (player.Health <= c.MinimumCan)
            {
                EffectManager.sendUIEffect(22000, 22, player.SteamPlayer().transportConnection, false, $"{player.Health} {c.Can}");
                return;
            }
             else
            {
                EffectManager.askEffectClearByID(22000, player.SteamPlayer().transportConnection);
                return;
            }
            
        }
         private void öldün(UnturnedPlayer player, EDeathCause cause, ELimb limb, CSteamID murderer)
        {
            var c = Configuration.Instance;
            EffectManager.askEffectClearByID(22000, player.SteamPlayer().transportConnection);
            EffectManager.sendUIEffect(22000, 22, player.SteamPlayer().transportConnection, false, c.ÖlümMEsajı);

        }
         private void dirildi(UnturnedPlayer player, UnityEngine.Vector3 position, byte angle)
        {
            EffectManager.askEffectClearByID(22000, player.SteamPlayer().transportConnection);
        }
        private void Bağlandı(UnturnedPlayer player)
        {
            UnturnedChat.Say(player, $"{player.DisplayName}{Configuration.Instance.ChatMesaj}");
        }

        protected override void Unload()
        { 
            UnturnedPlayerEvents.OnPlayerUpdateHealth -= can;
            UnturnedPlayerEvents.OnPlayerDeath -= öldün;
            UnturnedPlayerEvents.OnPlayerRevive -= dirildi;
            U.Events.OnPlayerConnected -= Bağlandı;
            Instance = null;
            Logger.Log("***************************************|");
            Logger.Log("                                       |");
            Logger.Log("     Babanenizin en sevdiği plugin     |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log($"{name}{Assembly.GetName().Version} Plugin Başarılı Bir Şekilde Unload Olmuştur|Anancılık plugin|");
            Logger.Log("                                       |");
            Logger.Log("               Vidanjör                |");
            Logger.Log("                                       |");
            Logger.Log("                                       |");
            Logger.Log(" Dikkat Babennize Bağımlılık yapabilir |");
            Logger.Log("                                       |");
            Logger.Log("***************************************|");
        }

    }
}
