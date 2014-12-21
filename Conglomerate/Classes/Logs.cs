using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conglomerate.Classes
{
    class Logs
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        public void createLogEvent(string prefix, string username, string action, string page)
        {
            string query = "Insert into dbo." + prefix + "_Logs(Username,Action,Page,DT) Values('" + username + "','" + action + "','" + page + "','" + DateTime.Now.ToString() + "')";
            q.ExecuteGenQuery(query);
        }
    }
}
