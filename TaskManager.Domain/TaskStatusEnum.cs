namespace TaskManager.Domain
{
    public enum TaskStatusEnum
    {
        //Не начата
        NotStarted,
        //В процессе
        InProgress,
        //Выполнен
        Completed,
        //Отменен
        Canceled,
        //Отклонен
        Rejected
    }
}