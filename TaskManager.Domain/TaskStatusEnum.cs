using System.ComponentModel;

namespace TaskManager.Domain
{
    public enum TaskStatusEnum
    {
        [Description("Не начата")]
        NotStarted,
        [Description("В процессе")]
        InProgress,
        [Description("Выполнен")]
        Completed,
        [Description("Отменен")]
        Canceled,
        [Description("Отклонен")]
        Rejected
    }
}