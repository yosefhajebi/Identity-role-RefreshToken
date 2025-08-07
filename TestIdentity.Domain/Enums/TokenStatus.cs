namespace TestIdentity.Domain.Enums;

public enum TokenStatus
{
    Active = 0,     // توکن معتبر و قابل استفاده
    Expired = 1,    // تاریخ انقضا گذشته
    Revoked = 2     // به‌صورت دستی باطل شده
}