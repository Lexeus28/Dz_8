using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_File_8
{
    public class Project
    {
        public string description;
        public DateTime deadline;
        public string initiator;
        public TeamMember teamLead;
        public List<Task> tasks { get; private set; } = new List<Task>();
        public ProjectStatus status { get; set; } = ProjectStatus.Project;

        public void AddTask(Task task)
        {
            if (status != ProjectStatus.Project)
            {
                Console.WriteLine("Задачи можно добавлять только в статусе 'Проект'.");
                return;
            }
            tasks.Add(task);
        }

        public void ChangeStatus(ProjectStatus newStatus)
        {
            status = newStatus;
        }
    }
}
