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
        /// <summary>
        /// Title of project
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Description of Project.
        /// </summary>
        public string Description { get; set; }
/// <summary>
/// Checks the uniquness of Project. Title should not be repeated
/// </summary>
/// <param name="cmd">command that will be executed in order to check the uniquness</param>
/// <returns>true if project is unique else false</returns>
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
