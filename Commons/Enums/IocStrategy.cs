namespace BraveStory.Commons.Enums;

/// <summary>
///     ioc对象类型
/// </summary>
public enum IocStrategy
{
    //只要注入实现类
    OnlyClass,

    //注入接口及其实现类
    Interfaces
}