using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManageModel;
using StudentManageDAL;
namespace StudentManageBLL
{
    public class AdminManager
    {
        AdminServer admserver = new AdminServer();
       public Admins GetAdmins(Admins adm)
        {
            return admserver.GetAdmins(adm);
        }
    }
}
