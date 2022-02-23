using System;
using System.Collections.Generic;
using System.Reflection;
using CSM.API;
using CSM.API.Commands;
using CSM.Commands;
using CSM.Helpers;
using CSM.Util;

namespace CSM.Mods
{
    class ModSupport
    {
        List<Connection> connectedMods;
        public void registerCommandSenders()
        {
            connectedMods = new List<Connection>();
            IEnumerable<Type> handlers = ReflectionHelper.FindClassesInMods(typeof(Connection));

            foreach (var handler in handlers)
            {
                Connection connectionInstance = (Connection) Activator.CreateInstance(handler);
                connectionInstance.ConnectToCSM(SendToClient, SendToClient2, SendToClients, SendToOtherClients,
                    SendToServer, SendToAll);
            }
        }

        public bool SendToClient(NetPeer peer, CommandBase command)
        {
            // Command.sendToClient(peer, command);

            return true;
        }

        public bool SendToClient2(Player player, CommandBase command)
        {
            // Command.sendToClient(player, command);
            return true;
        }

        public bool SendToClients(CommandBase command)
        {
            // Command.sendToClients(command);

            return true;
        }

        public bool SendToOtherClients(CommandBase command, Player exclude)
        {
            // Command.sendToOtherClients(command, exclude);

            return true;
        }

        public bool SendToServer(CommandBase command)
        {
            // Command.sendToServer(command);

            return true;
        }

        public bool SendToAll(CommandBase command)
        {
            // Command.sendToAll(command);

            return true;
        }
        public bool SendToServer(CommandBase command)
        {
            Command.SendToServer(command);
            return false;
        }
    }
}