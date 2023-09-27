namespace Osaka.Bot.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddOsaka(this IServiceCollection services)
    {
        services.AddScoped<IChatScopeService, ChatScopeService>();
        services.AddScoped<IChatFlowService, ChatFlowService>();
        services.AddScoped<ITextCommandService, TextCommandService>();
        services.AddScoped<IDialogueService, DialogueService>();
        services.AddScoped<IInputService, InputService>();
        services.AddScoped<IAutoInputService, AutoInputService>();
        services.AddScoped<IReportService, ReportService>();
        services.AddScoped<ITriggerService, TriggerService>();
        services.AddScoped<IValidationService, ValidationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICrewService, CrewService>();

        services.AddScoped<IEffectDispatcher, EffectDispatcher>();
        services.AddScoped<ITextSetterDispatcher, TextSetterDispatcher>();

        services.Scan(scan => scan
            .FromAssemblyOf<IEffectApplier>()
                .AddClasses(classes => classes.AssignableTo(typeof(IEffectApplier<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
            .FromAssemblyOf<ITextSetterApplier>()
                .AddClasses(classes => classes.AssignableTo(typeof(ITextSetterApplier<>)))
                    .AsImplementedInterfaces()
                    .WithScopedLifetime()
        );

        return services;
    }
}
