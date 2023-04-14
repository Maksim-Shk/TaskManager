namespace TaskManager.Domain
{
    public class Task
    {
        public Task() { }
        /// <summary>
        /// ������������� ������
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// �������� ������
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ���� �������� ������
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// ���� ���������� ��������� ������
        /// </summary>
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// ������������� ������������ ������
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// ������������� ����������� ������
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// ������ ������ (�� ������, � ��������, ��������, �������, ��������)
        /// </summary>
        public TaskStatusEnum Status { get; set; }

        /// <summary>
        /// ����������� ������
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// ����������� ������
        /// </summary>
        public virtual User Receiver { get; set; }

    }
}