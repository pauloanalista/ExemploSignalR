using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace AppNotification.WindowsService.Hubs
{
    public class ApplicationAbcHub : Hub
    {
        /// <summary>
        /// Add a connection to the specified group
        /// </summary>
        /// <param name="groupName">Ex: tcp/udp</param>
        /// <returns>Task IGroupManager</returns>
        public Task JoinGroup(string groupName)
        {
            return Groups.Add(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// Remove a connection from the specified group
        /// </summary>
        /// <param name="groupName">Ex: tcp/udp</param>
        /// <returns>Task IGroupManager</returns>
        public Task LeaveGroup(string groupName)
        {
            return Groups.Remove(Context.ConnectionId, groupName);
        }

        /// <summary>
        /// send message to the specified group
        /// </summary>
        /// <param name="groupName">Ex: tcp/udp</param>
        /// <param name="message">Message</param>
        public void SendMessage(string groupName, object message)
        {
            Clients.Group(groupName).sendMessage(message);
        }
    }
}
