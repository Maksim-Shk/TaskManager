using System.ComponentModel;

namespace TaskManager.Domain
{
    public enum TaskStatusEnum
    {
        [Description("�� ������")]
        NotStarted,
        [Description("� ��������")]
        InProgress,
        [Description("��������")]
        Completed,
        [Description("�������")]
        Canceled,
        [Description("��������")]
        Rejected
    }
}