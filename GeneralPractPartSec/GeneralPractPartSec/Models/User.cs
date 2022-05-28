using System;
using System.Collections.Generic;
using Custom_Exceptions.Exceptions;

namespace GeneralPractPartSec.Models
{
    public class User
    {
        public int Id { get; }
		private int _id;
        public string UserName{ get; set; }
		public List<Status> _statuses;

        public User(string userName)
        {
			_id++;
			Id = _id;
			UserName = userName;
			_statuses = new List<Status>();

		}

		public void GetStatusInfo(int id)
		{
			Status status = _statuses.Find(s => s.Id == id);
			Console.WriteLine($"Title:{status.Title}\nContent:{status.Content}\nShared:{status.SharedDate - DateTime.Now} ago");
		}

		public void ShowInfo()
        {
            Console.WriteLine($"UserName:{UserName}\nStatusCount:{_statuses.Count}");
        }

		public void ShareStatus(Status status)
        {
			_statuses.Add(status);
            Console.WriteLine("\nStatus Shared:");
			return;
		}

		public Status GetStatusById(int? id)
		{
			if (id == null)
			{
				throw new NullReferenceException("Status Not Found");
			}


			Status status = _statuses.Find(s => s.Id == id );
			if (status == null)
			{
				throw new NotFoundException("Status Not Found");

			}
			return status;
		}

		public List<Status> GetAllStatuses()
		{
			List<Status> statusCopy = new List<Status>();
            if (_statuses is null)
            {
				throw new NotFoundException("User Status Not Found");
            }
			statusCopy.AddRange(_statuses);

			return statusCopy;
		}

		public List<Status> FilterStatusByDate(DateTime dateTime,int userId)
		{
			return _statuses.FindAll(s=>s.Id == userId && s.SharedDate >= dateTime);
		}


	}
}
