using System.ComponentModel;

namespace TaskManager.Domain
{
    public enum UserStatusEnum
    {
        [Description("Активен")]
        Active,
        [Description("Отключен")]
        Inactive,
        [Description("Заблокирован")]
        Blocked
    }
}