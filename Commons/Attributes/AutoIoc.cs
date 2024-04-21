using System;
using BraveStory.Commons.Enums;

namespace BraveStory.Commons.Attributes;

[AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class)]
public class AutoIoc : Attribute
{
    /// <summary>
    ///     ioc注入类型,生命周期
    /// </summary>
    public IocLifeCycle IocLifeCycle { get; set; } = IocLifeCycle.Transient;

    /// <summary>
    ///     ioc注入类型，只要注入实现类、注入接口和其实现类
    /// </summary>
    public IocStrategy IocStrategy { get; set; } = IocStrategy.Interfaces;
}