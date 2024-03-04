using SK_GamingSolution.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SK_GamingSolution.Permissions;

public class SK_GamingSolutionPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SK_GamingSolutionPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(SK_GamingSolutionPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SK_GamingSolutionResource>(name);
    }
}
