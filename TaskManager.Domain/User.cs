namespace TaskManager.Domain
{
    public class User
    {
        public User()
        {
            SenderTasks = new HashSet<Task>();
            ReceiverTasks = new HashSet<Task>();
        }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата последнего изменения информации о пользователе
        /// </summary>
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// Статус пользователя (Активен,Отключен,Заблокирован)
        /// </summary>
        public UserStatusEnum Status { get; set; }

        /// <summary>
        /// задачи выданные пользователем
        /// </summary>
        public virtual ICollection<Task> SenderTasks { get; set; }
        /// <summary>
        /// задачи выданные пользователю
        /// </summary>
        public virtual ICollection<Task> ReceiverTasks { get; set; }
    }
   
    //public class UserStatus
    //{
    //    private UserStatus(UserStatusEnum @enum)
    //    {
    //        Id = (int)@enum;
    //        Name = @enum.ToString();
    //    }

    //    public int Id { get; set; }
    //    public string Name { get; set;}

    //}
}