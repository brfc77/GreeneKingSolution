using GreeneKingSpeaker.Calculators;
using GreeneKingSpeaker.Repository;
using GreeneKingSpeaker.Validation;
using GreeneKingSpeaker.Validation.Evalutator;
using GreeneKingSpeaker.Validation.Rules.QualificationRules;
using GreeneKingSpeaker.Validation.Rules.SessionRules;
using GreeneKingSpeaker.Validation.Rules.ValidationRules;
using GreeneKingSpeaker.Validation.Validators;

namespace GreeneKingSpeaker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register session rules
            services.AddScoped<ISessionRule, NonEmptyRule>();
            services.AddScoped<ISessionRule, OutdatedTechnologyRule>();
            services.AddScoped<ISessionRule, SufficientDescriptionRule>();

            // Register Qualifcation rules
            services.AddScoped<IQualificationRule, BlogRule>();
            services.AddScoped<IQualificationRule, BrowserRule>();
            services.AddScoped<IQualificationRule, CertificationRule>();
            services.AddScoped<IQualificationRule, EmailDomainRule>();
            services.AddScoped<IQualificationRule, EmployerRule>();
            services.AddScoped<IQualificationRule, ExperienceRule>();

            // Register basic rules
            services.AddScoped<IValidationRule, EmailRequiredRule>();
            services.AddScoped<IValidationRule, FirstNameRequiredRule>();
            services.AddScoped<IValidationRule, LastNameRequiredRule>();

            // Register validators
            services.AddScoped<IValidator, SessionValidator>();
            services.AddScoped<IValidator, QualificationValidator>();
            services.AddScoped<IValidator, BasicValidator>();
            
            // Register Checker
            services.AddScoped<ISpeakerChecker, SpeakerChecker>();

            // Register repo
            services.AddScoped<ISpeakerRegisterRepository, SpeakerRegisterRepository>();

            // Calculator
            services.AddScoped<IFeeCalculator, FeeCalculator>();

            //Evaluators
            services.AddScoped<ISessionEvaluator, SessionEvaluator>();

            // Register Checker
            services.AddScoped<ISpeakerRegister, SpeakerRegister>();

            // Add any other services you need
            // services.AddScoped<IMyService, MyService>();

            return services;
        }
    }
}
