using System;
using System.Threading.Tasks;
namespace Dz_File_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Task();
        }
        static void Task()
        {
            List<TeamMember> team = new List<TeamMember>
        {
            new TeamMember { name = "Алексей" },
            new TeamMember { name = "Григорий" },
            new TeamMember { name = "Никита" },
            new TeamMember { name = "Дмитрий" },
            new TeamMember { name = "Анжела" },
        };
            Project project = new Project
            {
                description = "Улучшить код",
                deadline = DateTime.Now.AddMonths(1),
                initiator = "Company CEO",
                teamLead = team[0]
            };
            Console.WriteLine("Создание проекта...");
            Console.WriteLine($"Проект: {project.description}");
            Console.WriteLine($"Сроки: {project.deadline}");
            Console.WriteLine($"Инициатор: {project.initiator}");
            Console.WriteLine($"Тимлид: {project.teamLead.name}");
            Console.WriteLine("Создаем задачи для проекта...");
            for (int i = 0; i < team.Count; i++)
            {
                Task task = new Task($"Улучшение кода", DateTime.Now.AddDays(7), project.teamLead.name, team[i]);
                project.AddTask(task);
                Console.WriteLine($"\nЗадача {i + 1}: {task.description} назначена {task.assignee.name}");
            }
            Console.WriteLine("\nМеняем статус проекта на 'Исполнение'...");
            project.ChangeStatus(ProjectStatus.Execution);
            foreach (var task in project.tasks)
            {
                Console.WriteLine($"\nИсполнитель {task.assignee.name} начал работу над задачей: {task.description}");
                task.StartWork();
                task.SubmitReport($"Completed work on {task.description}.");
                task.ApproveReport();
                Console.WriteLine($"Задача {task.description} завершена.");
            }
            if (project.tasks.All(t => t.status == TaskStatus.Completed))
            {
                project.ChangeStatus(ProjectStatus.Closed);
            }
            Console.WriteLine($"\nПроект \"{project.description}\" закрыт: {project.status == ProjectStatus.Closed}");
        }
            
    }
}