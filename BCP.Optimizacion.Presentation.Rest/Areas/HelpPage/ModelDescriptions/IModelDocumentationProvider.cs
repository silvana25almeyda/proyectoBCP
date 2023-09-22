using System;
using System.Reflection;

namespace BCP.Optimizacion.Presentation.Rest.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}