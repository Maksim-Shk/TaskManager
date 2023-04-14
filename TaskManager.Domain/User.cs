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
        /// ������������� ������������
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// ��� ������������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ������� ������������
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// ���� �����������
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// ���� ���������� ��������� ���������� � ������������
        /// </summary>
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// ������ ������������ (�������,��������,������������)
        /// </summary>
        public UserStatusEnum Status { get; set; }

        /// <summary>
        /// ������ �������� �������������
        /// </summary>
        public virtual ICollection<Task> SenderTasks { get; set; }
        /// <summary>
        /// ������ �������� ������������
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