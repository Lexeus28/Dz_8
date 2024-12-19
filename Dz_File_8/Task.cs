using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dz_File_8
{
    public class Task
    {
        public string description;
        public DateTime deadline;
        public string initiator;
        public TeamMember assignee;
        public TaskStatus status { get; set; } = TaskStatus.Assigned;
        public Report taskReport { get; private set; }

        public Task(string description, DateTime deadline, string initiator, TeamMember assignee)
        {
            this.description = description;
            this.deadline = deadline;
            this.initiator = initiator;
            this.assignee = assignee;
        }

        public void AssignTo(TeamMember member)
        {
            assignee = member;
            status = TaskStatus.Assigned;
        }
        public void StartWork()
        {
            if (assignee == null)
            {
                Console.WriteLine("Задача не назначена исполнителю.");
                return;
            }
            status = TaskStatus.InProgress;
        }

        public void SubmitReport(string reportText)
        {
            if (status != TaskStatus.InProgress)
            {
                Console.WriteLine("Отчет можно отправить только в статусе 'В работе'.");
                return;
            }
            taskReport = new Report
            {
                text = reportText,
                completionDate = DateTime.Now,
                author = assignee
            };
            status = TaskStatus.InReview;
        }

        public void ApproveReport()
        {
            if (taskReport == null)
            {
                Console.WriteLine("Отчёт не отправлен.");
                return;
            }
            status = TaskStatus.Completed;
        }
    }
}
