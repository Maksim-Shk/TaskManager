using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TaskManager.Application.Interfaces;
using TaskManager.Domain;

namespace TaskManager.Persistence
{
    public class TaskManagerContext : DbContext, ITaskManagerContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options)
            : base(options) { }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                //entity.HasIndex(e => e.UserId, "user_id");
                entity.HasKey(e => e.UserId)
                   .HasName("user_pkey");

                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .HasMaxLength(64)
                    .HasColumnName("surname");

                entity.Property(e => e.CreationDate)
                  .HasColumnType("timestamp with time zone")
                  .HasColumnName("create_date");

                entity.Property(e => e.LastChangeDate)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("last_change_date");

                entity.Property(e => e.Status)
                .HasConversion(v => v.ToString(),
                v => (UserStatusEnum)Enum.Parse(typeof(UserStatusEnum), v)).IsUnicode(false)
                .HasColumnType("character varying")
                .HasMaxLength(64)
                .HasColumnName("status")
                .HasDefaultValue(UserStatusEnum.Active);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                   .HasName("task_pkey");

                entity.HasIndex(e => e.SenderId, "sender_fkey");

                entity.HasIndex(e => e.ReceiverId, "receiver_fkey");

                entity.ToTable("task");

                entity.Property(e => e.TaskId)
                    .HasColumnName("task_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name");

                entity.Property(e => e.Description)
                    .HasMaxLength(4096)
                    .HasColumnName("description");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("create_date");

                entity.Property(e => e.LastChangeDate)
                   .HasColumnType("timestamp with time zone")
                   .HasColumnName("last_change_date");

                entity.Property(e => e.Status)
                   .HasConversion(v => v.ToString(),
                   v => (TaskStatusEnum)Enum.Parse(typeof(TaskStatusEnum), v)).IsUnicode(false)
                   .HasColumnType("character varying")
                   .HasMaxLength(64)
                   .HasColumnName("status")
                   .HasDefaultValue(TaskStatusEnum.NotStarted);

                entity.HasOne(d => d.Receiver)
                   .WithMany(p => p.ReceiverTasks)
                   .HasForeignKey(d => d.ReceiverId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("task_id_receiver_fkey");

                entity.HasOne(d => d.Sender)
                   .WithMany(p => p.SenderTasks)
                   .HasForeignKey(d => d.SenderId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("task_id_sender_fkey");

                entity.Property(e => e.SenderId)
                .HasColumnName("sender_id");

                entity.Property(e => e.ReceiverId)
               .HasColumnName("receiver_id");
            });

            List<User> users = new List<User>();
            RandomData randomData = new();
            Random rand = new();
            for (int i = 1; i <= 5; i++)
            {
                DateTime сreationDate = DateTime.MinValue;
                DateTime lastChangeDate = DateTime.MinValue;
                do
                {
                    сreationDate = randomData.RandomDay().AddDays(-10);
                    lastChangeDate = randomData.RandomDay().AddDays(-5);
                } 
                while (lastChangeDate < сreationDate);

                User user = new()
                {
                    UserId = i,
                    Name = randomData.GetRandomName(),
                    Surname = randomData.GetRandomSurname(),
                    CreationDate = сreationDate,
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

                TaskStatusEnum taskStatus = (TaskStatusEnum)rand.Next(0, Enum.GetValues(typeof(TaskStatusEnum)).Length);

                DateTime creationDate = DateTime.MinValue;
                DateTime lastChangeDate = DateTime.MinValue;

                if (senderStatus == UserStatusEnum.Blocked || receiverStatus == UserStatusEnum.Blocked)
                    do
                    {
                        creationDate = randomData.RandomDay();
                        lastChangeDate = randomData.RandomDay();

                    } while (creationDate <= users[senderid].LastChangeDate 
                    || lastChangeDate <= users[receiverId].LastChangeDate
                    || lastChangeDate < creationDate
                    || creationDate == DateTime.MinValue
                    || lastChangeDate == DateTime.MinValue);


                Task task = new()
                {
                    TaskId = i,
                    Name = "Задача №" + i,
                    Description = "Описание задачи №" + i,
                    Status = taskStatus,
                    SenderId = senderid + 1,
                    ReceiverId = receiverId + 1,
                    CreationDate = creationDate,
                    LastChangeDate = lastChangeDate,
                };
                tasks.Add(task);
            }
            modelBuilder.Entity<User>().HasData(users);
            //new User[]
            //{
            //    new User { UserId = 1, Name = "Иван", Surname = "Первый", CreationDate = DateTime.UtcNow.AddDays(-14), LastChangeDate = DateTime.UtcNow.AddDays(-13) , Status = UserStatusEnum.Active},
            //    new User { UserId = 2, Name = "Иван", Surname = "Второй", CreationDate = DateTime.UtcNow.AddDays(-13), LastChangeDate = DateTime.UtcNow.AddDays(-1),  Status = UserStatusEnum.Blocked},
            //    new User { UserId = 3, Name = "Иван", Surname = "Третий", CreationDate = DateTime.UtcNow.AddDays(-12), LastChangeDate = DateTime.UtcNow.AddDays(-11),  Status = UserStatusEnum.Inactive},
            //    new User { UserId = 4, Name = "Иван", Surname = "Четвертый", CreationDate = DateTime.UtcNow.AddDays(-11), LastChangeDate = DateTime.UtcNow.AddDays(-10),  Status = UserStatusEnum.Active}
            //});

            modelBuilder.Entity<Task>().HasData(tasks);
            //new Task[]
            //{
            //    new Task { TaskId = 1, Name = "Задача 1", Description = "Описание задачи 1", CreationDate = DateTime.UtcNow.AddDays(-4), LastChangeDate = DateTime.UtcNow.AddDays(-4), ReceiverId = 4, SenderId = 1, Status = TaskStatusEnum.NotStarted},
            //    new Task { TaskId = 2, Name = "Задача 2", Description = "Описание задачи 2", CreationDate = DateTime.UtcNow.AddDays(-3), LastChangeDate = DateTime.UtcNow.AddDays(-2), ReceiverId = 2, SenderId = 1, Status = TaskStatusEnum.Completed},
            //    new Task { TaskId = 3, Name = "Задача 3", Description = "Описание задачи 3", CreationDate = DateTime.UtcNow.AddDays(-2), LastChangeDate = DateTime.UtcNow.AddDays(-1), ReceiverId = 3, SenderId = 1, Status = TaskStatusEnum.InProgress},
            //    new Task { TaskId = 4, Name = "Задача 4", Description = "Описание задачи 4", CreationDate = DateTime.UtcNow.AddDays(-1), LastChangeDate = DateTime.UtcNow, ReceiverId = 3, SenderId = 4, Status = TaskStatusEnum.InProgress}
            //});
        }
    }
}