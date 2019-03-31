using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication23
{
    class Project
    {
        public static List<Project> Projects = new List<Project>();
        public string Title { get; set; }
        public string Description { get; set; }
/// <summary>
/// Checks the uniquness of Project. Title should not be repeated
/// </summary>
/// <param name="cmd"></param>
/// <returns></returns>
        public bool uniqueproject(string cmd)
        {
            int yo = dbConnection.getInstance().getScalerData(cmd);
            if(yo >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
