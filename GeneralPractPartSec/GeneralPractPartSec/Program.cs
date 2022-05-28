using System;
using System.Collections.Generic;
using GeneralPractPartSec.Models;

namespace GeneralPractPartSec
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("User1");
            int choice;
            do
            {
                Console.WriteLine("Menu\n" +
                    "1.Share status\n" +
                    "2.Get all statuses\n" +
                    "3.Get status by id\n" +
                    "4.Filter status by date\n" +
                    "5.Get Status Info\n" +
                    "0.Quit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Add a status");
                        string title = Console.ReadLine();
                        Console.WriteLine("Add a theme");
                        string content = Console.ReadLine();
                        Status status = new Status(title,content);
                        user.ShareStatus(status);
                        break;
                    case 2:
                        Console.WriteLine("All statuses");
                        foreach (var item in user.GetAllStatuses())
                        {
                            Console.WriteLine($"Title:{item.Title}\nContent:{item.Content}\nSharedDate:{item.SharedDate}");
                        }

                        break;
                    case 3:
                        Console.WriteLine("Enter an Id");
                        int statusId = Convert.ToInt32(Console.ReadLine());
                        var userStatus=user.GetStatusById(statusId);
                        Console.WriteLine($"Title:{userStatus.Title}\nContent:{userStatus.Content}\nSharedDate:{userStatus.SharedDate}");
                        break;
                    case 4:
                        Console.WriteLine("Enter Date");
                        DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Enter an Id");
                        int userId = Convert.ToInt32(Console.ReadLine());
                        List<Status> filterStatus = user.FilterStatusByDate(dateTime, userId);
                        foreach (var item in filterStatus)
                        {
                            Console.WriteLine($"Title:{item.Title}\nContent:{item.Content}\nShareDate:{item.SharedDate}");
                        }          
                        break;
                    case 5:
                        Console.WriteLine("Enter an Id");
                        int Id = Convert.ToInt32(Console.ReadLine());
                        user.GetStatusInfo(Id);
                        break;
                    default:
                        break;
                }
            } while (choice != 0);
        }
    }
}
