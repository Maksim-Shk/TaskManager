namespace TaskManager.Domain
{
    public class Task
    {
        public Task() { }
        /// <summary>
        /// Идентификатор задачи
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Описание задачи
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Дата создания задачи
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Дата последнего изменения задачи
        /// </summary>
        public DateTime LastChangeDate { get; set; }

        /// <summary>
        /// Идентификатор постановщика задачи
        /// </summary>
        public int SenderId { get; set; }

        /// <summary>
        /// Идентификатор Исполнителя задачи
        /// </summary>
        public int ReceiverId { get; set; }

        /// <summary>
        /// Статус задачи (Не начата, В процессе, Выполнен, Отменен, Отклонен)
        /// </summary>
        public TaskStatusEnum Status { get; set; }

        /// <summary>
        /// Постановщик задачи
        /// </summary>
        public virtual User Sender { get; set; }

        /// <summary>
        /// Исполнитель задачи
        /// </summary>
        public virtual User Receiver { get; set; }

    }
}