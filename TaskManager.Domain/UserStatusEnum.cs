using System.ComponentModel;

namespace TaskManager.Domain
{
    public enum UserStatusEnum
    {
        [Description("�������")]
        Active,
        [Description("��������")]
        Inactive,
        [Description("������������")]
        Blocked
    }
}