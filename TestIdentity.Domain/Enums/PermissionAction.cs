namespace TestIdentity.Domain.Enums;

public enum PermissionAction
{
    Read = 0,       // مشاهده
    Create = 1,     // ایجاد
    Update = 2,     // ویرایش
    Delete = 3,     // حذف
    Execute = 4     // اجرای عملیات خاص (مثلاً تایید، ارسال، چاپ)
}
