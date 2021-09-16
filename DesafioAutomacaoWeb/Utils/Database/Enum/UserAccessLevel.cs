using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAutomacaoWeb.Utils.Database.Enum
{
    public enum UserAccessLevel
    {
        Administrator = 90,
        Manager = 70,
        Developer = 55,
        Updater = 40,
        Reporter = 25,
        Viewer = 10
    }
}
