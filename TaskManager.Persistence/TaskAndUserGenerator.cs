using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
using TaskManager.Domain;

namespace TaskManager.Persistence
{
    public class TaskAndUserGenerator
    {
        public List<User> Users { get; set; }
        public List<Task> Tasks { get; set; }

        public void GenerateUserAndTaskLists()
        {
            List<User> users = new List<User>();
            RandomData randomData = new();
            Random rand = new();
            for (int i = 1; i <= 5; i++)
            {
                DateTime ñreationDate = DateTime.MinValue;
                DateTime lastChangeDate = DateTime.MinValue;
                do
                {
                    ñreationDate = randomData.RandomDay().AddDays(-20);
                    lastChangeDate = randomData.RandomDay().AddDays(-5);
                }
                while (lastChangeDate < ñreationDate
                || ñreationDate == DateTime.MinValue
                || lastChangeDate == DateTime.MinValue);

                string name = randomData.GetRandomName();
                User user = new()
                {
                    UserId = i,
                    Name = name,
                    Surname = randomData.GetRandomSurname(name),
                    CreationDate = ñreationDate,
                    LastChangeDate = lastChangeDate,
                    Status = (UserStatusEnum)rand.Next(0, Enum.GetValues(typeof(UserStatusEnum)).Length)
                };
                users.Add(user);
            }
            List<Task> tasks = new List<Task>();
            for (int i = 1; i <= 24; i++)
            {
                int senderid = rand.Next(0, users.Count);
                int receiverId;
                do
                {
                    receiverId = rand.Next(0, users.Count);
                }
                while (senderid == receiverId);

                UserStatusEnum senderStatus = users[senderid].Status;
                UserStatusEnum receiverStatus = users[receiverId].Status;

                int j = 0;
                while ((users[receiverId].CreationDate > users[senderid].LastChangeDate || users[receiverId].LastChangeDate < users[senderid].CreationDate) && j < 100)
                {
                    senderid = rand.Next(0, users.Count);
                    do
                    {
                        receiverId = rand.Next(0, users.Count);
                    }
                    while (senderid == receiverId);
                    senderStatus = users[senderid].Status;
                    receiverStatus = users[receiverId].Status;
                    j++;
                }

                TaskStatusEnum taskStatus = (TaskStatusEnum)rand.Next(0, Enum.GetValues(typeof(TaskStatusEnum)).Length);

                DateTime creationDate = users[senderid].LastChangeDate.AddDays(rand.Next(0,(users[senderid].LastChangeDate - users[senderid].CreationDate).Days));
                DateTime lastChangeDate = users[receiverId].LastChangeDate.AddDays(rand.Next(0, (users[receiverId].LastChangeDate - users[receiverId].CreationDate).Days));

                if (senderStatus == UserStatusEnum.Blocked || receiverStatus == UserStatusEnum.Blocked)
                    do
                    {
                        creationDate = users[senderid].LastChangeDate.AddDays(rand.Next(0, Math.Abs((users[receiverId].LastChangeDate - users[senderid].LastChangeDate).Days)));
                        lastChangeDate = creationDate.AddDays(rand.Next(0, 3));//users[receiverId].LastChangeDate.AddDays(rand.Next(0, (users[receiverId].LastChangeDate - users[receiverId].CreationDate).Days));

                    } while (creationDate <= users[senderid].LastChangeDate
                    || lastChangeDate <= users[receiverId].LastChangeDate
                    || lastChangeDate < creationDate
                    || creationDate == DateTime.MinValue
                    || lastChangeDate == DateTime.MinValue);


                Task task = new()
                {
                    TaskId = i,
                    Name = "Çàäà÷à ¹" + i,
                    Description = "Îïèñàíèå çàäà÷è ¹" + i,
                    Status = taskStatus,
                    SenderId = senderid + 1,
                    ReceiverId = receiverId + 1,
                    CreationDate = creationDate,
                    LastChangeDate = lastChangeDate,
                };
                tasks.Add(task);

                Users = users;
                Tasks = tasks;
            }
        }
    }
}