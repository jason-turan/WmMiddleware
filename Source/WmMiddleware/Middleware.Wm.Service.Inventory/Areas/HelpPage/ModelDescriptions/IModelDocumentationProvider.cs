using System;
using System.Reflection;

namespace NB.DTC.Aptos.InventoryService.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}